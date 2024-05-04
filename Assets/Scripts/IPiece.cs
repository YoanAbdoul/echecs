using System.Collections.Generic;

public interface IPiece
{
    public void SetCoordonnees(Coordonnees coordonnees);
    public void SetEstBlanc(bool estBlanc);
    public List<Coordonnees> PositionsPossibles(List<IPiece> listePieces);
    public Coordonnees GetCoordonnees();
    public bool EstBlanc();
    public bool Equals(object obj);
}

