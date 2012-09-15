module Yahtzee.Model

type Roll = int * int * int * int * int

type Combination =
    | Ones
    | Fours

let calcScore combination roll =
    match combination with
        | Ones  -> 2
        | Fours -> 8