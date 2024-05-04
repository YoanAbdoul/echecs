using System.Collections.Generic;
using UnityEngine;

public class Tour : PieceAbstract
{
    public override List<Coordonnees> PositionsPossibles(List<IPiece> listePieces)
    {
        List<Coordonnees> positionsPossibles = new List<Coordonnees>();
        int abscisseDeBase = this.GetCoordonnees().GetAbscisse();
        int ordonneeDeBase = this.GetCoordonnees().GetOrdonnee();
        for(int i = 0; i < 7; i++)
        {
            int ordonnee = i;
            Coordonnees coordonnees = new Coordonnees(abscisseDeBase, ordonnee);
            if(!this.GetCoordonnees().Equals(coordonnees))
            {
                positionsPossibles.Add(coordonnees);
            }
        }
        for(int i = 0; i < 7; i++)
        {
            int abscisse = i;
            Coordonnees coordonnees = new Coordonnees(abscisse, ordonneeDeBase);
            if(!this.GetCoordonnees().Equals(coordonnees))
            {
                positionsPossibles.Add(coordonnees);
            }
        }
        return positionsPossibles;
    }
}
