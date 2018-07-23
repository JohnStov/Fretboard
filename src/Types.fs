module App.Types

open Global

type Msg =
  | HomeMsg of Home.Types.Msg
  | ScaleMsg of Scale.Types.Msg

type Model = {
    currentPage: Page
    home: Home.Types.Model
    scale: Scale.Types.Model
  }
