module AdventOfCode2023.Tests.Day8Tests

open AdventOfCode2023.Solver
open Xunit

type Day8Test() =
    let demoData =
        [|
            "LLR"
            ""
            "AAA = (BBB, BBB)"
            "BBB = (AAA, ZZZ)"
            "ZZZ = (ZZZ, ZZZ)"
        |]

    [<Fact>]
    let ``Day 8 part 1`` () =
        let solution = Day8.solver1 demoData
        Assert.Equal(6, solution)


    [<Fact>]
    let ``Day 8 part 2`` () =
        let solution = Day8.solver2 demoData
        Assert.Equal("", solution)
