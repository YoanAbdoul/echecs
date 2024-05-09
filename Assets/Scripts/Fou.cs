using System.Collections.Generic;
using UnityEngine;

public class Fou : PieceAbstract
{
    public override int[,] GetVecteursPossibles()
    {
        int[,] vecteursPossibles = {
            {1, 1},
            {-1, 1},
            {1, -1},
            {-1, -1},
        };
        return vecteursPossibles;
    }

    public override int Distance()
    {
        return 7;
    }
}
