using System.Collections.Generic;
using UnityEngine;

public class Roi : PieceAbstract
{
    public override List<Coordonnees> PositionsPossibles(List<IPiece> listePieces)
    {
        List<Coordonnees> positionsPossibles = new List<Coordonnees>();
        for(int i = -1; i < 2; i++)
        {
            for(int j = -1; j < 2; j++)
            {
                int abscisse = this.GetCoordonnees().GetAbscisse() + i;
                int ordonnee = this.GetCoordonnees().GetOrdonnee() + j;
                Coordonnees coordonnees = new Coordonnees(abscisse, ordonnee);
                if(!this.GetCoordonnees().Equals(coordonnees) 
                && abscisse >= 0 && ordonnee <= 7
                && abscisse >= 0 && ordonnee <= 7
                && !this.PositionPriseAllie(coordonnees, listePieces))
                {
                    positionsPossibles.Add(coordonnees);
                }
            }
        }
        return positionsPossibles;
    }
}