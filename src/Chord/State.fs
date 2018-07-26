module Chord.State

open Theory.Scale
open Theory.Tab

open Elmish
open Types

let tunings = [
  ("Standard", guitar)
  ("Open G", openG)
  ("Open D", openD)
  ("DADGAD", dadgad)
  ("Ukulele", ukulele)
  ("Mandolin", mandolin) ]

let init () : Model * Cmd<Msg> =
  {tuning = guitar}, []

let update msg model : Model * Cmd<Msg> =
  match msg with
  | TuningName str ->
      let tuning = 
        tunings |> List.find (fun (n, _) -> n = str) |> snd
      {model with tuning = tuning}, []
