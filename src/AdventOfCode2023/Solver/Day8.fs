module AdventOfCode2023.Solver.Day8

open System.Collections.Generic

type Node = { id: string; left: string; right: string }

type MyMap = IDictionary<string,Node>

let getMap (lines: string array) =
    lines
    |> Array.map (fun x ->
        (x.Substring(0, 3),
         {
           id = x.Substring(0,3)
           left = x.Substring(7, 3)
           right = x.Substring(12, 3) }))
    |> dict

let rec findDestination (map:MyMap) (instructions: string) (node: Node) (count: int) : int =
    if node.id = "ZZZ" then count
    else
        let instruction = instructions[count % instructions.Length]
        let nextNodeId = match instruction with
                            | 'L' -> node.left
                            | 'R' -> node.right
                            | _ -> failwith "impossible"
        findDestination map instructions map[nextNodeId] (count + 1)

let solver1 (lines: string array) =
    let map = getMap (lines |> Array.skip 2)
    findDestination map lines[0] map["AAA"] 0

let solver2 (lines: string array) = failwith "error"
