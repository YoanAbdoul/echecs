using System.Collections.Generic;
using UnityEngine;

public class Cavalier : PieceAbstract
{
    public override List<Coordonnees> PositionsPossibles(List<IPiece> listePieces)
    {
        List<Coordonnees> positionsPossibles = new List<Coordonnees>();
        int[,] tableauPossibilites = {
            {1,2},
            {2,1},
            {-1,2},
            {-2,1},
            {-1,-2},
            {-2,-1},
            {1,-2},
            {2,-1},
        };
        int abscisseDeBase = this.GetCoordonnees().GetAbscisse();
        int ordonneeDeBase = this.GetCoordonnees().GetOrdonnee();
        for(int i = 0; i < 8; i++)
        {
            int abscisse = abscisseDeBase+tableauPossibilites[i,0];
            int ordonnee = ordonneeDeBase+tableauPossibilites[i,1];
            Coordonnees endroitPossible = new Coordonnees(abscisse, ordonnee);
            if(!this.GetCoordonnees().Equals(endroitPossible) 
            && abscisse >= 0 && abscisse <= 7
            && ordonnee >= 0 && ordonnee <= 7
            && !this.PositionPriseAllie(endroitPossible, listePieces))
            {
                positionsPossibles.Add(endroitPossible);
            }

        }
        return positionsPossibles;
    }
}
