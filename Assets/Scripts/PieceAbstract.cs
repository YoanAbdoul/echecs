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
    public abstract List<Coordonnees> PositionsPossibles(List<IPiece> listePieces);
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
