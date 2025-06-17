open System
open System.IO
open System.Text.RegularExpressions

let r = Regex("public enum \w+ : (?<type>\w+)|((?<a>\w+ = )(?<b>YG\w+,))+")
let args = fsi.CommandLineArgs |> Array.tail
let processingDir =
    match Array.tryItem 0 args with
    | None -> raise (ArgumentException("No processing directory specified."))
    | Some x -> x

printfn "Performing fixups..."

printfn "Enum fixup..."
for filePath in Directory.EnumerateFiles processingDir do
    printf "Fixing '%s'..." filePath
    let text = File.ReadAllText filePath
    let mutable occurrences = 0
    let mutable t = "missing_type"
    let replacement =
        r.Replace (text, MatchEvaluator(fun m ->
            let _t = m.Groups["type"].Value
            if not (String.IsNullOrEmpty _t) then
                t <- _t
                m.Value
            else
                occurrences <- occurrences + 1
                m.Groups["a"].Value + $"(%s{t})" + m.Groups["b"].Value))
    if occurrences = 0 then
        printfn $" \u001b[90mNo replacements needed.\u001b[0m"
    else
        File.WriteAllText (filePath, replacement)
        printfn $" \u001b[37mReplaced %i{occurrences} occurrences.\u001b[0m"
        // printfn "\t\u001b[37m%s\u001b[0m" replacement

printfn "Done."

printfn "Fixups successful."
