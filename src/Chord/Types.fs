module Chord.Types

open Theory.Scale
open Theory.Tab

type Model = 
  {
    tuning : Tuning;     
    root : Note;
    chord : Scale -> Scale
  }

type Msg =
  | TuningName of string
  | RootName of string
  | ChordName of string
