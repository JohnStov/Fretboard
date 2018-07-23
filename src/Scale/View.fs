module Scale.View

open Theory.Tab

open Fable.Helpers.React

let root model dispatch =
  let frets = (drawTab true 5 openD)
  let lines = drawTab true 5 openD |> Seq.map (fun x -> [str x; br []]) |> Seq.collect id |> Seq.toList

  div
    [ ]
    lines 
    