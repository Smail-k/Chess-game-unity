using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class chessman : MonoBehaviour
{   
    public struct pos
    {
       public  int x;
       public  int y;  
    };   
    //prise en passant :
    private static int xprisepass=-1;
    private static int yprisepass=-1;



    // le rook: 
    private static bool grandrookb=true;
    private static bool grandrookn=true;
    private static bool petitrookb=true;
    private static bool petitrookn=true;

    public GameObject controller;
    public GameObject movement;
    // Start is called before the first frame update
    private int xboard = -1;
    private int yboard = -1;
    private int tj;
    public GameObject carre;
    private GameObject carresupp; 
    public Sprite reine_noire, cavalier_noir, fou_noir, tour_noire, roi_noir, pion_noir;
    public Sprite reine_blanche, cavalier_blanc, fou_blanc, tour_blanche, roi_blanc, pion_blanc;

    void update()
    {
    }
    public void activer()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");
        setcoords(); // pour ce placer dans le carreau convenable de la piece avant de la creer; 
        switch (this.name)
        {
            case "reine_noire": this.GetComponent<SpriteRenderer>().sprite = reine_noire; tj = 2; break;
            case "cavalier_noir": this.GetComponent<SpriteRenderer>().sprite = cavalier_noir; tj = 2; break;
            case "fou_noir": this.GetComponent<SpriteRenderer>().sprite = fou_noir; tj = 2; break;
            case "tour_noire": this.GetComponent<SpriteRenderer>().sprite = tour_noire; tj = 2; break;
            case "roi_noir": this.GetComponent<SpriteRenderer>().sprite = roi_noir; tj = 2; break;
            case "pion_noir": this.GetComponent<SpriteRenderer>().sprite = pion_noir; tj = 2; break;

            case "reine_blanche": this.GetComponent<SpriteRenderer>().sprite = reine_blanche; tj = 1; break;
            case "cavalier_blanc": this.GetComponent<SpriteRenderer>().sprite = cavalier_blanc; tj = 1; break;
            case "fou_blanc": this.GetComponent<SpriteRenderer>().sprite = fou_blanc; tj = 1; break;
            case "tour_blanche": this.GetComponent<SpriteRenderer>().sprite = tour_blanche; tj = 1; break;
            case "roi_blanc": this.GetComponent<SpriteRenderer>().sprite = roi_blanc; tj = 1; break;
            case "pion_blanc": this.GetComponent<SpriteRenderer>().sprite = pion_blanc; tj = 1; break;

        }
        
    }// les cas d'echecs des pieces noires : 
    public int echecnoir(int x,int y,ref int x1,ref int y1)
    {
        controller = GameObject.FindGameObjectWithTag("GameController");
        game a = controller.GetComponent<game>();
        int i, j;
        j = x + 1; i = y;
        while (j<8) // cas de tour ou reine a droite de la piece 
        {
            if (a.getposition(j,i) == null)
                j++;
            else if (a.getposition(j, i).GetComponent<chessman>().tj != tj && (a.getposition(j, i).name == "tour_blanche" ||
                a.getposition(j, i).name == "reine_blanche"))
                    {
                        x1 = j; y1 = i; 
                        return 1;
                    }
                
            else
                j = 8; 
        }
        j = x - 1; i = y;  // cas de tour ou reine a gauche de la piece
        while (j >= 0)
        {
            if (a.getposition(j, i) == null)
                j--;
            else if (a.getposition(j, i).GetComponent<chessman>().tj != tj && (a.getposition(j, i).name == "tour_blanche" ||
                a.getposition(j, i).name == "reine_blanche"))
            {
                x1 = j; y1 = i;
                return 1;
            }
            else
                j = -1;
        }
        j = x; i = y+1;  // cas de tour ou reine en haut de la piece
        while (i < 8)
        {
            if (a.getposition(j, i) == null)
                i++;
            else if (a.getposition(j, i).GetComponent<chessman>().tj != tj && (a.getposition(j, i).name == "tour_blanche" ||
                a.getposition(j, i).name == "reine_blanche"))
            {
                x1 = j; y1 = i;
                return 1;
            }
            else
                i=8;
        }
        i = y - 1; // cas de tour ou reine en bas de la piece
        while (i >=0)
        {
            if (a.getposition(j, i) == null)
                i--;
            else if (a.getposition(j, i).GetComponent<chessman>().tj != tj && (a.getposition(j, i).name == "tour_blanche" ||
                a.getposition(j, i).name == "reine_blanche"))
            {
                x1 = j; y1 = i;
                return 1;
            }
            else
                i = -1;
        }
        i = y + 1; j = x + 1;
        while (i <8 && j<8) // cas de fou au diagonale haut a droite
        {
            if (a.getposition(j, i) == null)
            {
                i++; j++; 
            }
            else if (a.getposition(j, i).GetComponent<chessman>().tj != tj && (a.getposition(j, i).name == "fou_blanc" ||
                a.getposition(j, i).name == "reine_blanche"))
            {
                x1 = j; y1 = i;
                return 1;
            }
            else
                i = 8;
        }
        i = y + 1; j = x - 1; 
        while (i < 8 && j >=0) // cas de fou au diagonale haut a gauche
        {
            if (a.getposition(j, i) == null)
            {
                i++; j--;
            }
            else if (a.getposition(j, i).GetComponent<chessman>().tj != tj && (a.getposition(j, i).name == "fou_blanc" ||
                a.getposition(j, i).name == "reine_blanche"))
            {
                x1 = j; y1 = i;
                return 1;
            }
            else
                i = 8;
        }
        i = y - 1; j = x - 1; 
        while (i >=0 && j >=0) // cas de fou au diagonale bas a gauche
        {
            if (a.getposition(j, i) == null)
            {
                i--; j--; 
            }
            else if (a.getposition(j, i).GetComponent<chessman>().tj != tj && (a.getposition(j, i).name == "fou_blanc" ||
                a.getposition(j, i).name == "reine_blanche"))
            {
                x1 = j; y1 = i;
                return 1;
            }
            else
                i = -1;
        }
        i = y - 1; j = x + 1;
        while (i >= 0 && j <8) // cas de fou au diagonale bas a gauche
        {
            if (a.getposition(j, i) == null)
            {
                i--; j++;
            }
            else if (a.getposition(j, i).GetComponent<chessman>().tj != tj && (a.getposition(j, i).name == "fou_blanc" ||
                a.getposition(j, i).name == "reine_blanche"))
            {
                x1 = j; y1 = i;
                return 1;
            }
            else
                i = -1;
        }
        i = y + 2; j = x + 1; 
        if(a.PositionDansPlateau(j,i)==true && a.getposition(j, i) != null && a.getposition(j, i).name=="cavalier_blanc")
        {
            x1 = j; y1 = i;
            return 1;
        }
        i = y + 2; j = x - 1;
        if (a.PositionDansPlateau(j, i) == true && a.getposition(j, i) != null && a.getposition(j, i).name == "cavalier_blanc")
        {
            x1 = j; y1 = i;
            return 1;
        }
        i = y - 2; j = x + 1;
        if (a.PositionDansPlateau(j, i) == true && a.getposition(j, i) != null && a.getposition(j, i).name == "cavalier_blanc")
        {
            x1 = j; y1 = i;
            return 1;
        }
        i = y - 2; j = x - 1;
        if (a.PositionDansPlateau(j, i) == true && a.getposition(j, i) != null && a.getposition(j, i).name == "cavalier_blanc")
        {
            x1 = j; y1 = i;
            return 1;
        }
        i = y + 1; j = x + 2;
        if (a.PositionDansPlateau(j, i) == true && a.getposition(j, i) != null && a.getposition(j, i).name == "cavalier_blanc")
        {
            x1 = j; y1 = i;
            return 1;
        }
        i = y + 1; j = x - 2;
        if (a.PositionDansPlateau(j, i) == true && a.getposition(j, i) != null && a.getposition(j, i).name == "cavalier_blanc")
        {
            x1 = j; y1 = i;
            return 1;
        }
        i = y - 1; j = x + 2;
        if (a.PositionDansPlateau(j, i) == true && a.getposition(j, i) != null && a.getposition(j, i).name == "cavalier_blanc")
        {
            x1 = j; y1 = i;
            return 1;
        }
        i = y - 1; j = x - 2;
        if (a.PositionDansPlateau(j, i) == true && a.getposition(j, i) != null && a.getposition(j, i).name == "cavalier_blanc")
        {
            x1 = j; y1 = i;
            return 1;
        }
        //cas de roi et aussi le pion
        i = y + 1; j = x;
        if (a.PositionDansPlateau(j, i) == true && a.getposition(j, i) != null && a.getposition(j, i).name == "roi_blanc")
        {
            x1 = j; y1 = i;
            return 1;
        }
        j = x + 1;
        if (a.PositionDansPlateau(j, i) == true && a.getposition(j, i) != null && (a.getposition(j, i).name == "roi_blanc" || a.getposition(j, i).name == "pion_blanc"))
        {
            x1 = j; y1 = i;
            return 1;
        }
        j = x - 1;
        if (a.PositionDansPlateau(j, i) == true && a.getposition(j, i) != null && (a.getposition(j, i).name == "roi_blanc" || a.getposition(j, i).name == "pion_blanc"))
        {
            x1 = j; y1 = i;
            return 1;
        }
        i = y - 1; j = x;
        if (a.PositionDansPlateau(j, i) == true && a.getposition(j, i) != null && a.getposition(j, i).name == "roi_blanc")
        {
            x1 = j; y1 = i;
            return 1;
        }
        j = x + 1;
        if (a.PositionDansPlateau(j, i) == true && a.getposition(j, i) != null && (a.getposition(j, i).name == "roi_blanc" || a.getposition(j, i).name == "pion_blanc"))
        {
            x1 = j; y1 = i;
            return 1;
        }
        j = x - 1;
        if (a.PositionDansPlateau(j, i) == true && a.getposition(j, i) != null && (a.getposition(j, i).name == "roi_blanc" || a.getposition(j, i).name == "pion_blanc"))
        {
            x1 = j; y1 = i;
            return 1;
        }
        i = y;
        if (a.PositionDansPlateau(j, i) == true && a.getposition(j, i) != null && a.getposition(j, i).name == "roi_blanc")
        {
            x1 = j; y1 = i;
            return 1;
        }
        j = x + 1;
        if (a.PositionDansPlateau(j, i) == true && a.getposition(j, i) != null && a.getposition(j, i).name == "roi_blanc")
        {
            x1 = j; y1 = i;
            return 1;
        }


        return 0;
    } 
// les cas d'echecs des pieces blanches 
    public int echecblanc(int x, int y,ref int x1,ref int y1)
    {
        controller = GameObject.FindGameObjectWithTag("GameController");
        game a = controller.GetComponent<game>();
        int i, j;
        j = x + 1; i = y;
        while (j < 8) // cas de tour ou reine a droite de la piece 
        {
            if (a.getposition(j, i) == null)
                j++;
            else if (a.getposition(j, i).GetComponent<chessman>().tj != tj && (a.getposition(j, i).name == "tour_noire" ||
                a.getposition(j, i).name == "reine_noire"))
                 {
                     x1 = j; y1 = i;
                         return 1;
                 }
            else
                j = 8;
        }
        j = x - 1; i = y;  // cas de tour ou reine a gauche de la piece
        while (j >= 0)
        {
            if (a.getposition(j, i) == null)
                j--;
            else if (a.getposition(j, i).GetComponent<chessman>().tj != tj && (a.getposition(j, i).name == "tour_noire" ||
                a.getposition(j, i).name == "reine_noire"))
            {
                x1 = j; y1 = i;
                return 1;
            }
            else
                j = -1;
        }
        j = x; i = y + 1;  // cas de tour ou reine en haut de la piece
        while (i < 8)
        {
            if (a.getposition(j, i) == null)
                i++;
            else if (a.getposition(j, i).GetComponent<chessman>().tj != tj && (a.getposition(j, i).name == "tour_noire" ||
                a.getposition(j, i).name == "reine_noire"))
            {
                x1 = j; y1 = i;
                return 1;
            }
            else
                i = 8;
        }
        i = y - 1; // cas de tour ou reine en bas de la piece
        while (i >= 0)
        {
            if (a.getposition(j, i) == null)
                i--;
            else if (a.getposition(j, i).GetComponent<chessman>().tj != tj && (a.getposition(j, i).name == "tour_noire" ||
                a.getposition(j, i).name == "reine_noire"))
            {
                x1 = j; y1 = i;
                return 1;
            }
            else
                i = -1;
        }
        i = y + 1; j = x + 1;
        while (i < 8 && j < 8) // cas de fou au diagonale haut a droite
        {
            if (a.getposition(j, i) == null)
            {
                i++; j++;
            }
            else if (a.getposition(j, i).GetComponent<chessman>().tj != tj && (a.getposition(j, i).name == "fou_noir" ||
                a.getposition(j, i).name == "reine_noire"))
            {
                x1 = j; y1 = i;
                return 1;
            }
            else
                i = 8;
        }
        i = y + 1; j = x - 1;
        while (i < 8 && j >= 0) // cas de fou au diagonale haut a gauche
        {
            if (a.getposition(j, i) == null)
            {
                i++; j--;
            }
            else if (a.getposition(j, i).GetComponent<chessman>().tj != tj && (a.getposition(j, i).name == "fou_noir" ||
                a.getposition(j, i).name == "reine_noire"))
            {
                x1 = j; y1 = i;
                return 1;
            }
            else
                i = 8;
        }
        i = y - 1; j = x - 1;
        while (i >= 0 && j >= 0) // cas de fou au diagonale bas a gauche
        {
            if (a.getposition(j, i) == null)
            {
                i--; j--;
            }
            else if (a.getposition(j, i).GetComponent<chessman>().tj != tj && (a.getposition(j, i).name == "fou_noir" ||
                a.getposition(j, i).name == "reine_noire"))
            {
                x1 = j; y1 = i;
                return 1;
            }
            else
                i = -1;
        }
        i = y - 1; j = x + 1;
        while (i >= 0 && j < 8) // cas de fou au diagonale bas a gauche
        {
            if (a.getposition(j, i) == null)
            {
                i--; j++;
            }
            else if (a.getposition(j, i).GetComponent<chessman>().tj != tj && (a.getposition(j, i).name == "fou_noir" ||
                a.getposition(j, i).name == "reine_noire"))
            {
                x1 = j; y1 = i;
                return 1;
            }
            else
                i = -1;
        }
        i = y + 2; j = x + 1;
        if (a.PositionDansPlateau(j, i) == true && a.getposition(j, i) != null && a.getposition(j, i).name == "cavalier_noir")
        {
            x1 = j; y1 = i;
            return 1;
        }
        i = y + 2; j = x - 1;
        if (a.PositionDansPlateau(j, i) == true && a.getposition(j, i) != null && a.getposition(j, i).name == "cavalier_noir")
        {
            x1 = j; y1 = i;
            return 1;
        }
        i = y - 2; j = x + 1;
        if (a.PositionDansPlateau(j, i) == true && a.getposition(j, i) != null && a.getposition(j, i).name == "cavalier_noir")
        {
            x1 = j; y1 = i;
            return 1;
        }
        i = y - 2; j = x - 1;
        if (a.PositionDansPlateau(j, i) == true && a.getposition(j, i) != null && a.getposition(j, i).name == "cavalier_noir")
        {
            x1 = j; y1 = i;
            return 1;
        }
        i = y + 1; j = x + 2;
        if (a.PositionDansPlateau(j, i) == true && a.getposition(j, i) != null && a.getposition(j, i).name == "cavalier_noir")
        {
            x1 = j; y1 = i;
            return 1;
        }
        i = y + 1; j = x - 2;
        if (a.PositionDansPlateau(j, i) == true && a.getposition(j, i) != null && a.getposition(j, i).name == "cavalier_noir")
        {
            x1 = j; y1 = i;
            return 1;
        }
        i = y - 1; j = x + 2;
        if (a.PositionDansPlateau(j, i) == true && a.getposition(j, i) != null && a.getposition(j, i).name == "cavalier_noir")
        {
            x1 = j; y1 = i;
            return 1;
        }
        i = y - 1; j = x - 2;
        if (a.PositionDansPlateau(j, i) == true && a.getposition(j, i) != null && a.getposition(j, i).name == "cavalier_noir")
        {
            x1 = j; y1 = i;
            return 1;
        }
        //cas de roi et aussi le pion
        i = y + 1; j = x;
        if (a.PositionDansPlateau(j, i) == true && a.getposition(j, i) != null && a.getposition(j, i).name == "roi_noir")
        {
            x1 = j; y1 = i;
            return 1;
        }
        j = x + 1;
        if (a.PositionDansPlateau(j, i) == true && a.getposition(j, i) != null && (a.getposition(j, i).name == "roi_noir" || a.getposition(j, i).name == "pion_noir"))
        {
            x1 = j; y1 = i;
            return 1;
        }
        j = x - 1;
        if (a.PositionDansPlateau(j, i) == true && a.getposition(j, i) != null && (a.getposition(j, i).name == "roi_noir" || a.getposition(j, i).name == "pion_noir"))
        {
            x1 = j; y1 = i;
            return 1;
        }
        i = y - 1; j = x;
        if (a.PositionDansPlateau(j, i) == true && a.getposition(j, i) != null && a.getposition(j, i).name == "roi_noir")
        {
            x1 = j; y1 = i;
            return 1;
        }
        j = x + 1;
        if (a.PositionDansPlateau(j, i) == true && a.getposition(j, i) != null && (a.getposition(j, i).name == "roi_noir" || a.getposition(j, i).name == "pion_noir"))
        {
            x1 = j; y1 = i;
            return 1;
        }
        j = x - 1;
        if (a.PositionDansPlateau(j, i) == true && a.getposition(j, i) != null && (a.getposition(j, i).name == "roi_noir" || a.getposition(j, i).name == "pion_noir"))
        {
            x1 = j; y1 = i;
            return 1;
        }
        i = y;
        if (a.PositionDansPlateau(j, i) == true && a.getposition(j, i) != null && a.getposition(j, i).name == "roi_noir")
        {
            x1 = j; y1 = i;
            return 1;
        }
        j = x + 1;
        if (a.PositionDansPlateau(j, i) == true && a.getposition(j, i) != null && a.getposition(j, i).name == "roi_noir")
        {
            x1 = j; y1 = i;
            return 1;
        }
        return 0;
    }   

    public bool echecmate(int x,int y,bool blanc=true)
    {
        int i, j,x1=-1,y1=-1; 
        if(blanc){ 
            i=x+1; j=y; //i les colonnes j les lignes 
            game a = controller.GetComponent<game>();
            if (a.PositionDansPlateau(i, j) == true && (a.getposition(i, j) == null || (a.getposition(i, j) != null && (a.getposition(i, j).name.EndsWith("noir") || a.getposition(i, j).name.EndsWith("noire")))) && echecblanc(i, j, ref x1, ref y1) == 0 && echecblanc(x, y, ref x1, ref y1) == 0)
                return false;
            i = x - 1;
            if (a.PositionDansPlateau(i, j) == true && (a.getposition(i, j) == null || (a.getposition(i, j) != null && (a.getposition(i, j).name.EndsWith("noir") || a.getposition(i, j).name.EndsWith("noire")))) && echecblanc(i, j, ref x1, ref y1) == 0 && echecblanc(x, y, ref x1, ref y1) == 0)
                return false;
             
            i = x;
            if (a.PositionDansPlateau(i, j) == true && echecblanc(i, j, ref x1, ref y1) == 0)
                return false;
            j = y + 1;
            if (a.PositionDansPlateau(i, j) == true && (a.getposition(i, j) == null || (a.getposition(i, j) != null && (a.getposition(i, j).name.EndsWith("noir") || a.getposition(i, j).name.EndsWith("noire")))) && echecblanc(i, j, ref x1, ref y1) == 0 && echecblanc(x, y, ref x1, ref y1) == 0)
                return false;
            j = y - 1;
            if (a.PositionDansPlateau(i, j) == true && (a.getposition(i, j) == null || (a.getposition(i, j) != null && (a.getposition(i, j).name.EndsWith("noir") || a.getposition(i, j).name.EndsWith("noire")))) && echecblanc(i, j, ref x1, ref y1) == 0 && echecblanc(x, y, ref x1, ref y1) == 0)
                return false;
            i = x - 1;
            if (a.PositionDansPlateau(i, j) == true && (a.getposition(i, j) == null || (a.getposition(i, j) != null && (a.getposition(i, j).name.EndsWith("noir") || a.getposition(i, j).name.EndsWith("noire")))) && echecblanc(i, j, ref x1, ref y1) == 0 && echecblanc(x, y, ref x1, ref y1) == 0)
                return false;
            i = x + 1;
            if (a.PositionDansPlateau(i, j) == true && (a.getposition(i, j) == null || (a.getposition(i, j) != null && (a.getposition(i, j).name.EndsWith("noir") || a.getposition(i, j).name.EndsWith("noire")))) && echecblanc(i, j, ref x1, ref y1) == 0 && echecblanc(x, y, ref x1, ref y1) == 0)
                return false;
            j = y + 1;
            if (a.PositionDansPlateau(i, j) == true && (a.getposition(i, j) == null || (a.getposition(i, j) != null && (a.getposition(i, j).name.EndsWith("noir") || a.getposition(i, j).name.EndsWith("noire")))) && echecblanc(i, j, ref x1, ref y1) == 0 && echecblanc(x, y, ref x1, ref y1) == 0)
                return false;
            i = x - 1;
            if (a.PositionDansPlateau(i, j) == true && (a.getposition(i, j) == null || (a.getposition(i, j) != null && (a.getposition(i, j).name.EndsWith("noir") || a.getposition(i, j).name.EndsWith("noire")))) && echecblanc(i, j, ref x1, ref y1) == 0 && echecblanc(x,y, ref x1, ref y1) == 0)
                return false;
    }
    else
    {
         i = x + 1;  j = y; //i les colonnes j les ligne 
        game a = controller.GetComponent<game>();
        if (a.PositionDansPlateau(i, j) == true && (a.getposition(i, j) == null || (a.getposition(i, j) != null && (a.getposition(i, j).name.EndsWith("blanc") || a.getposition(i, j).name.EndsWith("blanche")))) && echecnoir(i, j, ref x1, ref y1) == 0 && echecnoir(x,y, ref x1, ref y1) == 0)
            return false;
        i = x - 1;
        if (a.PositionDansPlateau(i, j) == true && (a.getposition(i, j) == null || (a.getposition(i, j) != null && (a.getposition(i, j).name.EndsWith("blanc") || a.getposition(i, j).name.EndsWith("blanche")))) && echecnoir(i, j, ref x1, ref y1) == 0 && echecnoir(x, y, ref x1, ref y1) == 0)
            return false;
        i = x;
        if (a.PositionDansPlateau(i, j) == true && echecnoir(i, j, ref x1, ref y1) == 0)
            return false;
        j = y + 1;
        if (a.PositionDansPlateau(i, j) == true && (a.getposition(i, j) == null || (a.getposition(i, j) != null && (a.getposition(i, j).name.EndsWith("blanc") || a.getposition(i, j).name.EndsWith("blanche")))) && echecnoir(i, j, ref x1, ref y1) == 0 && echecnoir(x, y, ref x1, ref y1) == 0)
            return false;
        j = y - 1;
        if (a.PositionDansPlateau(i, j) == true && (a.getposition(i, j) == null || (a.getposition(i, j) != null && (a.getposition(i, j).name.EndsWith("blanc") || a.getposition(i, j).name.EndsWith("blanche")))) && echecnoir(i, j, ref x1, ref y1) == 0 && echecnoir(x, y, ref x1, ref y1) == 0)
            return false;
        i = x - 1;
        if (a.PositionDansPlateau(i, j) == true && (a.getposition(i, j) == null || (a.getposition(i, j) != null && (a.getposition(i, j).name.EndsWith("blanc") || a.getposition(i, j).name.EndsWith("blanche")))) && echecnoir(i, j, ref x1, ref y1) == 0 && echecnoir(x, y, ref x1, ref y1) == 0)
            return false;
        i = x + 1;
        if (a.PositionDansPlateau(i, j) == true && (a.getposition(i, j) == null || (a.getposition(i, j) != null && (a.getposition(i, j).name.EndsWith("blanc") || a.getposition(i, j).name.EndsWith("blanche")))) && echecnoir(i, j, ref x1, ref y1) == 0 && echecnoir(x, y, ref x1, ref y1) == 0)
            return false;
        j = y + 1;
        if (a.PositionDansPlateau(i, j) == true && (a.getposition(i, j) == null || (a.getposition(i, j) != null && (a.getposition(i, j).name.EndsWith("blanc") || a.getposition(i, j).name.EndsWith("blanche")))) && echecnoir(i, j, ref x1, ref y1) == 0 && echecnoir(x, y, ref x1, ref y1) == 0)
            return false;
        i = x - 1;
        if (a.PositionDansPlateau(i, j) == true && (a.getposition(i, j) == null || (a.getposition(i, j) != null && (a.getposition(i, j).name.EndsWith("blanc") || a.getposition(i, j).name.EndsWith("blanche")))) && echecnoir(i, j, ref x1, ref y1) == 0 && echecnoir(x, y, ref x1, ref y1) == 0)
            return false;
    }         
        return true; 
    }

    public void setxprise(int x)
    {
        xprisepass = x;
    }
    public void setyprise(int y)
    {
        yprisepass = y;
    }
    public int getxprise()
    {
        return xprisepass;
    }
    public  int getyprise()
    {
        return yprisepass; 
    }
    //rook setters. 
    public void setrookgb(bool rook)
    {
        grandrookb = rook; 
    }
    public void setrookpb(bool rook)
    {
        petitrookb = rook;
    }
    public void setrookgn(bool rook)
    {
        grandrookn = rook;
    }
    public void setrookpn(bool rook)
    {
        petitrookn = rook;
    }
    //fin
   
    public void setcoords(){
            float x=xboard; 
            float y=yboard; 
            x*=0.66f; 
            y*=0.66f; 
            x+=-2.3f; 
            y+=-2.3f; 
            this.transform.position=new Vector3(x,y,-1.0f); 
        }
        public int getXboard()
        {
            return xboard; 
        }
        public int getYboard()
        {
            return yboard;
        }
        public void setXboard(int x)
        {
            xboard = x;
        }
        public void setYboard(int y)
        {
            yboard = y;
        }
    public int gettj()
    {
        return tj; 
    }
    public void prisepasspossible()
    { 
        if (tj == 2)
        {
            if (xprisepass != -1)
                if (((xboard - xprisepass) == -1 || (xboard - xprisepass) == 1) && (yboard - yprisepass) == 0)
            {
                effectuerlecarre(xprisepass, yboard - 1,false,true); 
            }
        }else {
            if (xprisepass != -1)
                if (((xboard - xprisepass) ==-1 || (xboard - xprisepass) ==1) && (yboard - yprisepass) == 0)
            {
                effectuerlecarre(xprisepass, yboard + 1, false, true);
            }
        }

    }
        public bool CloueOuNon(List<pos> t,int x1,int y1)
            { 
                for (int i = 0; i < t.Count; i++)
                    {
                   
                        if (t[i].x == x1 && t[i].y == y1)
                        {
                            if (tj == 1)
                                MVTpaticulierBlanc(x1, y1);
                            else
                                MVTpaticulierNoir(x1, y1);
                            return true; 
                        }
                          
                    }
                return false; 
            }
    void OnMouseUp(){
           
            supprimerCarreMVT();
            pos a; a.x = -1; a.y = -1;
        bool nonmvt = false;List<pos> t=new List<pos>();
       
            if (/*!controller.GetComponent<game>().GetfinPartie() && */controller.GetComponent<game>().gettj() == tj)
            {                                
            if (tj == 1)
            {
                 t= clouage_blanc();
                if (CloueOuNon(t, xboard, yboard))
                    nonmvt = true; 
            }else if(tj==2){
                  t= clouage_noir();
                if (CloueOuNon(t, xboard, yboard))
                    nonmvt = true; 
            }
                
            if(!nonmvt)
                dessinerCarreMVT(); // tracer les nouveaux mvt

            } t.Clear();
        }

    public void supprimerCarreMVT()
        {
            GameObject[] Carres = GameObject.FindGameObjectsWithTag("CarredeMvt");
            for (int i = 0; i < Carres.Length; i++)
            {
                Destroy(Carres[i]); 
            }
        }
    public void dessinerCarreMVT()
    {
        
        switch (this.name)
        {
            case "pion_noir":
                carre_Pion(xboard,yboard-1);
                if (controller.GetComponent<game>().getposition(xboard, yboard - 1) == null && yboard == 6)
                {
                    carre_Pion(xboard, yboard - 2);
                }
                prisepasspossible();
                break;  
            case "pion_blanc":
                carre_Pion(xboard, yboard+1);
                
                if(controller.GetComponent<game>().getposition(xboard,yboard+1)==null && yboard == 1)
                {
                    carre_Pion(xboard, yboard + 2);
                }
                prisepasspossible();
                break;
            case "tour_blanche":
            case "tour_noire":
                 mouvementDeTour(); break;
            
            case "fou_noir":
            case "fou_blanc":
                fouMouvement(); break;
            case "cavalier_noir":
            case "cavalier_blanc":
                mouvementcavalier(); break;

            case "reine_blanche":
            case "reine_noire":
                fouMouvement();
                mouvementDeTour(); break;
            case "roi_noir":
            case "roi_blanc":
                mouvementRoi(); break; 
        }
    }
    public void carre_Pion(int x, int y)
    {
        game a = controller.GetComponent<game>();
        if (a.PositionDansPlateau(x,y))
        {
            if (a.getposition(x, y) == null)
            {
                effectuerlecarre(x, y);
            }
            if (a.PositionDansPlateau(x+1, y))
            {
                if (a.getposition(x + 1, y) != null && a.getposition(x + 1, y).GetComponent<chessman>().tj != tj && ((y - yboard == 1) || (yboard - y == 1)))
                {
                    effectuerlecarre(x + 1, y, true);
                }
            }
            if (a.PositionDansPlateau(x - 1, y))
            {
                if (a.getposition(x - 1, y) != null && a.getposition(x - 1, y).GetComponent<chessman>().tj != tj && ((y-yboard==1) || (yboard-y==1))) //dans le moment dans la creation du plateau chaque sprite on a donner tj qui coresspant 
                {
                    effectuerlecarre(x - 1, y, true);
                }
            }
        }
        else
        {
            Debug.Log("achkaaadiiiir"); 
        }
    }
        public void effectuerlecarre(int x, int y,bool attack=false,bool prise=false) {
            float x1,y1;
            x1 =x* 0.66f;
            y1 = y * 0.66f;

            x1 += -2.3f;
            y1 += -2.3f;
        //Instantiate(carre, new Vector3(x1, y1, -1.0f), Quaternion.identity);
        if (attack==false && prise==false){
                GameObject piesse  = Instantiate(carre, new Vector3(x1, y1, -1.0f), Quaternion.identity);
            CarreDeMVT CmScript = piesse.GetComponent<CarreDeMVT>();
            CmScript.setpiesceorg(gameObject);
            CmScript.SetCoords(x, y);
        }
        else if(attack==true)
        {
            
            GameObject piece = Instantiate(carre, new Vector3(x1, y1, -3.0f), Quaternion.identity);
            CarreDeMVT c = piece.GetComponent<CarreDeMVT>();
            c.attack = true;
            c.setpiesceorg(gameObject); // kanseredla lpiyasa li wrekt 3liha 
            c.SetCoords(x, y);
        }
        if (prise)
        {
            GameObject piece = Instantiate(carre, new Vector3(x1, y1, -3.0f), Quaternion.identity);
            CarreDeMVT c = piece.GetComponent<CarreDeMVT>();
            c.priseenpassant = true;
            c.setpiesceorg(gameObject);
            c.x1=xprisepass;
            c.y1 = yprisepass;
            c.SetCoords(x, y);
        }
        }

       public void mouvementDeTour()
        {
        int j = xboard+1; 
        while (j < 8) //parcour des colonnes droites
        {
            if (controller.GetComponent<game>().getposition(j, yboard) == null)
            {
                effectuerlecarre(j, yboard);                j++; 
            }
            else if(controller.GetComponent<game>().getposition(j, yboard).GetComponent<chessman>().tj != tj)
            {
                effectuerlecarre(j, yboard,true); j = 8; 
            }
            else
                j = 8;
        }
        j= xboard - 1;
        while (j >=0) //parcour des colonnes 
        {
            if (controller.GetComponent<game>().getposition(j, yboard) == null)
            {
                effectuerlecarre(j, yboard); j--;
            }
            else if (controller.GetComponent<game>().getposition(j, yboard).GetComponent<chessman>().tj != tj)
            {
                effectuerlecarre(j, yboard, true); j = -1;
            }
            else
                j = -1;
        }
        
        int i = yboard+1;
        while (i < 8) //parcour des colonnes 
        {
            if (controller.GetComponent<game>().getposition(xboard,i) == null)
            {
                effectuerlecarre(xboard, i);      i++;
            }
            else if (controller.GetComponent<game>().getposition(xboard,i).GetComponent<chessman>().tj != tj)
            {
                effectuerlecarre(xboard, i,true); i = 8;
            }
            else
                i = 8;
        }
        i = yboard - 1; 
        while (i >=0) //parcour des colonnes 
        {
            if (controller.GetComponent<game>().getposition(xboard, i) == null)
            {
                effectuerlecarre(xboard, i); i--;
            }
            else if (controller.GetComponent<game>().getposition(xboard, i).GetComponent<chessman>().tj != tj)
            {
                effectuerlecarre(xboard, i, true); i = -1;
            }
            else
                i = -1;
        }

    }
        public void fouMouvement()
        {
            int i = yboard+1,j=xboard+1;   
            while (i<8 && j < 8)
            {
            if (controller.GetComponent<game>().getposition(j, i) == null)
                {
                effectuerlecarre(j, i,false); i++; j++; 
                }
            else if (controller.GetComponent<game>().getposition(j, i).GetComponent<chessman>().tj != tj)
            {
                effectuerlecarre(j, i,true); i = 8;
            }
            else
                i = 8;
            }
        i = yboard + 1; j = xboard - 1;
            while (i < 8 && j >=0)
            {
                if (controller.GetComponent<game>().getposition(j, i) == null)
                {
                effectuerlecarre(j, i, false); i++; j--;
                }
               else if (controller.GetComponent<game>().getposition(j, i).GetComponent<chessman>().tj != tj)
                {
                    effectuerlecarre(j, i,true); i = 8;
                }
                else
                    i = 8;
            }
        i = yboard - 1; j = xboard + 1;
            while (i >=0 && j <8 )
            {
            if (controller.GetComponent<game>().getposition(j, i) == null)
            {
                effectuerlecarre(j, i, false); i--; j++;
            }
            else if (controller.GetComponent<game>().getposition(j, i).GetComponent<chessman>().tj != tj)
            {
                effectuerlecarre(j, i, true); j = 8;
            }
            else
                j = 8;
            }
        i = yboard - 1; j = xboard - 1;
            while (i >= 0 && j >=0)
            {
                if (controller.GetComponent<game>().getposition(j, i) == null)
                {
                    effectuerlecarre(j, i, false); i--; j--;
                }
                else if (controller.GetComponent<game>().getposition(j, i).GetComponent<chessman>().tj != tj)
                {
                    effectuerlecarre(j, i, true); j = -1;
                }
                else
                    j = -1;
            }
    }
        public void mouvementcavalier()
        {
        int j = xboard+1; int i = yboard + 2;
        game a = controller.GetComponent<game>();
        if (a.PositionDansPlateau(j, i))
        {
            if (a.getposition(j, i) == null)
            
                effectuerlecarre(j, i, false);
            
            else if (a.getposition(j, i).GetComponent<chessman>().tj != tj)
            
                effectuerlecarre(j, i, true);
            
        }
        j = xboard - 1; i = yboard + 2; 
        if (a.PositionDansPlateau(j, i))
        {
            if (a.getposition(j, i) == null)

                effectuerlecarre(j, i, false);

            else if (a.getposition(j, i).GetComponent<chessman>().tj != tj)

                effectuerlecarre(j, i, true);

        }
        j = xboard -1; i = yboard -2;
        if (a.PositionDansPlateau(j, i))
        {
            if (a.getposition(j, i) == null)

                effectuerlecarre(j, i, false);

            else if (a.getposition(j, i).GetComponent<chessman>().tj != tj)

                effectuerlecarre(j, i, true);

        }
        j = xboard + 1; i = yboard - 2;
        if (a.PositionDansPlateau(j, i))
        {
            if (a.getposition(j, i) == null)

                effectuerlecarre(j, i, false);

            else if (a.getposition(j, i).GetComponent<chessman>().tj != tj)

                effectuerlecarre(j, i, true);

        }
        j = xboard + 2; i = yboard + 1;
        if (a.PositionDansPlateau(j, i))
        {
            if (a.getposition(j, i) == null)

                effectuerlecarre(j, i, false);

            else if (a.getposition(j, i).GetComponent<chessman>().tj != tj)

                effectuerlecarre(j, i, true);

        }
        j = xboard - 2; i = yboard + 1;
        if (a.PositionDansPlateau(j, i))
        {
            if (a.getposition(j, i) == null)

                effectuerlecarre(j, i, false);

            else if (a.getposition(j, i).GetComponent<chessman>().tj != tj)

                effectuerlecarre(j, i, true);

        }
        j = xboard + 2; i = yboard - 1;
        if (a.PositionDansPlateau(j, i))
        {
            if (a.getposition(j, i) == null)

                effectuerlecarre(j, i, false);

            else if (a.getposition(j, i).GetComponent<chessman>().tj != tj)

                effectuerlecarre(j, i, true);

        }
        j = xboard - 2; i = yboard - 1;
        if (a.PositionDansPlateau(j, i))
        {
            if (a.getposition(j, i) == null)

                effectuerlecarre(j, i, false);

            else if (a.getposition(j, i).GetComponent<chessman>().tj != tj)

                effectuerlecarre(j, i, true);

        }
    }
        public void mouvementRoi()
        {
        int j = xboard + 1; int i = yboard + 1;
        game a = controller.GetComponent<game>(); 
        if(a.PositionDansPlateau(j,i))
        {
            if (a.getposition(j, i) == null)
                effectuerlecarre(j, i, false);
            else if (a.getposition(j, i).GetComponent<chessman>().tj != tj)
                effectuerlecarre(j, i, true);
        }
        j = xboard - 1; 
        if (a.PositionDansPlateau(j, i))
        {
            if (a.getposition(j, i) == null)
                effectuerlecarre(j, i, false);
            else if (a.getposition(j, i).GetComponent<chessman>().tj != tj)
                effectuerlecarre(j, i, true);
        }
        j = xboard; 
        if (a.PositionDansPlateau(j, i))
        {
            if (a.getposition(j, i) == null)
                effectuerlecarre(j, i, false);
            else if (a.getposition(j, i).GetComponent<chessman>().tj != tj)
                effectuerlecarre(j, i, true);
        }
        j = xboard - 1; i = yboard; 
        if (a.PositionDansPlateau(j, i))
        {
            if (a.getposition(j, i) == null)
                effectuerlecarre(j, i, false);
            else if (a.getposition(j, i).GetComponent<chessman>().tj != tj)
                effectuerlecarre(j, i, true);
        }
        j = xboard + 1; 
        if (a.PositionDansPlateau(j, i))
        {
            if (a.getposition(j, i) == null)
                effectuerlecarre(j, i, false);
            else if (a.getposition(j, i).GetComponent<chessman>().tj != tj)
                effectuerlecarre(j, i, true);
        }
        j = xboard + 1; i = yboard - 1; 
        if (a.PositionDansPlateau(j, i))
        {
            if (a.getposition(j, i) == null)
                effectuerlecarre(j, i, false);
            else if (a.getposition(j, i).GetComponent<chessman>().tj != tj)
                effectuerlecarre(j, i, true);
        }
        j = xboard - 1; 
        if (a.PositionDansPlateau(j, i))
        {
            if (a.getposition(j, i) == null)
                effectuerlecarre(j, i, false);
            else if (a.getposition(j, i).GetComponent<chessman>().tj != tj)
                effectuerlecarre(j, i, true);
        }
        j = xboard; 
        if (a.PositionDansPlateau(j, i))
        {
            if (a.getposition(j, i) == null)
                effectuerlecarre(j, i, false);
            else if (a.getposition(j, i).GetComponent<chessman>().tj != tj)
                effectuerlecarre(j, i, true);
        }
        int s=0, w=0;
        if(tj==2 && grandrookn == true)
        {
            if(a.getposition(xboard-1,yboard)==null && a.getposition(xboard - 2, yboard) == null)
            {
                if(echecnoir(xboard,yboard,ref s, ref w)==0 && echecnoir(xboard-2,yboard,ref s, ref w)==0 && echecnoir(xboard - 1, yboard,ref s, ref w) ==0 && echecnoir(xboard - 3, yboard, ref s, ref w) ==0)
                {
                    effectuerlecarre(xboard-2, yboard, false); effectuerlecarre(xboard-1,yboard, false);
                }
            }
        }
        if(tj==2 && petitrookn == true)
        {
            if (a.getposition(xboard + 1, yboard) == null && a.getposition(xboard + 2, yboard) == null)
            {
                if (echecnoir(xboard, yboard, ref s, ref w)==0 && echecnoir(xboard + 2, yboard, ref s, ref w) ==0 && echecnoir(xboard + 1, yboard, ref s, ref w) ==0)
                    {
                    effectuerlecarre(xboard + 2, yboard, false); effectuerlecarre(xboard + 1, yboard, false);
                     }
            }
               
        }// rook blanc
        if (tj == 1 && grandrookb == true)
        {
            if (a.getposition(xboard - 1, yboard) == null && a.getposition(xboard - 2, yboard) == null)
            {
                if (echecblanc(xboard , yboard, ref s, ref w) ==0 && echecblanc(xboard - 2, yboard, ref s, ref w) ==0 && echecblanc(xboard - 1, yboard, ref s, ref w) ==0 && echecblanc(xboard - 3, yboard, ref s, ref w) ==0)
                { 
                    effectuerlecarre(xboard - 2, yboard, false); effectuerlecarre(xboard - 1, yboard, false);
                }
            }
        }
        if (tj == 1 && petitrookb == true)
        {
            if (a.getposition(xboard + 1, yboard) == null && a.getposition(xboard + 2, yboard) == null)
            {
                if (echecblanc(xboard, yboard, ref s, ref w) ==0 && echecblanc(xboard + 2, yboard, ref s, ref w) ==0 && echecblanc(xboard + 1, yboard, ref s, ref w) ==0)
                {
                    effectuerlecarre(xboard + 2, yboard, false); effectuerlecarre(xboard + 1, yboard, false);
                }
            }
        }


    }
    //chercher le roi : 
        public pos chercherroi(string roi)
        { pos r;
            for (int i = 0; i < 8; i++){
            for (int j = 0; j < 8; j++)
            {
                if (controller.GetComponent<game>().getposition(i, j)!=null && controller.GetComponent<game>().getposition(i, j).name == roi) { 
                    r.x = i; r.y =j;
                    return r;
                }
            }
           
            } r.x = -1; r.y = -1;
            return r;
        }
    //clouage blanc 
        public List<pos> clouage_blanc()
        {
        pos roi, temp; temp.x = -1; temp.y = -1;
        roi = chercherroi("roi_blanc");      
        List<pos> cloue =new List<pos>();
        //cloue.Clear();
        int i = roi.x+1; int j = roi.y; int cp = 0;
        game a = controller.GetComponent<game>();
        int x1 = 0; int y1 = 0; bool arriver = false;
        while (i < 8)
        {
            if (a.getposition(i,j)!=null && (a.getposition(i, j).name.EndsWith("blanc")|| a.getposition(i, j).name.EndsWith("blanche")) && echecblanc(i, j,ref x1,ref y1) == 1 && (a.getposition(x1, y1).name == "tour_noire" || a.getposition(x1, y1).name == "reine_noire") && y1 == roi.y)
            {
                temp.x = i; temp.y = j; 
                i++; cp++;
            }
            else if (a.getposition(i, j) != null && (a.getposition(i, j).name.EndsWith("blanc") || a.getposition(i, j).name.EndsWith("blanche")))
            {
                cp++; i++;
            }
            else
                i++;
            if (a.PositionDansPlateau(i, j))
                if (cp > 1 || (a.getposition(i, j) != null && (a.getposition(i, j).name == "tour_noire" || a.getposition(i, j).name == "reine_noire"))) //ima wselna lhadi li ghatakolo ya ima nbr des pieces li fdak chemain fat 1
                { i = 8; arriver = true; }
        }
        if (temp.x != -1 && cp == 1 && arriver)
        {
            cloue.Add(temp); 
        }
        temp.x = -1; temp.y = -1; cp = 0;
        i = roi.x - 1; j = roi.y; arriver = false; 
        while (i >=0)
        {
            if (a.getposition(i, j) != null && (a.getposition(i, j).name.EndsWith("blanc") || a.getposition(i, j).name.EndsWith("blanche")) && echecblanc(i, j, ref x1, ref y1) == 1 && (a.getposition(x1, y1).name == "tour_noire" || a.getposition(x1, y1).name == "reine_noire") && y1 == roi.y)
            {
                temp.x = i; temp.y = j; Debug.Log( x1 & y1);
                i--; cp++;
            }
            else if (a.getposition(i, j) != null && (a.getposition(i, j).name.EndsWith("blanc") || a.getposition(i, j).name.EndsWith("blanche")))
            {
                cp++; i--;
            }
            else
                i--;
            if (a.PositionDansPlateau(i, j))
            if (cp > 1 || (a.getposition(i, j) != null && (a.getposition(i, j).name == "tour_noire" || a.getposition(i, j).name == "reine_noire"))) //ima wselna lhadi li ghatakolo ya ima nbr des pieces li fdak chemain fat 1
            { i = -1;arriver = true; }
        }
        if (temp.x != -1 && cp == 1 && arriver)
        {
            cloue.Add(temp); 
        }
        temp.x = -1; temp.y = -1; cp = 0; arriver = false;
        i = roi.x; j = roi.y+1; 
        while (j<8)
        {
            if (a.getposition(i, j) != null && (a.getposition(i, j).name.EndsWith("blanc") || a.getposition(i, j).name.EndsWith("blanche")) && echecblanc(i, j, ref x1, ref y1) == 1 && (a.getposition(x1, y1).name == "tour_noire" || a.getposition(x1, y1).name == "reine_noire") && x1 == roi.x)
            {
                temp.x = i; temp.y = j; 
                j++; cp++;
            }
            else if (a.getposition(i, j) != null && (a.getposition(i, j).name.EndsWith("blanc") || a.getposition(i, j).name.EndsWith("blanche")))
            {
                cp++; j++;
            }
            else
                j++;
            if(a.PositionDansPlateau(i,j))
            if (cp > 1 || (a.getposition(i, j) != null && (a.getposition(i, j).name == "tour_noire" || a.getposition(i, j).name == "reine_noire"))) //ima wselna lhadi li ghatakolo ya ima nbr des pieces li fdak chemain fat 1
            { j=8;arriver = true; }
        }
        if (temp.x != -1 && cp == 1 && arriver)
        {

            cloue.Add(temp); 
        }
        temp.x = -1; temp.y = -1; cp = 0; arriver = false;
        i = roi.x; j = roi.y-1;
        while (j >= 0)
        {
            if (a.getposition(i, j) != null && (a.getposition(i, j).name.EndsWith("blanc") || a.getposition(i, j).name.EndsWith("blanche")) && echecblanc(i, j, ref x1, ref y1) == 1 && (a.getposition(x1, y1).name == "tour_noire" || a.getposition(x1, y1).name == "reine_noire") && x1 == roi.x)
            {
                temp.x = i; temp.y = j;Debug.Log( x1 & y1);
                j--; cp++;
            }
            else if (a.getposition(i, j) != null && (a.getposition(i, j).name.EndsWith("blanc") || a.getposition(i, j).name.EndsWith("blanche")))
            {
                cp++; j--;
            }
            else
                j--;
            if (a.PositionDansPlateau(i, j))
                if (cp > 1 || (a.getposition(i, j) != null && (a.getposition(i, j).name == "tour_noire" || a.getposition(i, j).name == "reine_noire"))) //ima wselna lhadi li ghatakolo ya ima nbr des pieces li fdak chemain fat 1
                {j = -1;arriver = true; }
        }
        if (temp.x != -1 && cp == 1 && arriver)
        {
            cloue.Add(temp); 
        }
        //cas de diagonale : -------------------------------------------------------------------------------------------------------------------
        temp.x = -1; temp.y = -1; cp = 0; arriver = false;
        i = roi.x + 1; j = roi.y + 1; 
        while (i <8 && j<8)
        {
            if (a.getposition(i, j) != null && (a.getposition(i, j).name.EndsWith("blanc") || a.getposition(i, j).name.EndsWith("blanche")) && echecblanc(i, j, ref x1, ref y1) == 1 && (a.getposition(x1, y1).name == "fou_noir" || a.getposition(x1, y1).name == "reine_noire") && x1> roi.x)
            {
                temp.x = i; temp.y = j; 
                i++; j++; cp++;
            }
            else if (a.getposition(i, j) != null && (a.getposition(i, j).name.EndsWith("blanc") || a.getposition(i, j).name.EndsWith("blanche")))
            {
                cp++; i++; j++; 
            }
            else
            {
                 i++; j++; 
            }
            if (a.PositionDansPlateau(i, j))
                if (cp > 1 || (a.getposition(i, j) != null && (a.getposition(i, j).name == "fou_noir" || a.getposition(i, j).name == "reine_noire"))) //ima wselna lhadi li ghatakolo ya ima nbr des pieces li fdak chemain fat 1
                {
                    i = 8; arriver = true;  
                }
        }
        if (temp.x != -1 && cp == 1 && arriver)
        {
            cloue.Add(temp);
        }
        /////--------------------------------------------
        temp.x = -1; temp.y = -1; cp = 0; arriver = false;
        i = roi.x - 1; j = roi.y + 1;
        while (i>=0 && j<8)
        {
            if (a.getposition(i, j) != null && (a.getposition(i, j).name.EndsWith("blanc") || a.getposition(i, j).name.EndsWith("blanche")) && echecblanc(i, j, ref x1, ref y1) == 1 && (a.getposition(x1, y1).name == "fou_noir" || a.getposition(x1, y1).name == "reine_noire") && x1 < roi.x)
            {
                temp.x = i; temp.y = j; 
                i--; j++; cp++;
            }
            else if (a.getposition(i, j) != null && (a.getposition(i, j).name.EndsWith("blanc") || a.getposition(i, j).name.EndsWith("blanche")))
            {
                cp++; i--; j++;
            }
            else
            {
                i--; j++;
            }
            if (a.PositionDansPlateau(i, j))
                if (cp > 1 || (a.getposition(i, j) != null && (a.getposition(i, j).name == "fou_noir" || a.getposition(i, j).name == "reine_noire"))) //ima wselna lhadi li ghatakolo ya ima nbr des pieces li fdak chemain fat 1
                {i = -1;arriver = true; }
        }
        if (temp.x != -1 && cp == 1 && arriver)
        {
            cloue.Add(temp); 
        }
        temp.x = -1; temp.y = -1; cp = 0; arriver = false;
        i = roi.x - 1; j = roi.y - 1;
        while (i>=0 && j>=0)
        {
            if (a.getposition(i, j) != null && (a.getposition(i, j).name.EndsWith("blanc") || a.getposition(i, j).name.EndsWith("blanche")) && echecblanc(i, j, ref x1, ref y1) == 1 && (a.getposition(x1, y1).name == "fou_noir" || a.getposition(x1, y1).name == "reine_noire") && x1 < roi.x)
            {
                temp.x = i; temp.y = j; 
                i--; j--; cp++;
            }
            else if (a.getposition(i, j) != null && (a.getposition(i, j).name.EndsWith("blanc") || a.getposition(i, j).name.EndsWith("blanche")))
            {
                cp++; i--; j--;
            }
            else
            {
                i--; j--; 
            }
               
            if (a.PositionDansPlateau(i, j))
                if (cp > 1 || (a.getposition(i, j) != null && (a.getposition(i, j).name == "fou_noir" || a.getposition(i, j).name == "reine_noire"))) //ima wselna lhadi li ghatakolo ya ima nbr des pieces li fdak chemain fat 1
                {i = -1;arriver = true; }
        }
        if (temp.x != -1 && cp == 1 && arriver)
        {
            cloue.Add(temp);
        }

        temp.x = -1; temp.y = -1; cp = 0; arriver = false;
        i = roi.x + 1; j = roi.y - 1;
        while (i < 8 && j>=0)
        {
            if (a.getposition(i, j) != null && (a.getposition(i, j).name.EndsWith("blanc") || a.getposition(i, j).name.EndsWith("blanche")) && echecblanc(i, j, ref x1, ref y1) == 1 && (a.getposition(x1, y1).name == "fou_noir" || a.getposition(x1, y1).name == "reine_noire") && x1 > roi.x)
            {
                temp.x = i; temp.y = j; 
                i++; j--; cp++;
            }
            else if (a.getposition(i, j) != null && (a.getposition(i, j).name.EndsWith("blanc") || a.getposition(i, j).name.EndsWith("blanche")))
            {
                cp++; i++; j--;
            }
            else
            {
                i++; j--;
            }
            if (a.PositionDansPlateau(i, j))
                if (cp > 1 || (a.getposition(i, j) != null && (a.getposition(i, j).name == "fou_noir" || a.getposition(i, j).name == "reine_noire"))) //ima wselna lhadi li ghatakolo ya ima nbr des pieces li fdak chemain fat 1
                {i = 8;arriver = true; }
        }
        if (temp.x != -1 && cp == 1 && arriver)
        {
            cloue.Add(temp); 
        }
        return cloue;
    }
        //clouage noir 
        public List<pos> clouage_noir()
        {
            pos roi, temp; temp.x = -1; temp.y = -1;
            roi = chercherroi("roi_noir");
            
            List<pos> cloue = new List<pos>();
            int i = roi.x + 1; int j = roi.y; int cp = 0;
            game a = controller.GetComponent<game>();
            int x1 = 0; int y1 = 0; bool arriver=false;
            while (i < 8)
            {
                if (a.getposition(i, j) != null && (a.getposition(i, j).name.EndsWith("noir") || a.getposition(i, j).name.EndsWith("noire")) && echecnoir(i, j, ref x1, ref y1) == 1 && (a.getposition(x1, y1).name == "tour_blanche" || a.getposition(x1, y1).name == "reine_blanche") && y1 == roi.y)
                {
                    temp.x = i; temp.y = j;
                    i++; cp++;
                }
                else if (a.getposition(i, j) != null && (a.getposition(i, j).name.EndsWith("noir") || a.getposition(i, j).name.EndsWith("noire")))
                {
                    cp++; i++;
                }
                else
                    i++;
                if (a.PositionDansPlateau(i, j))
                if (cp > 1 || (a.getposition(i,j)!= null && (a.getposition(i, j).name == "tour_blanche" || a.getposition(i, j).name == "reine_blanche"))) //ima wselna lhadi li ghatakolo ya ima nbr des pieces li fdak chemain fat 1
                {i = 8;arriver = true; }
            }
            if (temp.x != -1 && cp == 1 && arriver)
            {
                cloue.Add(temp); 
            }
            temp.x = -1; temp.y = -1; cp = 0; arriver = false;
            i = roi.x - 1; j = roi.y;
            while (i >= 0)
            {
                if (a.getposition(i, j) != null && (a.getposition(i, j).name.EndsWith("noir") || a.getposition(i, j).name.EndsWith("noire")) && echecnoir(i, j, ref x1, ref y1) == 1 && (a.getposition(x1, y1).name == "tour_blanche" || a.getposition(x1, y1).name == "reine_blanche") && y1 == roi.y)
                {
                    temp.x = i; temp.y = j;
                    i--; cp++;
                }
                else if (a.getposition(i, j) != null && (a.getposition(i, j).name.EndsWith("noir") || a.getposition(i, j).name.EndsWith("noire")))
                {
                    cp++; i--;
                }
                else
                    i--;
                if (a.PositionDansPlateau(i, j)) 
                if (cp > 1 || (a.getposition(i, j) != null && (a.getposition(i, j).name == "tour_blanche" || a.getposition(i, j).name == "reine_blanche"))) //ima wselna lhadi li ghatakolo ya ima nbr des pieces li fdak chemain fat 1
                {i = -1;arriver = true; }
            }
            if (temp.x != -1 && cp == 1 && arriver)
            {
                cloue.Add(temp); 
            }
            temp.x = -1; temp.y = -1; cp = 0; arriver = false;
            i = roi.x; j = roi.y + 1;
            while (j < 8)
            {
                if (a.getposition(i, j) != null && (a.getposition(i, j).name.EndsWith("noir") || a.getposition(i, j).name.EndsWith("noire")) && echecnoir(i, j, ref x1, ref y1) == 1 && (a.getposition(x1, y1).name == "tour_blanche" || a.getposition(x1, y1).name == "reine_blanche") && x1 == roi.x)
                {
                    temp.x = i; temp.y = j;
                    j++; cp++;
                }
                else if (a.getposition(i, j) != null && (a.getposition(i, j).name.EndsWith("noir") || a.getposition(i, j).name.EndsWith("noire")))
                {
                    cp++; j++;
                }
                else
                    j++;
                if (a.PositionDansPlateau(i, j))
                    if (cp > 1 || (a.getposition(i, j) != null && (a.getposition(i, j).name == "tour_blanche" || a.getposition(i, j).name == "reine_blanche"))) //ima wselna lhadi li ghatakolo ya ima nbr des pieces li fdak chemain fat 1
                    {j = 8;arriver = true; }
            }
            if (temp.x != -1 && cp == 1 && arriver)
            {

                cloue.Add(temp); 
            }
            temp.x = -1; temp.y = -1; cp = 0; arriver = false;
            i = roi.x; j = roi.y - 1;
            while (j >= 0)
            {
                if (a.getposition(i, j) != null && (a.getposition(i, j).name.EndsWith("noir") || a.getposition(i, j).name.EndsWith("noire")) && echecnoir(i, j, ref x1, ref y1) == 1 && (a.getposition(x1, y1).name == "tour_blanche" || a.getposition(x1, y1).name == "reine_blanche") && x1 == roi.x)
                {
                    temp.x = i; temp.y = j;
                    j--; cp++;
                }
                else if (a.getposition(i, j) != null && (a.getposition(i, j).name.EndsWith("noir") || a.getposition(i, j).name.EndsWith("noire")))
                {
                    cp++; j--;
                }
                else
                    j--;
                if (a.PositionDansPlateau(i, j))
                    if (cp > 1 || (a.getposition(i, j) != null && (a.getposition(i, j).name == "tour_blanche" || a.getposition(i, j).name == "reine_blanche"))) //ima wselna lhadi li ghatakolo ya ima nbr des pieces li fdak chemain fat 1
                    {j = -1;arriver = true; }
            }
            if (temp.x != -1 && cp == 1 && arriver)
            {
                cloue.Add(temp); 
            }
            //cas de diagonale : -------------------------------------------------------------------------------------------------------------------
            temp.x = -1; temp.y = -1; cp = 0; arriver = false;
            i = roi.x + 1; j = roi.y + 1;
            while (i < 8 && j < 8)
            {
                if (a.getposition(i, j) != null && (a.getposition(i, j).name.EndsWith("noir") || a.getposition(i, j).name.EndsWith("noire")) && echecnoir(i, j, ref x1, ref y1) == 1 && (a.getposition(x1, y1).name == "fou_blanc" || a.getposition(x1, y1).name == "reine_blanche") && x1 > roi.x)
                {
                    temp.x = i; temp.y = j;
                    i++; j++; cp++;
                }
                else if (a.getposition(i, j) != null && (a.getposition(i, j).name.EndsWith("noir") || a.getposition(i, j).name.EndsWith("noire")))
                {
                    cp++; i++; j++;
                }
                else
                {
                    i++; j++;
                }
                if (a.PositionDansPlateau(i, j))
                    if (cp > 1 || (a.getposition(i, j) != null && (a.getposition(i, j).name == "fou_blanc" || a.getposition(i, j).name == "reine_blanche"))) //ima wselna lhadi li ghatakolo ya ima nbr des pieces li fdak chemain fat 1
                    {i = 8;arriver = true; }
            }
            if (temp.x != -1 && cp == 1 && arriver)
            {
                cloue.Add(temp); 
            } 
            /////--------------------------------------------
            temp.x = -1; temp.y = -1; cp = 0; arriver = false;
            i = roi.x - 1; j = roi.y + 1;
            while (i >= 0 && j < 8)
            {
                if (a.getposition(i, j) != null && (a.getposition(i, j).name.EndsWith("noir") || a.getposition(i, j).name.EndsWith("noire")) && echecnoir(i, j, ref x1, ref y1) == 1 && (a.getposition(x1, y1).name == "fou_blanc" || a.getposition(x1, y1).name == "reine_blanche") && x1 < roi.x)
                {
                    temp.x = i; temp.y = j;
                    i--; j++; cp++;
                }
                else if (a.getposition(i, j) != null && (a.getposition(i, j).name.EndsWith("noir") || a.getposition(i, j).name.EndsWith("noire")))
                {
                    cp++; i--; j++;
                }
                else
                {
                    i--; j++;
                }
                if (a.PositionDansPlateau(i, j))
                    if (cp > 1 || (a.getposition(i, j) != null && (a.getposition(i, j).name == "fou_blanc" || a.getposition(i, j).name == "reine_blanche"))) //ima wselna lhadi li ghatakolo ya ima nbr des pieces li fdak chemain fat 1
                    {i = -1;arriver = true; }
            }
            if (temp.x != -1 && cp == 1 && arriver)
            {
                cloue.Add(temp); 
            }
            temp.x = -1; temp.y = -1; cp = 0; arriver = false;
            i = roi.x - 1; j = roi.y - 1;
            while (i >= 0 && j >= 0)
            {
                if (a.getposition(i, j) != null && (a.getposition(i, j).name.EndsWith("noir") || a.getposition(i, j).name.EndsWith("noire")) && echecnoir(i, j, ref x1, ref y1) == 1 && (a.getposition(x1, y1).name == "fou_blanc" || a.getposition(x1, y1).name == "reine_blanche") && x1 < roi.x)
                {
                    temp.x = i; temp.y = j;
                    i--; j--; cp++;
                }
                else if (a.getposition(i, j) != null && (a.getposition(i, j).name.EndsWith("noir") || a.getposition(i, j).name.EndsWith("noire")))
                {
                    cp++; i--; j--;
                }
                else { i--; j--; }
                    
                if (a.PositionDansPlateau(i, j))
                    if (cp > 1 || (a.getposition(i, j) != null && (a.getposition(i, j).name == "fou_blanc" || a.getposition(i, j).name == "reine_blanche"))) //ima wselna lhadi li ghatakolo ya ima nbr des pieces li fdak chemain fat 1
                    {i = -1;arriver = true; }
            }
            if (temp.x != -1 && cp == 1 && arriver)
            {
                cloue.Add(temp); 
            }

            temp.x = -1; temp.y = -1; cp = 0; arriver = false;
            i = roi.x + 1; j = roi.y - 1;
            while (i < 8 && j >= 0)
            {
                if (a.getposition(i, j) != null && (a.getposition(i, j).name.EndsWith("noir") || a.getposition(i, j).name.EndsWith("noire")) && echecnoir(i, j, ref x1, ref y1) == 1 && (a.getposition(x1, y1).name == "fou_blanc" || a.getposition(x1, y1).name == "reine_blanche") && x1 > roi.x)
                {
                    temp.x = i; temp.y = j;
                    i++; j--; cp++;
                }
                else if (a.getposition(i, j) != null && (a.getposition(i, j).name.EndsWith("noir") || a.getposition(i, j).name.EndsWith("noire")))
                {
                    cp++; i++; j--;
                }
                else
                {
                    i++; j--;
                }
                if (a.PositionDansPlateau(i, j))
                    if (cp > 1 || (a.getposition(i, j) != null && (a.getposition(i, j).name == "fou_blanc" || a.getposition(i, j).name == "reine_blanche"))) //ima wselna lhadi li ghatakolo ya ima nbr des pieces li fdak chemain fat 1
                    {i = 8;arriver = true; }
            }
            if (temp.x != -1 && cp == 1 && arriver)
            {
                cloue.Add(temp);
            }
            return cloue;
        }
        public void MVTpaticulierNoir(int x, int y)
        {

            game a = controller.GetComponent<game>();
            GameObject Pcloue = a.getposition(x, y);
            int x1 = 0, y1 = 0; int x2 = 0, y2 = 0;
            echecnoir(x, y, ref x1, ref y1);
            a.viderlacase(x, y);
            pos roi = chercherroi("roi_noir");
            echecnoir(roi.x, roi.y, ref x2, ref y2);
            a.setposition2(Pcloue, x, y);
            if (x1 == x2 && y1 == y2)
            {

                if (a.getposition(x, y).name == "tour_noire" || a.getposition(x, y).name == "reine_noire")
                {
                    if (x == x1 && y < y1)
                        MvtParTour(x, y, "haut", "blanc");
                    else if (x == x1 && y > y1)
                        MvtParTour(x, y, "bas", "blanc");
                    else if (y == y1 && x < x1)
                        MvtParTour(x, y, "droite", "blanc");
                    else if (y == y1 && x > x1)
                        MvtParTour(x, y, "gauche", "blanc");
                }
                if (a.getposition(x, y).name == "fou_noir" || a.getposition(x, y).name == "reine_noire")
                {
                    if (x > x1 && y > y1)
                        MvtParfou(x, y, "Ddroite", "blanc");
                    if (x1 > x && y > y1)
                        MvtParfou(x, y, "Dgauche", "blanc");
                }
                if (a.getposition(x, y).name == "pion_noir")
                {
                    if (x == x1 + 1 && y == y1 + 1)
                        MvtParPion(x, y, "droite", "blanc");
                    if (x1 == x + 1 && y == y1 + 1)
                        MvtParPion(x, y, "gauche", "blanc");
                    if (x1 == x && y > y1)
                        MvtParPion(x, y, "tdroite", "blanc");
                }
            }

        }
    

        public void MVTpaticulierBlanc(int x,int y)
        {            
            game a = controller.GetComponent<game>();
            GameObject Pcloue = a.getposition(x, y);
            int x1=0, y1=0;int x2 = 0, y2 = 0;
            echecblanc(x, y, ref x1, ref y1);
            a.viderlacase(x, y);
            pos roi = chercherroi("roi_blanc");
            echecblanc(roi.x,roi.y,ref x2,ref y2);
            a.setposition2(Pcloue,x,y); 
            if (x1 == x2 && y1 == y2)
            {
                
                if (a.getposition(x, y).name == "tour_blanche" || a.getposition(x, y).name == "reine_blanche")
                {
                    if (x == x1 && y < y1)
                        MvtParTour(x, y, "haut","noir"); 
                    else if(x==x1 && y>y1)
                        MvtParTour(x, y, "bas", "noir");
                    else if(y==y1 && x<x1)
                        MvtParTour(x, y, "droite", "noir");
                    else if(y==y1 && x>x1)
                        MvtParTour(x, y, "gauche", "noir");
                } 
                 if(a.getposition(x, y).name == "fou_blanc" || a.getposition(x, y).name == "reine_blanche")
                {
                    if (x > x1  && y1 > y )
                        MvtParfou(x, y, "Dgauche", "noir"); 
                    if(x1>x && y1>y)
                        MvtParfou(x, y, "Ddroite", "noir");
                }
                 if (a.getposition(x, y).name == "pion_blanc")
                {
                   
                    if(x==x1+1 && y1==y+1)
                        MvtParPion(x, y, "gauche", "noir");
                    if(x1==x+1 && y1==y+1)
                        MvtParPion(x, y, "droite", "noir");
                    if(x1==x && y1>y)
                        MvtParPion(x, y, "tdroite", "noir");
                }    
            }

        }
        public void MvtParTour(int x,int y, string chemain,string piece)
        {game a = controller.GetComponent<game>();
            string piece2,piece22,piece33; 
            if(piece=="blanc") //l3eks
                piece2="blanche"; 
            else 
                piece2="noire";
            int x1 = x,y1=y; 
            if (chemain == "haut")
            {
                //Debug.Log("ana hna db");
                y++;
                while (y < 8)
                {
                    if (a.getposition(x, y) != null && (a.getposition(x, y).name.EndsWith(piece) || a.getposition(x, y).name.EndsWith(piece2))){
                         effectuerlecarre(x, y, true, false);y = 8;
                    }    
                    else
                        effectuerlecarre(x, y, false, false);
                    y++;
                }
                y =y1-1;
                if (piece == "blanc") 
                {
                    piece22 = "noir"; piece33 = "noire";
                }
                else
                {
                    piece22 = "blanc"; piece33 = "blanche";
                }
                    
                while (y >=0)
                {
                    if (a.getposition(x, y) != null && (a.getposition(x, y).name.EndsWith(piece22) || a.getposition(x, y).name.EndsWith(piece33)))
                    
                         y = -1;
                  
                    else
                        effectuerlecarre(x, y, false, false);
                    y--;
                }
            }
            else if (chemain== "bas"){
                y--; 
                while (y >= 0)
                {
                    if (a.getposition(x, y) != null && (a.getposition(x, y).name.EndsWith(piece) || a.getposition(x, y).name.EndsWith(piece2)))
                    {
                        effectuerlecarre(x, y, true, false); y = -1;
                    }  
                    else
                        effectuerlecarre(x, y, false, false);
                    y--;               
                }
                y = y1 + 1;
                if (piece == "blanc")
                {
                    piece22 = "noir"; piece33 = "noire";
                }
                else
                {
                    piece22 = "blanc"; piece33 = "blanche";
                }

                while (y <8)
                {
                    if (a.getposition(x, y) != null && (a.getposition(x, y).name.EndsWith(piece22) || a.getposition(x, y).name.EndsWith(piece33)))
                        y = 8;
                    else
                        effectuerlecarre(x, y, false, false);
                    y++;
                }
            }
            else if (chemain == "droite")
            {
                x++;
                while (x <8)
                {
                    if (a.getposition(x, y) != null && (a.getposition(x, y).name.EndsWith(piece) || a.getposition(x, y).name.EndsWith(piece2)))
                    {
                        effectuerlecarre(x, y, true, false); x=8;
                    }  
                    else
                        effectuerlecarre(x, y, false, false);
                    x++;
                }
                x = x1 - 1;
                if (piece == "blanc")
                {
                    piece22 = "noir"; piece33 = "noire";
                }
                else
                {
                    piece22 = "blanc"; piece33 = "blanche";
                }

                while (x>=0)
                {
                    if (a.getposition(x, y) != null && (a.getposition(x, y).name.EndsWith(piece22) || a.getposition(x, y).name.EndsWith(piece33)))
                        x=-1;
                    else
                        effectuerlecarre(x, y, false, false);
                    x--;
                }
            }
            else if (chemain == "gauche")
            {
                x--;
                while (x >= 0)
                {
                    if (a.getposition(x, y) != null && (a.getposition(x, y).name.EndsWith(piece) || a.getposition(x, y).name.EndsWith(piece2)))
                    {
                        effectuerlecarre(x, y, true, false); x = -1;
                    }  
                    else
                        effectuerlecarre(x, y, false, false);
                    x--;
                }
                x = x1 + 1;
                if (piece == "blanc")
                {
                    piece22 = "noir"; piece33 = "noire";
                }
                else
                {
                    piece22 = "blanc"; piece33 = "blanche";
                }

                while (x < 8)
                {
                    if (a.getposition(x, y) != null && (a.getposition(x, y).name.EndsWith(piece22) || a.getposition(x, y).name.EndsWith(piece33)))
                        x = 8;
                    else
                        effectuerlecarre(x, y, false, false);
                    x++;
                }

            }

        }
        public void MvtParfou(int x, int y, string chemain, string piece)
        {
            game a = controller.GetComponent<game>();
            string piece2;
            if (piece == "blanc") //l3eks
                piece2 = "blanche";
            else
                piece2 = "noire";
            int i = x - 1, j = y + 1; string piece22, piece33;
            if (piece == "noir")
            {
                if (chemain == "Dgauche")
                {
                    while (j < 8 && i >= 0)
                    {
                        if (a.getposition(i, j) != null && (a.getposition(i, j).name.EndsWith(piece) || a.getposition(i, j).name.EndsWith(piece2)))
                        {
                            effectuerlecarre(i, j, true, false); i = -1;
                        }
                        else
                        {
                            effectuerlecarre(i, j, false, false); Debug.Log("afeen");
                            i--; j++;
                        }
                    }
                    i = x + 1; j = y - 1;
                    if (piece == "blanc")
                    {

                        piece22 = "noir"; piece33 = "noire";
                    }
                    else
                    {
                        piece22 = "blanc"; piece33 = "blanche";
                    }
                    while (i < 8 && j >= 0)
                    {
                        if (a.getposition(i, j) != null && (a.getposition(i, j).name.EndsWith(piece22) || a.getposition(i, j).name.EndsWith(piece33)))
                        {
                            i = 8;
                        }
                        else
                        {
                            effectuerlecarre(i, j, false, false);
                            i++; j--;
                        }

                    }
                }
                else
                {
                    i = x + 1; j = y + 1;
                    while (j < 8 && i < 8)
                    {
                        if (a.getposition(i, j) != null && (a.getposition(i, j).name.EndsWith(piece) || a.getposition(i, j).name.EndsWith(piece2)))
                        {
                            effectuerlecarre(i, j, true, false); i = 8;
                        }
                        else
                        {
                            effectuerlecarre(i, j, false, false);
                            i++; j++;
                        }
                    }
                    i = x - 1; j = y - 1;
                    if (piece == "blanc")
                    {

                        piece22 = "noir"; piece33 = "noire";
                    }
                    else
                    {
                        piece22 = "blanc"; piece33 = "blanche";
                    }
                    while (i >= 0 && j >= 0)
                    {
                        if (a.getposition(i, j) != null && (a.getposition(i, j).name.EndsWith(piece22) || a.getposition(i, j).name.EndsWith(piece33)))
                        {
                            i = -1;
                        }
                        else
                        {
                            effectuerlecarre(i, j, false, false);
                            i--; j--;
                        }
                    }

                }
            }
            else
            {
                if (chemain == "Dgauche")
                {
                    i = x + 1; j = y - 1;
                    while (j <=0 && i <8)
                    {
                        if (a.getposition(i, j) != null && (a.getposition(i, j).name.EndsWith(piece) || a.getposition(i, j).name.EndsWith(piece2)))
                        {
                            effectuerlecarre(i, j, true, false); i = 8;
                        }
                        else
                        {
                            effectuerlecarre(i, j, false, false); 
                            i++; j--;
                        }
                    }
                    i = x - 1; j = y + 1;                 

                        piece22 = "noir"; piece33 = "noire";
                  
                    while (i >=0 && j < 8)
                    {
                        if (a.getposition(i, j) != null && (a.getposition(i, j).name.EndsWith(piece22) || a.getposition(i, j).name.EndsWith(piece33)))
                        {
                            i = -1;
                        }
                        else
                        {
                            effectuerlecarre(i, j, false, false);
                            i--; j++;
                        }

                    }
                }
                else
                {
                    i = x - 1; j = y - 1;
                    while (j >=0 && i >=0)
                    {
                        if (a.getposition(i, j) != null && (a.getposition(i, j).name.EndsWith(piece) || a.getposition(i, j).name.EndsWith(piece2)))
                        {
                            effectuerlecarre(i, j, true, false); i =-1;
                        }
                        else
                        {
                            effectuerlecarre(i, j, false, false);
                            i--; j--;
                        }
                    }
                    i = x + 1; j = y + 1;
                    

                        piece22 = "noir"; piece33 = "noire";
                    
                    while (i <8  && j <8 )
                    {
                        if (a.getposition(i, j) != null && (a.getposition(i, j).name.EndsWith(piece22) || a.getposition(i, j).name.EndsWith(piece33)))
                        {
                            i = 8;     
                        }
                        else
                        {
                            effectuerlecarre(i, j, false, false);
                            i++; j++;
                        }
                    }

                }




            }
        }

        public void MvtParPion(int x, int y, string chemain, string piece)
        {
            game a = controller.GetComponent<game>();
            string piece2;
            if (piece == "blanc") //l3eks
                piece2 = "blanche";
            else
                piece2 = "noire";
            int i=0,j=0;
            if (piece == "noir") { 
            if (chemain == "tdroite")
            {
                if (piece == "noir" && y==1)
                {
                    i = x; j = y + 1; 
                    while (j <= y+2)
                    {
                        if (a.getposition(i, j) != null && (a.getposition(i, j).name.EndsWith(piece) || a.getposition(i, j).name.EndsWith(piece2)))
                            j = 8;
                        else
                        {
                            effectuerlecarre(i, j, false, false); j++;
                        }
                            
                    }
                }
                    
                else if (y != 1 )
                {i=x; j=y+1;
                    
                    
                        if (a.getposition(i, j)==null)
                            effectuerlecarre(i, j, false, false);
                          

                }


            }else if(chemain == "droite")
                effectuerlecarre(x+1, y+1, true, false);
            else
                effectuerlecarre(x-1, y+1, true, false);
            }
            else
            {

                if (chemain == "tdroite")
                {
                    if (piece == "blanc" && y == 6)
                    {
                        i = x; j = y - 1;
                        while (j >= y - 2)
                        {
                            if (a.getposition(i, j) != null && (a.getposition(i, j).name.EndsWith(piece) || a.getposition(i, j).name.EndsWith(piece2)))
                                j = -1;
                            else
                            {
                                effectuerlecarre(i, j, false, false); j--;
                            }

                        }
                    }

                    else if (y != 6)
                    {
                        i = x; j = y - 1;


                        if (a.getposition(i, j) == null)
                            effectuerlecarre(i, j, false, false);
                    }


                }
                else if (chemain == "droite")
                    effectuerlecarre(x - 1, y - 1, true, false);
                else
                    effectuerlecarre(x + 1, y - 1, true, false);



            }

        }


}
