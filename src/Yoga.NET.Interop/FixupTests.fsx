open System
open System.IO
open System.Text.RegularExpressions

let args = fsi.CommandLineArgs |> Array.tail
let processingDir =
    match Array.tryItem 0 args with
    | None -> raise (ArgumentException("No processing directory specified."))
    | Some x -> x

printfn "Performing tests fixups..."

type Ctx = { mutable lastEnumType: string }
type Fixup = Regex * (Match * Ctx -> string)

let fixups: Fixup list = [
    // remove some duplicate test classes
    Regex("(    public static unsafe partial class YGConfigTests\n    {.*?\n    }).*?(    public static unsafe partial class YGConfigTests\n    {.*?\n    })", RegexOptions.Singleline), (fun (m, _) -> m.Groups[1].Value)
    Regex("(    public static unsafe partial class YGNodeTests\n    {.*?\n    }).*?(    public static unsafe partial class YGNodeTests\n    {.*?\n    })", RegexOptions.Singleline), (fun (m, _) -> m.Groups[1].Value)
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

printfn "Test fixups successful."
