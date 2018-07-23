module Global
open System.Xml.Schema

type Page =
  | Home
  | Scale
  | About

let toHash page =
  match page with
  | About -> "#about"
  | Scale -> "#scale"
  | Home -> "#home"
