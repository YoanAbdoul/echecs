using System.Collections.Generic;
using UnityEngine;

public class Cavalier : PieceAbstract
{
    public override int[,] GetVecteursPossibles()
    {
        int[,] vecteursPossibles = {
            {1,2},
            {2,1},
            {-1,2},
            {-2,1},
            {-1,-2},
            {-2,-1},
            {1,-2},
            {2,-1},
        };
        return vecteursPossibles;
    }

    public override int Distance()
    {
        return 1;
    }
}
