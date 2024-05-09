using System.Collections.Generic;
using UnityEngine;

public class Roi : PieceAbstract
{
    public override int[,] GetVecteursPossibles()
    {
        int[,] vecteursPossibles = {
            {1, 1},
            {-1, 1},
            {1, -1},
            {-1, -1},
            {0, 1},
            {0, -1},
            {1, 0},
            {-1, 0},
        };
        return vecteursPossibles;
    }

    public override int Distance()
    {
        return 1;
    }
}