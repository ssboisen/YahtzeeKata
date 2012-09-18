module Yahtzee.Model

type Roll = int * int * int * int * int

type Combination =
    | Ones
    | Twos
    | Threes
    | Fours
    | Fives
    | Sixes
    | Pair
    | TwoPairs
    | ThreeOfAKind
    | FourOfAKind
    | SmallStraight
    | LargeStraight
    | FullHouse
    | Yahtzee
    | Chance

let calcScore combination roll =
    let roll = roll |> List.sort
    let calcForNumberCombination number roll =
        roll |> Seq.filter (fun f -> f = number) |> Seq.sum
    let findGroupsOf number roll =
        roll |> Seq.groupBy id 
             |> Seq.filter (fun f -> (snd f) |> Seq.length >= number) 
    let findGroupsOfExact number roll =
        roll |> Seq.groupBy id 
             |> Seq.filter (fun f -> (snd f) |> Seq.length = number)
    let collectSum list =
        list |> Seq.sumBy (fun f -> snd f |> Seq.sum)
    match combination with
        | Ones  -> roll |> calcForNumberCombination 1
        | Twos  -> roll |> calcForNumberCombination 2
        | Threes -> roll |> calcForNumberCombination 3
        | Fours -> roll |> calcForNumberCombination 4
        | Fives -> roll |> calcForNumberCombination 5
        | Sixes -> roll |> calcForNumberCombination 6
        | Pair -> let pairs = findGroupsOf 2 roll
                  if pairs |> Seq.length > 0 then
                    pairs |> Seq.maxBy fst |> snd |> Seq.sum
                  else 
                    0
        | TwoPairs -> let pairs = findGroupsOf 2 roll
                      if pairs |> Seq.length > 1 then
                        pairs |> collectSum
                      else
                        0 
        | ThreeOfAKind -> roll  |> findGroupsOf 3 |> collectSum
        | FourOfAKind -> roll |> findGroupsOf 4 |> collectSum
        | SmallStraight -> match roll with
                            | [1;2;3;4;5] -> 15
                            | _ -> 0
        | LargeStraight -> match roll with
                            | [2;3;4;5;6] -> 20
                            | _ -> 0
        | FullHouse ->  let pair = findGroupsOfExact 2 roll
                        let triple = findGroupsOfExact 3 roll
                        if pair |> Seq.length = 1 then
                            (pair |> collectSum) + (triple |> collectSum)
                        else
                            0
        | Yahtzee ->  let yahtzee = findGroupsOfExact 5 roll
                      if yahtzee |> Seq.length = 1 then
                        50
                      else
                        0
        | Chance -> roll |> Seq.sum