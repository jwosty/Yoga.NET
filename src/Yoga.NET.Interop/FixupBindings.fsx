open System
open System.IO
open System.Text.RegularExpressions

let args = fsi.CommandLineArgs |> Array.tail
let processingDir =
    match Array.tryItem 0 args with
    | None -> raise (ArgumentException("No processing directory specified."))
    | Some x -> x

printfn "Performing fixups..."

type Ctx = { mutable lastEnumType: string }
type Fixup = Regex * (Match * Ctx -> string)

let fixups: Fixup list = [
    // fix this specific enum case being a red herring for ClangSharpPInvokeGenerator enum prefix strip (special case -
    // this enum field is the name of the overall enum)
    Regex(" = YGWrap.YGWrapWrap,"), (fun (_, _) -> "Wrap = YGWrap.YGWrapWrap,")
    // work around ClangSharpPInvokeGenerator not adding casts where necessary in enum definitions depending on values
    // of a different type (that gets implicitly cast in C)
    Regex("public enum \w+ : (?<type>\w+)|((?<a>\w+ = )(?<b>YG[a-zA-Z.]+,))+"), (fun (m, ctx) ->
        let _t = m.Groups["type"].Value
        if not (String.IsNullOrEmpty _t) then
            ctx.lastEnumType <- _t
            m.Value
        else
            m.Groups["a"].Value + $"(%s{ctx.lastEnumType})" + m.Groups["b"].Value
    )
    // changing the YG prefix to Yoga in all enum types
    Regex("YG(?=Align|BoxSizing|Dimension|Direction|Display|Edge|Errata|ExperimentalFeature|FlexDirection|Gutter|Justify|LogLevel|MeasureMode|NodeType|PositionType|Unit|Wrap|Overflow)"), (fun (_, _) -> "Yoga")
    // fixing up a bug where ClangSharpPInvokeGenerator doesn't properly handle enum prefix stripping at the call site
    Regex("(Yoga(Align|BoxSizing|Dimension|Direction|Display|Edge|Errata|ExperimentalFeature|FlexDirection|Gutter|Justify|LogLevel|MeasureMode|NodeType|PositionType|Unit|Wrap|Overflow))\.\1"), (fun (m, _) -> m.Groups[1].Value + ".")
    Regex("(?<=\d)'"), (fun (_, _) -> "")
    Regex("NaN"), (fun (_, _) -> "Single.NaN")
    Regex("(private|public) array<(?<type>\w+),\s*(?<size>\d+)>"), (fun (m, _) ->
        sprintf "InlineArray%s<%s>" m.Groups["size"].Value m.Groups["type"].Value)
    Regex("""array<int, unchecked\(\(byte\)\(LayoutPassReason\.COUNT\)\)>"""), (fun (_, _) -> "InlineArray8<int>")
    Regex("""array<CachedMeasurement, MaxCachedMeasurements>"""), (fun (m, _) -> "InlineArray8<CachedMeasurement>")
    Regex("""vector<(?<type>\w+)>"""), (fun (m, _) -> sprintf "CppVector<%s>" m.Groups["type"].Value)
    Regex("SmallValueBuffer<(?<size>\d+)>"), (fun (m, _) -> sprintf "SmallValueBuffer%s" m.Groups["size"].Value)
    Regex("bitset<1>"), (fun (_, _) -> "byte")
    Regex("""(?<=public unsafe partial struct Node.*)public bool _bitfield""", RegexOptions.Singleline), (fun (_, _) ->
        "public byte _bitfield")
    Regex("public partial struct LayoutResults"), (fun (_, _) -> "public unsafe partial struct LayoutResults")
]

for filePath in Directory.EnumerateFiles processingDir do
    printf "Fixing '%s'..." filePath
    let text = File.ReadAllText filePath
    let mutable count = 0
    let mutable ctx = { lastEnumType = "missing_type" }
    let runFixup (fixup: Fixup) text =
        (fst fixup).Replace (text, MatchEvaluator(fun m ->
            let text' = (snd fixup) (m, ctx)
            if text' <> text then
                count <- count + 1
            text'))
    let text = List.fold (fun text fixup -> runFixup fixup text) text fixups
    if count = 0 then
        printfn $" \u001b[90mNo replacements needed.\u001b[0m"
    else
        File.WriteAllText (filePath, text)
        printfn $" \u001b[37mReplaced %i{count} elements.\u001b[0m"
        // printfn "\t\u001b[37m%s\u001b[0m" replacement

printfn "Fixups successful."
