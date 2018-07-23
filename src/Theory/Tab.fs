module Theory.Tab

open Scale

type Tuning = Note list
let guitar : Tuning = [E; A; D; G; B; E]
let openG : Tuning = [D; G; D; G; B; D]
let openD : Tuning = [D; A; D; Fsharp; A; D]
let dadgad : Tuning = [D; A; D; G; A; D]
let ukulele : Tuning = [G; C; E; A]

let noteName note =
    match note with
    | C -> "C"
    | Csharp -> "C♯"
    | D -> "D"
    | Eflat -> "E♭"
    | E -> "E"
    | F -> "F"
    | Fsharp -> "F♯"
    | G -> "G"
    | Aflat -> "A♭"
    | A -> "A"
    | Bflat -> "B♭"
    | B -> "B"

let drawTab showFretNumbers nFrets tuning =
    let tuningLine = 
        ["   "] 
        @ (seq { for n in tuning -> sprintf "%-2s" (noteName n) } |> Seq.toList)
        |> String.concat ""
    
    let nut =
        if showFretNumbers then
            [" 0┌"]
        else
            ["  ┌"]
        @ [(seq { for _ in tuning -> "┬"} |> String.concat "─")]
        @ ["┐"]
        |> String.concat ""

    let board = 
        ["  │"]
        @ [(seq { for _ in tuning -> "│"} |> String.concat " ")]
        @ ["│"]
        |> String.concat ""

    let fret n =
        if showFretNumbers then
            [sprintf "%2d├" n]
        else
            ["  ├"]
        @ [(seq { for _ in tuning -> "┼"} |> String.concat "─")]
        @ ["┤"]
        |> String.concat ""

    let boards = seq { for _ in [1 .. nFrets] -> board}
    let frets = seq { for i in [1 .. nFrets] -> fret i}
    let fretboard = Seq.zip boards frets |> Seq.collect (fun (x, y) -> [x; y])
    seq {
        yield tuningLine
        yield nut
        yield! fretboard
    }
