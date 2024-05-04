using UnityEngine;

public class Coordonnees
{
    private int abscisse;
    private int ordonnee;

    public Coordonnees()
    {
        this.abscisse = 0;
        this.ordonnee = 0;
    }

    public Coordonnees(int abscisse, int ordonnee)
    {
        this.abscisse= abscisse;
        this.ordonnee= ordonnee;
    }

    public int GetAbscisse()
    {
        return abscisse;
    }

    public int GetOrdonnee()
    {
        return ordonnee;
    }

    public void DeplacerDe(int deltaX, int deltaY)
    {
        this.abscisse += deltaX;
        this.ordonnee += deltaY;
    }

    public void DeplacerA(int abscisse, int ordonnee)
    {
        this.abscisse = abscisse;
        this.ordonnee = ordonnee;
    }

    public override string ToString()
    {
        return "("+this.abscisse + "," + this.ordonnee+")";
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        Coordonnees other = (Coordonnees) obj;
        return this.abscisse == other.GetAbscisse() && this.ordonnee == other.GetOrdonnee();
    }
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
