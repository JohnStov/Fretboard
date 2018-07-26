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

let roots = [
  ("C", C)
  ("C♯", Csharp)
  ("D", D)
  ("E♭", Eflat)
  ("E", E)
  ("F", F)
  ("F♯", Fsharp)
  ("G", G)
  ("A♭", Aflat)
  ("A", A)
  ("B♭", Bflat)
  ("B", B) ]

let chords = [
  ("Major", major >> triad)
  ("Minor", minor >> triad) ]

let init () : Model * Cmd<Msg> =
  {tuning = guitar; root = C; chord = major >> triad}, []

let update msg model : Model * Cmd<Msg> =
  match msg with
  | TuningName str ->
      let tuning = 
        tunings |> List.find (fun (n, _) -> n = str) |> snd
      {model with tuning = tuning}, []
  | RootName str ->
      let root = 
        roots |> List.find (fun (n, _) -> n = str) |> snd
      {model with root = root}, []
  | ChordName str ->
      let chord = 
        chords |> List.find (fun (n, _) -> n = str) |> snd
      {model with chord = chord}, []
