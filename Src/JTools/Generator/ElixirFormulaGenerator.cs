using System.Collections.Generic;
using TierneyJohn.MiChangSheng.JTools.Model.Entity;

namespace TierneyJohn.MiChangSheng.JTools.Generator;

/// <summary>丹方数据生成器</summary>
public static class ElixirFormulaGenerator
{
    public static ElixirFormulaEntity Generator(
        int id,
        string name,
        (int, int) mainDrugA,
        (int, int) mainDrugB,
        (int, int) adjuvantA,
        (int, int) adjuvantB,
        (int, int) drugPrimer,
        int time = 1,
        int elixirId = 0
    )
    {
        if (elixirId == 0) elixirId = id - 1000;

        return new ElixirFormulaEntity
        {
            Id = id,
            ElixirId = elixirId,
            Name = name,
            Time = time,
            MainDrugA = mainDrugA,
            MainDrugB = mainDrugB,
            AdjuvantA = adjuvantA,
            AdjuvantB = adjuvantB,
            DrugPrimer = drugPrimer
        };
    }

    public static ElixirFormulaEntity Generator(
        int id,
        string name,
        List<(int, int)> formulas,
        int time = 1,
        int elixirId = 0
    )
    {
        return Generator(id, name, formulas[0], formulas[1], formulas[2], formulas[3], formulas[4], time, elixirId);
    }
}