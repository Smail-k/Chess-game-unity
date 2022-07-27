using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class echange : MonoBehaviour
{
    public GameObject controller;
    public GameObject echangemenu;
    //public GameObject echangemenu2; 
    public GameObject piece;
    public int x1,y1; 
    public void afficher_echange(int x,int y){
        x1 = x; y1 = y; 
        echangemenu.SetActive(true);
    }
   
    public void echange_tour()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");
        game a = controller.GetComponent<game>();
        string tour;
        if (a.gettj() == 2)
            tour = "tour_blanche";
        else
            tour = "tour_noire";
        piece = a.Create(tour, x1, y1);
        a.setposition(piece);
        echangemenu.SetActive(false);
    }
    public void echange_reine()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");
        game a = controller.GetComponent<game>();
        string reine;
        if (a.gettj() == 2)
            reine = "reine_blanche";
        else
            reine = "reine_noire"; 
        piece = a.Create(reine, x1, y1);
        a.setposition(piece);
        echangemenu.SetActive(false);
    }
    public void echange_fou()
    {
        
        controller = GameObject.FindGameObjectWithTag("GameController");
        game a = controller.GetComponent<game>();
        string fou;
        if (a.gettj() == 2)
            fou = "fou_blanc"; 
        else
            fou = "fou_noir"; 

        piece = a.Create(fou, x1, y1);
        a.setposition(piece);
        echangemenu.SetActive(false);
    }
    public void echange_cavalier()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");
        game a = controller.GetComponent<game>();
        string cavalier;
        if (a.gettj() == 2)
            cavalier = "cavalier_blanc";
        else
            cavalier = "cavalier_noir";
        piece = a.Create(cavalier, x1, y1);
        a.setposition(piece);
        echangemenu.SetActive(false);
    }
   
}
