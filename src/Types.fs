module App.Types

open Global

type Msg =
  | ScaleMsg of Scale.Types.Msg
  | ChordMsg of Chord.Types.Msg

type Model = {
    currentPage: Page
    scale: Scale.Types.Model
    chord: Chord.Types.Model
  }
