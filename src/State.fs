module App.State

open Elmish
open Elmish.Browser.Navigation
open Elmish.Browser.UrlParser
open Fable.Import.Browser
open Global
open Types

let pageParser: Parser<Page->Page,Page> =
  oneOf [
    map About (s "about")
    map Scale (s "scale")
    map Chord (s "chord")
  ]

let urlUpdate (result: Option<Page>) model =
  match result with
  | None ->
    console.error("Error parsing url")
    model,Navigation.modifyUrl (toHash model.currentPage)
  | Some page ->
      { model with currentPage = page }, []

let init result =
  let (scale, scaleCmd) = Scale.State.init()
  let (chord, chordCmd) = Chord.State.init()
  let (model, cmd) =
    urlUpdate result
      { currentPage = Scale
        scale = scale
        chord = chord }
  model, Cmd.batch [ cmd
                     Cmd.map ScaleMsg scaleCmd ]

let update msg model =
  match msg with
  | ScaleMsg msg ->
      let (scale, scaleCmd) = Scale.State.update msg model.scale
      { model with scale = scale }, Cmd.map ScaleMsg scaleCmd
  | ChordMsg msg ->
      let (chord, chordCmd) = Chord.State.update msg model.chord
      { model with chord = chord }, Cmd.map ChordMsg chordCmd
