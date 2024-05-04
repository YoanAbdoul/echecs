using System.Collections.Generic;
using UnityEngine;

public class Fou : PieceAbstract
{
    public override List<Coordonnees> PositionsPossibles(List<IPiece> listePieces)
    {
        List<Coordonnees> positionsPossibles = new List<Coordonnees>();
        int abscisseDeBase = this.GetCoordonnees().GetAbscisse();
        int ordonneeDeBase = this.GetCoordonnees().GetOrdonnee();
        for(int i = -7; i < 8; i++)
        {
            Coordonnees endroitPossible1 = new Coordonnees(abscisseDeBase + i, ordonneeDeBase + i);
            Coordonnees endroitPossible2 = new Coordonnees(abscisseDeBase - i, ordonneeDeBase + i);
            Coordonnees endroitPossible3 = new Coordonnees(abscisseDeBase + i, ordonneeDeBase - i);
            Coordonnees endroitPossible4 = new Coordonnees(abscisseDeBase - i, ordonneeDeBase - i);
            if(!this.GetCoordonnees().Equals(endroitPossible1) 
            && endroitPossible1.GetAbscisse() >= 0 && endroitPossible1.GetAbscisse() <= 7
            && endroitPossible1.GetOrdonnee() >= 0 && endroitPossible1.GetOrdonnee() <= 7)
            {
                positionsPossibles.Add(endroitPossible1);
            }
            if(!this.GetCoordonnees().Equals(endroitPossible2) 
            && endroitPossible2.GetAbscisse() >= 0 && endroitPossible2.GetAbscisse() <= 7
            && endroitPossible2.GetOrdonnee() >= 0 && endroitPossible2.GetOrdonnee() <= 7)
            {
                positionsPossibles.Add(endroitPossible2);
            }
            if(!this.GetCoordonnees().Equals(endroitPossible3) 
            && endroitPossible3.GetAbscisse() >= 0 && endroitPossible3.GetAbscisse() <= 7
            && endroitPossible3.GetOrdonnee() >= 0 && endroitPossible3.GetOrdonnee() <= 7)
            {
                positionsPossibles.Add(endroitPossible3);
            }
            if(!this.GetCoordonnees().Equals(endroitPossible4) 
            && endroitPossible4.GetAbscisse() >= 0 && endroitPossible4.GetAbscisse() <= 7
            && endroitPossible4.GetOrdonnee() >= 0 && endroitPossible4.GetOrdonnee() <= 7)
            {
                positionsPossibles.Add(endroitPossible4);
            }
        }
        return positionsPossibles;
    }
}
