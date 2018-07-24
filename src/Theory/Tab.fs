module Theory.Tab

open Scale

type Tuning = Note list
let guitar : Tuning = [E; A; D; G; B; E]
let openG : Tuning = [D; G; D; G; B; D]
let openD : Tuning = [D; A; D; Fsharp; A; D]
let dadgad : Tuning = [D; A; D; G; A; D]
let ukulele : Tuning = [G; C; E; A]
let mandolin : Tuning = [G; D; A; E]

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

let drawTab showFretNumbers nFrets tuning scale=
    let stringNotes = tuning |> List.map (fun root -> notePositions (nFrets+1) root scale)
    let isStringNote fret root =
        let index = tuning |> List.findIndex (fun x -> x = root)
        stringNotes.[index] |> List.contains fret

    let tuningLine =
        ["   "]
        @ (seq { for n in tuning -> sprintf "%-2s" (noteName n) } |> Seq.toList)
        |> String.concat ""

    let nut =
        if showFretNumbers then
            [" 0┌"]
        else
            ["  ┌"]
        @ [(seq { for root in tuning -> if root |> isStringNote 0 then "O" else "┬"} |> String.concat "─")]
        @ ["┐"]
        |> String.concat ""

    let board n =
        ["  │"]
        @ [(seq { for root in tuning -> if root |> isStringNote n then "O" else "│"} |> String.concat " ")]
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

    let boards = seq { for i in [1 .. nFrets] -> board i}
    let frets = seq { for i in [1 .. nFrets] -> fret i}
    let fretboard = Seq.zip boards frets |> Seq.collect (fun (x, y) -> [x; y])
    let frets = seq {
        yield tuningLine
        yield nut
        yield! fretboard
    }
    String.concat "\n\r" frets
