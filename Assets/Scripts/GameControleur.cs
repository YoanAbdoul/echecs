using UnityEngine;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;

public class GameControleur : MonoBehaviour
{
    private bool estTourBlanc;
    private IPiece pieceSelectionnee;
    private List<GameObject> piecesObjets;
    private List<IPiece> pieces;
    public Sprite[] spritesPieces;


    void Start ()
    {
        this.estTourBlanc = true;
        this.pieceSelectionnee = null;
        this.piecesObjets = new List<GameObject>();
        this.pieces = new List<IPiece>();
        this.InitialiserLesPieces();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Vérifie si le bouton gauche de la souris est enfoncé
        {
            Coordonnees coordonnees = this.GetCoordonneesClick();

            // Si une pièce est déjà sélectionnée
            if(this.pieceSelectionnee != null)
            {
                if(this.pieceSelectionnee.PositionsPossibles(this.pieces).Contains(coordonnees))
                {
                    this.pieceSelectionnee.SetCoordonnees(coordonnees);
                    this.pieceSelectionnee = null;
                    this.estTourBlanc = !this.estTourBlanc;
                }
            }
            else
            {
                // On regarde quel pièce est à cette endorit 
                bool pieceTrouve = false;
                int i = 0;
                while(!pieceTrouve && i < this.pieces.Count)
                {
                    IPiece piece = this.pieces[i];
                    if(piece.GetCoordonnees().Equals(coordonnees)
                    && piece.EstBlanc() == this.estTourBlanc)
                    {
                        this.pieceSelectionnee = piece;
                        pieceTrouve = true;
                    }
                    i++;
                }
            }
        }
    }

    private Coordonnees GetCoordonneesClick()
    {
        // Convertir les coordonnées de la souris en coordonnées du monde
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.nearClipPlane; // Distance par rapport à la caméra (z = 0 au niveau du plan de la caméra)

            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

            int x = (int)Math.Round(worldPos.x * 0.75)+3;
            int y = (int)Math.Round(worldPos.y * 0.75)+3;

            return new Coordonnees(x,y);
    }

    private void InitialiserLesPieces()
    {
        // affecter à toutes les pièces des coordonnées

        // Création des pions 
        for(int j = 0; j < 2; j++)
        {
            for(int i = 0; i < 8; i++)
            {
                GameObject nouvellePiece = new GameObject("Pion"+(j==0?"Blanc":"Noir")+i);
                Pion pion = nouvellePiece.AddComponent<Pion>();
                Coordonnees coordonnees = new Coordonnees(i,j==0?1:6);
                pion.SetCoordonnees(coordonnees);
                pion.SetEstBlanc(j==0);
                SpriteRenderer spriteRenderer = nouvellePiece.AddComponent<SpriteRenderer>();
                spriteRenderer.sprite = spritesPieces[j==0?5:11];
                this.pieces.Add(pion);
                this.piecesObjets.Add(nouvellePiece);
            }
        }

        

        // Création du reste
        for(int j = 0; j < 2; j++)
        {
            GameObject nouvellePiece;
            Coordonnees coordonnees;
            SpriteRenderer spriteRenderer;

            // Création des tours
            for(int i = 0; i < 2; i++)
            {
                nouvellePiece = new GameObject("Tour"+(j==0?"Blanc":"Noir")+i);
                Tour tour = nouvellePiece.AddComponent<Tour>();
                coordonnees = new Coordonnees(i==0?0:7,j==0?0:7);
                tour.SetCoordonnees(coordonnees);
                tour.SetEstBlanc(j==0);
                spriteRenderer = nouvellePiece.AddComponent<SpriteRenderer>();
                spriteRenderer.sprite = spritesPieces[j==0?4:10];
                this.pieces.Add(tour);
                this.piecesObjets.Add(nouvellePiece);
            }
            // Création des cavaliers
            for(int i = 0; i < 2; i++)
            {
                nouvellePiece = new GameObject("Cavalier"+(j==0?"Blanc":"Noir")+i);
                Cavalier cavalier = nouvellePiece.AddComponent<Cavalier>();
                coordonnees = new Coordonnees(i==0?1:6,j==0?0:7);
                cavalier.SetCoordonnees(coordonnees);
                cavalier.SetEstBlanc(j==0);
                spriteRenderer = nouvellePiece.AddComponent<SpriteRenderer>();
                spriteRenderer.sprite = spritesPieces[j==0?3:9];
                this.pieces.Add(cavalier);
                this.piecesObjets.Add(nouvellePiece);
            }
            // Création des fous
            for(int i = 0; i < 2; i++)
            {
                nouvellePiece = new GameObject("Fou"+(j==0?"Blanc":"Noir")+i);
                Fou fou = nouvellePiece.AddComponent<Fou>();
                coordonnees = new Coordonnees(i==0?2:5,j==0?0:7);
                fou.SetCoordonnees(coordonnees);
                fou.SetEstBlanc(j==0);
                spriteRenderer = nouvellePiece.AddComponent<SpriteRenderer>();
                spriteRenderer.sprite = spritesPieces[j==0?2:8];
                this.pieces.Add(fou);
                this.piecesObjets.Add(nouvellePiece);
            }
            // Création de la dame
            nouvellePiece = new GameObject("Dame"+(j==0?"Blanc":"Noir"));
            Dame dame = nouvellePiece.AddComponent<Dame>();
            coordonnees = new Coordonnees(3,j==0?0:7);
            dame.SetCoordonnees(coordonnees);
            dame.SetEstBlanc(j==0);
            spriteRenderer = nouvellePiece.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = spritesPieces[j==0?1:7];
            this.pieces.Add(dame);
            this.piecesObjets.Add(nouvellePiece);
            // Création du roi
            nouvellePiece = new GameObject("Roi"+(j==0?"Blanc":"Noir"));
            Roi roi = nouvellePiece.AddComponent<Roi>();
            coordonnees = new Coordonnees(4,j==0?0:7);
            roi.SetCoordonnees(coordonnees);
            roi.SetEstBlanc(j==0);
            spriteRenderer = nouvellePiece.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = spritesPieces[j==0?0:6];
            this.pieces.Add(roi);
            this.piecesObjets.Add(nouvellePiece);
        }
    }
}
 