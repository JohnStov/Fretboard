module Scale.State

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

let modifiers = [
  ("Major", major)
  ("Minor", minor)
  ("Blues", blues)
  ("Blues Minor", bluesMinor)
  ("Pentatonic", pentatonic)
  ("Pentatonic Minor", pentatonicMinor)
  ("Chromatic", (id)) ]

let init () : Model * Cmd<Msg> =
  {tuning = guitar; root = C; modifier = major}, []

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
  | ModifierName str ->
      let modifier =
        modifiers |> List.find (fun (n, _) -> n = str) |> snd
      {model with modifier = modifier}, []
