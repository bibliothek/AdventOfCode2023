module AdventOfCode2023.Solver.Day10

open AdventOfCodeHelpers
open AdventOfCodeHelpers.Array2DHelper

let getNextDirection (enter: Direction) (pipe: char) =
    match enter, pipe with
    | Up, '|' -> Some Up
    | Up, '7' -> Some Left
    | Up, 'F' -> Some Right
    | Left, '-' -> Some Left
    | Left, 'F' -> Some Down
    | Left, 'L' -> Some Up
    | Right, '-' -> Some Right
    | Right, 'J' -> Some Up
    | Right, '7' -> Some Down
    | Down, '|' -> Some Down
    | Down, 'J' -> Some Left
    | Down, 'L' -> Some Right
    | _ -> None

let getValidStartingDirections (map: char array2d) pos =
    let startingDirections =
        [ ((tryGetLeft map pos), Left)
          ((tryGetRight map pos), Right)
          ((tryGetUp map pos), Up)
          ((tryGetDown map pos), Down) ]

    startingDirections
    |> List.filter (fst >> Option.isSome)
    |> List.map (fun (el, direction) -> ((direction, el.Value), getNextDirection direction (el.Value |> fst)))
    |> List.filter (snd >> Option.isSome)
    |> List.map fst

let getStartingPos map =
    map |> toSeqi |> Seq.find (fun (_, el) -> el = 'S') |> fst

let rec traverse (map: char array2d) startPos pos direction count =
    if startPos = pos && count > 0 then count
    else
        let currentVal = map[pos |> fst, pos |> snd]
        let nextDirection = getNextDirection direction currentVal |> Option.get
        let nextPos = tryGetWithDirection map pos nextDirection |> Option.get |> snd
        // let nextPos =
        traverse map startPos nextPos nextDirection (count + 1)

let solver1 (lines: string array) =
    let map = buildFromLines lines
    let startingPos = getStartingPos map
    let validStartingDirections = getValidStartingDirections map startingPos
    let startingDirection = validStartingDirections.Head
    (traverse map startingPos (startingDirection |> snd |> snd) (startingDirection |> fst) 1) / 2

let solver2 (lines: string array) = failwith "error"
