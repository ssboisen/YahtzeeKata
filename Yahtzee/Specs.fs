module Yahtzee.Specs

open NaturalSpec
open Yahtzee.Model

// Utils
let placed on combination roll =
    printMethod combination
    calcScore combination roll

let on = ()

[<Scenario>]
let ``Given 1, 1, 1, 4, 4 placed on ones gives 3 points.``() =
  Given [1; 1; 1; 4; 4]
    |> When placed on Ones
    |> It should equal 3
    |> Verify

[<Scenario>]
let ``Given 2, 2, 2, 4, 4 placed on ones gives 0 points.``() =
  Given [2; 2; 2; 4; 4]
    |> When placed on Ones
    |> It should equal 0
    |> Verify

[<Scenario>]
let ``Given 1, 2, 2, 2, 4 placed on twos gives 6 points.``() =
  Given [1; 2; 2; 2; 4]
    |> When placed on Twos
    |> It should equal 6
    |> Verify

[<Scenario>]
let ``Given 3, 3, 3, 2, 4 placed on threes gives 9 points.``() =
  Given [3; 3; 3; 2; 4]
    |> When placed on Threes
    |> It should equal 9
    |> Verify

[<Scenario>]
let ``Given 1, 1, 4, 4, 4 placed on fours gives 12 points.``() =
  Given [1; 1; 4; 4; 4]
    |> When placed on Fours
    |> It should equal 12
    |> Verify
    
[<Scenario>]
let ``Given 1, 1, 4, 4, 4 placed on fives gives 0 points.``() =
  Given [1; 1; 4; 4; 4]
    |> When placed on Fives
    |> It should equal 0
    |> Verify
    
[<Scenario>]
let ``Given 6, 1, 4, 6, 4 placed on sixes gives 12 points.``() =
  Given [6; 1; 4; 6; 4]
    |> When placed on Sixes
    |> It should equal 12
    |> Verify
    
[<Scenario>]
let ``Given 1, 1, 3, 4, 4 placed on pair gives 8 points.``() =
  Given [1; 1; 3; 4; 4]
    |> When placed on Pair
    |> It should equal 8
    |> Verify

[<Scenario>]
let ``Given 1, 2, 3, 4, 5 placed on pair gives 0 points.``() =
  Given [1; 2; 3; 4; 5]
    |> When placed on Pair
    |> It should equal 0
    |> Verify

[<Scenario>]
let ``Given 1, 1, 2, 3, 3 placed on two pair gives 8 points.``() =
  Given [1; 1; 2; 3; 3]
    |> When placed on TwoPairs
    |> It should equal 8
    |> Verify

[<Scenario>]
let ``Given 1, 2, 3, 3, 3 placed on two pair gives 0 points.``() =
  Given [1; 2; 3; 3; 3]
    |> When placed on TwoPairs
    |> It should equal 0
    |> Verify

[<Scenario>]
let ``Given 3, 3, 3, 4, 5 placed on three of a kind gives 9 points.``() =
  Given [3; 3; 3; 4; 5]
    |> When placed on ThreeOfAKind
    |> It should equal 9
    |> Verify

[<Scenario>]
let ``Given 2, 2, 2, 2, 5 placed on four of a kind gives 8 points.``() =
  Given [2; 2; 2; 2; 5]
    |> When placed on FourOfAKind
    |> It should equal 8
    |> Verify

[<Scenario>]
let ``Given 1, 2, 3, 4, 5 placed on small straight gives 15 points.``() =
  Given [1; 2; 3; 4; 5]
    |> When placed on SmallStraight
    |> It should equal 15
    |> Verify

[<Scenario>]
let ``Given 2, 3, 4, 5, 6 placed on large straight gives 20 points.``() =
  Given [2; 3; 4; 5; 6]
    |> When placed on LargeStraight
    |> It should equal 20
    |> Verify

[<Scenario>]
let ``Given 1, 1, 2, 2, 2 placed on full house gives 8 points.``() =
  Given [1; 1; 2; 2; 2]
    |> When placed on FullHouse
    |> It should equal 8
    |> Verify

[<Scenario>]
let ``Given 4, 4, 4, 4, 4 placed on full house gives 0 points.``() =
  Given [4; 4; 4; 4; 4]
    |> When placed on FullHouse
    |> It should equal 0
    |> Verify


[<Scenario>]
let ``Given 4, 4, 4, 4, 4 placed on yahtzee gives 50 points.``() =
  Given [4; 4; 4; 4; 4]
    |> When placed on Yahtzee
    |> It should equal 50
    |> Verify


[<Scenario>]
let ``Given 4, 4, 4, 3, 4 placed on chance gives 19 points.``() =
  Given [4; 4; 4; 3; 4]
    |> When placed on Chance
    |> It should equal 19
    |> Verify