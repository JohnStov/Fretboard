module Global

type Page =
  | Scale
  | Chord
  | About

let toHash page =
  match page with
  | About -> "#about"
  | Scale -> "#scale"
  | Chord -> "#chord"
