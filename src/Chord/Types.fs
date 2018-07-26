module Chord.Types

open Theory.Scale
open Theory.Tab

type Model = 
  {
    tuning : Tuning;     
  }

type Msg =
  | TuningName of string
