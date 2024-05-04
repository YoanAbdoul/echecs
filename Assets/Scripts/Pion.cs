using System.Collections.Generic;
using UnityEngine;

public class Pion : PieceAbstract
{
    public override List<Coordonnees> PositionsPossibles(List<IPiece> listePieces)
    {
        List<Coordonnees> positionsPossibles = new List<Coordonnees>();
        // deplacements normals
        int abscisseDeBase = this.GetCoordonnees().GetAbscisse();
        int ordonneeDeBase = this.GetCoordonnees().GetOrdonnee();
        if(this.estBlanc)
        {
            if(this.GetCoordonnees().GetOrdonnee() == 1)
            {
                positionsPossibles.Add(new Coordonnees(abscisseDeBase, 2));
                positionsPossibles.Add(new Coordonnees(abscisseDeBase, 3));
            }
            else
            {
                positionsPossibles.Add(new Coordonnees(abscisseDeBase, ordonneeDeBase+1));
            }
        }
        else
        {
            if(this.GetCoordonnees().GetOrdonnee() == 6)
            {
                positionsPossibles.Add(new Coordonnees(abscisseDeBase, 5));
                positionsPossibles.Add(new Coordonnees(abscisseDeBase, 4));
            }
            else
            {
                positionsPossibles.Add(new Coordonnees(abscisseDeBase, ordonneeDeBase-1));
            }
        }
        // déplacements spécials des attaques
        if(this.EstBlanc())
        {
            Coordonnees endroitPoosible1 = new Coordonnees(abscisseDeBase+1,ordonneeDeBase+1);
            Coordonnees endroitPoosible2 = new Coordonnees(abscisseDeBase-1,ordonneeDeBase+1);
            for(int i = 0; i < listePieces.Count; i++)
            {
                if(!listePieces[i].EstBlanc())
                {
                    if(listePieces[i].GetCoordonnees().Equals(endroitPoosible1))
                    {
                        positionsPossibles.Add(endroitPoosible1);
                    }
                    else if(listePieces[i].GetCoordonnees().Equals(endroitPoosible2))
                    {
                        positionsPossibles.Add(endroitPoosible2);
                    }
                }
            }
        }
        else
        {
            Coordonnees endroitPoosible1 = new Coordonnees(abscisseDeBase+1,ordonneeDeBase-1);
            Coordonnees endroitPoosible2 = new Coordonnees(abscisseDeBase-1,ordonneeDeBase-1);
            for(int i = 0; i < listePieces.Count; i++)
            {
                if(listePieces[i].EstBlanc())
                {
                    if(listePieces[i].GetCoordonnees().Equals(endroitPoosible1))
                    {
                        positionsPossibles.Add(endroitPoosible1);
                    }
                    else if(listePieces[i].GetCoordonnees().Equals(endroitPoosible2))
                    {
                        positionsPossibles.Add(endroitPoosible2);
                    }
                }
            }
        }
        return positionsPossibles;
    }
}
