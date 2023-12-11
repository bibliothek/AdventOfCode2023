module AdventOfCode2023.Tests.Day10Tests

open AdventOfCode2023.Solver
open Xunit

type Day10Test() =
    let demoData =
        [|
            "..F7."
            ".FJ|."
            "SJ.L7"
            "|F--J"
            "LJ..."
        |]

    [<Fact>]
    let ``Day 10 part 1`` () =
        let solution = Day10.solver1 demoData
        Assert.Equal(8, solution)


    [<Fact>]
    let ``Day 10 part 2`` () =
        let solution = Day10.solver2 demoData
        Assert.Equal("", solution)
