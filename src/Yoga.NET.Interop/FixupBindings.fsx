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
    Regex("public enum \w+ : (?<type>\w+)|((?<a>\w+ = )(?<b>YG\w+,))+"),
    (fun (m, ctx) ->
        let _t = m.Groups["type"].Value
        if not (String.IsNullOrEmpty _t) then
            ctx.lastEnumType <- _t
            m.Value
        else
            m.Groups["a"].Value + $"(%s{ctx.lastEnumType})" + m.Groups["b"].Value
    )
    Regex("(?<=\d)'"), (fun (_, _) -> "")
    Regex("NaN"), (fun (_, _) -> "Single.NaN")
    Regex("(private|public) array<(?<type>\w+),\s*(?<size>\d+)>"),
    (fun (m, _) -> sprintf "InlineArray%s<%s>" (m.Groups["size"].Value) (m.Groups["type"].Value))
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
