using System.Collections.Generic;
using UnityEngine;

public abstract class PieceAbstract : MonoBehaviour, IPiece
{
    private Coordonnees coordonnees = new Coordonnees(0,0);
    public bool estBlanc = true;

    public void SetCoordonnees(Coordonnees coordonnees)
    {
        this.coordonnees = coordonnees;
        float x = (coordonnees.GetAbscisse()-3)/0.75f;
        float y = (coordonnees.GetOrdonnee()-3)/0.75f;
        this.transform.position = new Vector3(x,y,0f);
        this.transform.rotation = Quaternion.identity;
    }

    public void SetEstBlanc(bool estBlanc)
    {
        this.estBlanc = estBlanc;
    }

    public virtual List<Coordonnees> PositionsPossibles(List<IPiece> listePieces)
    {
        List<Coordonnees> positionsPossibles = new List<Coordonnees>();
        int abscisseDeBase = this.GetCoordonnees().GetAbscisse();
        int ordonneeDeBase = this.GetCoordonnees().GetOrdonnee();
        int[,] vecteursPossibles = this.GetVecteursPossibles();
        for(int j = 0; j < vecteursPossibles.GetLength(0); j++)
        {
            for(int i = 1; i < this.Distance()+1; i++)
            {
                Coordonnees endroitPossible = new Coordonnees(abscisseDeBase + (vecteursPossibles[j,0]*i), ordonneeDeBase + (vecteursPossibles[j,1]*i));
                if(endroitPossible.GetAbscisse() >= 0 && endroitPossible.GetAbscisse() <= 7
                && endroitPossible.GetOrdonnee() >= 0 && endroitPossible.GetOrdonnee() <= 7
                && !this.PositionPriseAllie(endroitPossible, listePieces))
                {
                    positionsPossibles.Add(endroitPossible);
                }
            }
        }
        return positionsPossibles;
    }

    public abstract int[,] GetVecteursPossibles();
    public abstract int Distance();

    public Coordonnees GetCoordonnees()
    {
        return this.coordonnees; 
    }
    
    public bool EstBlanc()
    {
        return this.estBlanc;
    }

    public bool PositionPriseAllie(Coordonnees coordonneesFutures, List<IPiece> listePieces)
    {
        bool result = false;
        int i = 0;
        while(!result && i < listePieces.Count)
        {
            if(this.EstBlanc() == listePieces[i].EstBlanc()
            && coordonneesFutures.Equals(listePieces[i].GetCoordonnees()))
            {
                result = true;
            }
            i++;
        }
        return result;
    }

    public bool PositionPrise(Coordonnees coordonneesFutures, List<IPiece> listePieces)
    {
        bool result = false;
        int i = 0;
        while(!result && i < listePieces.Count)
        {
            if(coordonneesFutures.Equals(listePieces[i].GetCoordonnees()))
            {
                result = true;
            }
            i++;
        }
        return result;
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        IPiece other = (IPiece) obj;
        return this.coordonnees.Equals(other.GetCoordonnees()) && (this.estBlanc == other.EstBlanc());
    }
    public override int GetHashCode()
    {
        return base.GetHashCode() ^ coordonnees.GetHashCode();
    }
}
