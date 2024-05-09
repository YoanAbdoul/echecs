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
            if(this.GetCoordonnees().GetOrdonnee() == 1
            && !this.PositionPrise(new Coordonnees(abscisseDeBase, ordonneeDeBase+2), listePieces))
            {
                positionsPossibles.Add(new Coordonnees(abscisseDeBase, ordonneeDeBase+1));
                positionsPossibles.Add(new Coordonnees(abscisseDeBase, ordonneeDeBase+2));
            }
            else if(!this.PositionPrise(new Coordonnees(abscisseDeBase, ordonneeDeBase+1), listePieces))
            {
                positionsPossibles.Add(new Coordonnees(abscisseDeBase, ordonneeDeBase+1));
            }
        }
        else
        {
            if(this.GetCoordonnees().GetOrdonnee() == 6
            && !this.PositionPrise(new Coordonnees(abscisseDeBase, ordonneeDeBase-2), listePieces))
            {
                positionsPossibles.Add(new Coordonnees(abscisseDeBase, ordonneeDeBase-1));
                positionsPossibles.Add(new Coordonnees(abscisseDeBase, ordonneeDeBase-2));
            }
            else if(!this.PositionPrise(new Coordonnees(abscisseDeBase, ordonneeDeBase-1), listePieces))
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

    public override int[,] GetVecteursPossibles()
    {
        // On n'utilise jamais cette méthode pour la classe Pion
        Debug.LogError("La fonction GetVecteursPossibles() de la classe Pion ne devrait pas être utilisé");
        int[,] vecteursPossibles = new int[0,0];
        return vecteursPossibles;
    }

    public override int Distance()
    {
        // On n'utilise jamais cette méthode pour la classe Pion
        Debug.LogError("La fonction Distance() de la classe Pion ne devrait pas être utilisé");
        return 0;
    }
}
