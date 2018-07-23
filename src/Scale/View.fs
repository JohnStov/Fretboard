module Scale.View

open Theory.Tab
open Theory.Scale

open Fable.Helpers.React

let root model dispatch =
  let frets = (drawTab true 5 openD)
  let cMaj = octave C |> major
  let lines = drawTab true 5 openD cMaj |> Seq.map (fun x -> [str x; br []]) |> Seq.collect id |> Seq.toList

  div
    [ ]
    lines
