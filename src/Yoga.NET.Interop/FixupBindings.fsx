open System
open System.IO
open System.Text.RegularExpressions

let args = fsi.CommandLineArgs |> Array.tail
let processingDir =
    match Array.tryItem 0 args with
    | None -> raise (ArgumentException("No processing directory specified."))
    | Some x -> x

printfn "Performing fixups..."

let enumFixupReg = Regex("public enum \w+ : (?<type>\w+)|((?<a>\w+ = )(?<b>YG\w+,))+")
let numberFixupReg = Regex("(?<=\d)'")
for filePath in Directory.EnumerateFiles processingDir do
    printf "Fixing '%s'..." filePath
    let text = File.ReadAllText filePath
    let mutable count = 0
    let mutable t = "missing_type"
    let text =
        enumFixupReg.Replace (text, MatchEvaluator(fun m ->
            let _t = m.Groups["type"].Value
            if not (String.IsNullOrEmpty _t) then
                t <- _t
                m.Value
            else
                count <- count + 1
                m.Groups["a"].Value + $"(%s{t})" + m.Groups["b"].Value))
    let text =
        numberFixupReg.Replace (text, MatchEvaluator(fun m -> count <- count + 1; ""))
    if count = 0 then
        printfn $" \u001b[90mNo replacements needed.\u001b[0m"
    else
        File.WriteAllText (filePath, text)
        printfn $" \u001b[37mReplaced %i{count} elements.\u001b[0m"
        // printfn "\t\u001b[37m%s\u001b[0m" replacement

printfn "Fixups successful."
