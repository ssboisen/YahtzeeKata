module Yahtzee.Specs

open NaturalSpec
open Yahtzee.Model

// Utils
let placed on combination roll =
    printMethod combination
    calcScore combination roll

let on = ()


[<Scenario>]
let ``Given 1, 1, 2, 4, 4 placed on fours gives 8 points.``() =
  Given [1; 1; 2; 4; 4]
    |> When placed on Fours
    |> It should equal 8
    |> Verify

[<Scenario>]
let ``Given 1, 1, 2, 4, 4 placed on ones gives 2 points.``() =
  Given [1; 1; 2; 4; 4]
    |> When placed on Ones
    |> It should equal 2
    |> Verify
