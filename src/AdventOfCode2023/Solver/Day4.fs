module AdventOfCode2023.Solver.Day4

open System

type Card =
    { winningNumbers: Set<int>
      numbers: Set<int> }

let lineToCard (line: string) =
    let noPrefix = line.Split(":").[1].Split("|")
    { winningNumbers = noPrefix.[0].Trim().Split(Array.zeroCreate<char> 0, StringSplitOptions.RemoveEmptyEntries) |> Array.map int |> Set.ofArray
      numbers = noPrefix.[1].Trim().Split(Array.zeroCreate<char> 0, StringSplitOptions.RemoveEmptyEntries) |> Array.map int |> Set.ofArray}

let getCardValue (card:Card) =
    let intersect = Set.intersect card.numbers card.winningNumbers
    if intersect.Count = 0 then 0 else pown 2 (intersect.Count - 1)

let solver1 (lines: string array) =
    lines
    |> Array.map (lineToCard >> getCardValue)
    |> Array.sum

let solver2 (lines: string array) = failwith "error"
