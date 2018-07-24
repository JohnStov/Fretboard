module Scale.Types

open Theory.Scale
open Theory.Tab

type Model = 
  {
    tuning : Tuning;     
    root : Note;
    modifier: Scale -> Scale
  }

type Msg =
  | TuningName of string
  | RootName of string
  | ModifierName of string
