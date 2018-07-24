module Scale.View

open Types
open State
open Theory.Tab
open Theory.Scale

open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props

let root model dispatch =
  let frets = drawTab true 12 model.tuning (model.root |>octave |> model.modifier)

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
                    [ str "Division"
                      select
                        [ ClassName "select"
                          OnChange (fun ev -> !!ev.target?value |> ModifierName |> dispatch )]
                        [ for (name, _) in modifiers -> option [] [ str name ] ] ] ] ]
          div [ ClassName "column fretboard" ]
            [ str frets ] ] ]

