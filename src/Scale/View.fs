module Scale.View

open Theory.Tab
open Theory.Scale

open Fable.Helpers.React
open Fable.Helpers.React.Props

let root model dispatch =
  let frets = (drawTab true 5 openD)
  let cMaj = octave C |> major |> triad
  let lines = drawTab true 5 openD cMaj |> Seq.map (fun x -> [str x; br []]) |> Seq.collect id |> Seq.toList

  div
    [ ClassName "fretboard" ]
    lines
