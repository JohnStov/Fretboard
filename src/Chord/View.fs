module Chord.View

open Types
open State
open Theory.Tab
open Theory.Scale

open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props

let root model dispatch =
  let frets = drawTab true 5 model.tuning (model.root |> octave |> model.chord)

  div [ ClassName "container" ]
    [
      div [ ClassName "columns" ]
        [
          div [ ClassName "column is-2" ]
            [
              div [ ClassName "form-group"]
                [
                  p [ ClassName "form-control" ]
                    [ str "Tuning"
                      select 
                        [ ClassName "select"
                          OnChange (fun ev -> !!ev.target?value |> TuningName |> dispatch )]
                        [ for (name, _) in tunings -> option [] [ str name ] ] ]
                  p [ ClassName "form-control" ]
                    [ str "Scale"
                      select
                        [ ClassName "select"
                          OnChange (fun ev -> !!ev.target?value |> RootName |> dispatch )]
                        [ for (name, _) in roots -> option [] [ str name ] ] ]
                  p [ ClassName "form-control" ]
                    [ str "Chord"
                      select
                        [ ClassName "select"
                          OnChange (fun ev -> !!ev.target?value |> ChordName |> dispatch )]
                        [ for (name, _) in chords -> option [] [ str name ] ] ] ] ]
          div [ ClassName "column fretboard" ] 
            [ str frets ] ] ]
                
