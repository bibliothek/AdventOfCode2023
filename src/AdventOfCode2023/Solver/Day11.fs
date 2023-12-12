module AdventOfCode2023.Solver.Day11

open System
open AdventOfCodeHelpers
open AdventOfCodeHelpers.Array2DHelper

let adjustPoint emptyRowIndices emptyColumnIndices (point:Pos) =
    let newX = (point.x :: emptyColumnIndices |> List.sort |> List.findIndex ((=) point.x)) + point.x
    let newY = (point.y :: emptyRowIndices |> List.sort |> List.findIndex ((=) point.y)) + point.y
    {x = newX; y = newY}

let calculatePath ((a:Pos), (b:Pos)) =
    let distance = Math.Abs(a.x - b.x) + Math.Abs(a.y - b.y)
    (distance, (a,b))

let rec pairs l = seq {
    match l with
    | h::t -> for e in t do yield h, e
              yield! pairs t
    | _ -> () }

let solver1 (lines: string array) =
    let map = Array2DHelper.buildFromLines lines

    let emptyRowIndices =
        lines
        |> Array.indexed
        |> Array.filter (fun (_, row) -> row.ToCharArray() |> Array.forall ((=) '.'))
        |> Array.map fst
        |> List.ofArray

    let emptyColumnIndices =
        Seq.init (lines[0].Length - 1) (id)
        |> Seq.filter (fun i -> map[i, *] |> Array.forall ((=) '.'))
        |> List.ofSeq

    let points = map |> Array2DHelper.toSeqWithPoint |> Seq.filter (snd >> (=) '#') |> Seq.map fst |> Array.ofSeq

    let adjustedPoints = points |> Array.map (adjustPoint emptyRowIndices emptyColumnIndices) |> List.ofArray

    let allPairs = adjustedPoints |> pairs |> List.ofSeq

    let distances = allPairs |> List.map calculatePath
    distances |> List.map fst |> List.sum

let solver2 (lines: string array) = failwith "error"
