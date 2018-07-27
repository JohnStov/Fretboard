module Theory.Scale

type Note =
    | C
    | Csharp
    | D
    | Eflat
    | E
    | F
    | Fsharp
    | G
    | Aflat
    | A
    | Bflat
    | B

type Scale = Note list

let allNotes : Scale = [C; Csharp; D; Eflat; E; F; Fsharp; G; Aflat; A; Bflat; B]

let major (scale : Scale) =
    [ scale.[0]; scale.[2]; scale.[4]; scale.[5]; scale.[7]; scale.[9]; scale.[11] ]

let minor (scale : Scale) =
    [ scale.[0]; scale.[2]; scale.[3]; scale.[5]; scale.[7]; scale.[8]; scale.[10] ]

let pentatonic (scale : Scale) =
    [ scale.[0]; scale.[2]; scale.[4]; scale.[7]; scale.[9] ]

let pentatonicMinor (scale : Scale) =
    [ scale.[0]; scale.[3]; scale.[5]; scale.[7]; scale.[10] ]

let blues (scale : Scale) =
    [ scale.[0]; scale.[2]; scale.[3]; scale.[4]; scale.[7]; scale.[9] ]

let bluesMinor (scale : Scale) =
    [ scale.[0]; scale.[3]; scale.[5]; scale.[6]; scale.[7]; scale.[10] ]

let triad (scale : Scale) =
    [scale.[0]; scale.[2]; scale.[4]]

let chromatic length rootNote : Scale =
    let rec extendToLength (notes : Scale) =
        if notes |> List.length >= length then
            notes |> List.take length
        else
            notes @ allNotes |> extendToLength

    allNotes
    |> List.skipWhile (fun n -> n <> rootNote)
    |> extendToLength

let octave root = chromatic 12 root
let cMaj = octave C |> major
let cMin = octave C |> minor

let notePositions nFrets rootNote scale : int list =
    let stringNotes = chromatic nFrets rootNote

    stringNotes
    |> List.mapi (fun i n -> if (scale |> List.contains n) then Some i else None)
    |> List.choose id

