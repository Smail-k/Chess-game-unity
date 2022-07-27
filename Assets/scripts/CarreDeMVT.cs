using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CarreDeMVT : MonoBehaviour
{
    public struct pos
    {
        public int x;
        public int y;
    };   
   // private  int xprisepass;
    //private int yprisepass; 
    public GameObject Echange;
    public GameObject Fin;
    public GameObject controller;
    private GameObject lapiesce_org; 
    public GameObject carreMVT;
    int x, y; 
    public bool attack=false;
    public bool priseenpassant = false; 
    public int x1;
    public int y1; 
    void start()
    {

        if (attack == true)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
            
        }

    }
    
    public void priseenpassantMvt()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");

        GameObject a = controller.GetComponent<game>().getposition(x1, y1);

        Destroy(a);

        controller.GetComponent<game>().viderlacase(x1, y1); 


    }
    // rook 
    public void testRook(GameObject piece)
    {
        if (controller.GetComponent<game>().gettj() == 2 && (piece.name == "tour_noire" || piece.name == "roi_noir"))
        {   if(piece.GetComponent<chessman>().getXboard()==0 && piece.name == "tour_noire")
                piece.GetComponent<chessman>().setrookgn(false);
            else if(piece.GetComponent<chessman>().getXboard() == 7 && piece.name == "tour_noire")
                    piece.GetComponent<chessman>().setrookpn(false);
           
            if (piece.name == "roi_noir")
            {
                piece.GetComponent<chessman>().setrookpn(false);
                piece.GetComponent<chessman>().setrookgn(false);

                if (piece.GetComponent<chessman>().getXboard() - x == 2 && piece.GetComponent<chessman>().getYboard() - y == 0)
                {
                    GameObject rook = controller.GetComponent<game>().getposition(0, y);

                    rook.GetComponent<chessman>().setXboard(x + 1);
                    rook.GetComponent<chessman>().setYboard(y);
                    rook.GetComponent<chessman>().setcoords();

                    //mise ajour de la matrice
                    controller.GetComponent<game>().setposition(rook);
                    destruirelescarres();
                    controller.GetComponent<game>().viderlacase(0, y);
                }
                else if (x-piece.GetComponent<chessman>().getXboard()==2 && piece.GetComponent<chessman>().getYboard() - y == 0)
                {
                    GameObject rook = controller.GetComponent<game>().getposition(x + 1, y);
                    rook.GetComponent<chessman>().setXboard(x - 1);
                    rook.GetComponent<chessman>().setYboard(y);
                    rook.GetComponent<chessman>().setcoords();
                    controller.GetComponent<game>().setposition(rook);
                    destruirelescarres();
                    controller.GetComponent<game>().viderlacase(7, y);
                }
                
            }

        }
        else if (controller.GetComponent<game>().gettj() == 1 && (piece.name == "tour_blanche" || piece.name == "roi_blanc"))
        {
            if (piece.GetComponent<chessman>().getXboard() == 0 && piece.name == "tour_blanche")
                piece.GetComponent<chessman>().setrookgb(false);
            else if (piece.GetComponent<chessman>().getXboard() == 7 && piece.name == "tour_blanche")
                piece.GetComponent<chessman>().setrookpb(false);

            if (piece.name == "roi_blanc")
            {
                piece.GetComponent<chessman>().setrookpb(false);
                piece.GetComponent<chessman>().setrookgb(false);

                if (piece.GetComponent<chessman>().getXboard() - x == 2 && piece.GetComponent<chessman>().getYboard() - y == 0) //rook grand 
                {
                    GameObject rook = controller.GetComponent<game>().getposition(0, y);

                    rook.GetComponent<chessman>().setXboard(x + 1);
                    rook.GetComponent<chessman>().setYboard(y);
                    rook.GetComponent<chessman>().setcoords();

                    //mise ajour de la matrice
                    controller.GetComponent<game>().setposition(rook);
                    destruirelescarres();
                    controller.GetComponent<game>().viderlacase(0, y);
                }
                else if (x - piece.GetComponent<chessman>().getXboard() == 2 && piece.GetComponent<chessman>().getYboard() - y == 0)
                {
                    GameObject rook = controller.GetComponent<game>().getposition(x + 1, y);
                    rook.GetComponent<chessman>().setXboard(x - 1);
                    rook.GetComponent<chessman>().setYboard(y);
                    rook.GetComponent<chessman>().setcoords();
                    controller.GetComponent<game>().setposition(rook);
                    destruirelescarres();
                    controller.GetComponent<game>().viderlacase(7, y);
                }

            }

        }
    }
    public bool check_Echange()
    {
        Echange = GameObject.FindGameObjectWithTag("echange");
        echange a = Echange.GetComponent<echange>();
        if(lapiesce_org.name=="pion_blanc" && y==7){
            controller.GetComponent<game>().viderlacase(x, y);
            Destroy(lapiesce_org); 
            a.afficher_echange(x,y);
            destruirelescarres();
            return true;
        }
        else if (lapiesce_org.name == "pion_noir" && y == 0)
        {
            controller.GetComponent<game>().viderlacase(x, y);
            Destroy(lapiesce_org);
            a.afficher_echange(x, y);
            destruirelescarres();
            return true;
        }
        return false; 
    }
    public void testermate(string roi)
    {
        controller = GameObject.FindGameObjectWithTag("GameController");
        chessman echec = lapiesce_org.GetComponent<chessman>();
        //place=echec.chercherroi(roi);
        game roii = controller.GetComponent<game>();
        int x=-1, y=-1; roii.chercherking(ref x, ref y, roi);
        if (roi.EndsWith("noir"))
        {
            if(echec.echecmate(x, y, false))
                {   
                    Fin = GameObject.FindGameObjectWithTag("Finish");
                    FinPartie a = Fin.GetComponent<FinPartie>();
                    a.afficherfinpartie(1); 
                }
        }
        else
        {

            if (echec.echecmate(x, y))
            {
                
                Fin = GameObject.FindGameObjectWithTag("Finish");
                FinPartie a = Fin.GetComponent<FinPartie>();
                a.afficherfinpartie(2);
            }
        }
       

    }



    void OnMouseUp()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");
        controller.GetComponent<game>().viderlacase(lapiesce_org.GetComponent<chessman>().getXboard(),
             lapiesce_org.GetComponent<chessman>().getYboard());

         

        //le cas de prise en passant si le joueur ne le fait pas exacetement apres le mvt de pions avec 2 on supprime la possibilité pour la prochaine fois 
        chessman pr = lapiesce_org.GetComponent<chessman>();
        pr.setxprise(-1);
        pr.setyprise(-1);
       

        
        
        if (attack)
        {
            GameObject a = controller.GetComponent<game>().getposition(x, y);
            game b = controller.GetComponent<game>();
            b.viderlacase(x, y);
            
            if (a.name == "roi_blanc" || a.name == "roi_noir")
            {
                Fin = GameObject.FindGameObjectWithTag("Finish");
                FinPartie fp = Fin.GetComponent<FinPartie>();
                 if (a.name == "roi_blanc")
                fp.afficherfinpartie(2); 
                 else
                     fp.afficherfinpartie(1); 
            }
            Destroy(a);
        }
        else if (priseenpassant)
            priseenpassantMvt();
if (!check_Echange()) { 
     if (lapiesce_org.name == "pion_blanc" && (y-lapiesce_org.GetComponent<chessman>().getYboard())== 2)
        {
            chessman cm = lapiesce_org.GetComponent<chessman>();
            cm.setxprise(x);
            cm.setyprise(y); 
        }
        else if (lapiesce_org.name == "pion_noir" && (lapiesce_org.GetComponent<chessman>().getYboard() - y) == 2)
        {
           
            chessman cm = lapiesce_org.GetComponent<chessman>();
            cm.setxprise(x);
            cm.setyprise(y);
        }
            testRook(lapiesce_org);

        lapiesce_org.GetComponent<chessman>().setXboard(x);
        lapiesce_org.GetComponent<chessman>().setYboard(y);
        lapiesce_org.GetComponent<chessman>().setcoords();

        //Update the matrix
        controller.GetComponent<game>().setposition(lapiesce_org);}
        /////check mate : 
        if (lapiesce_org.name.EndsWith("noir") || lapiesce_org.name.EndsWith("noire"))
        { 
            testermate("roi_noir");

        }
        else
        {
            testermate("roi_blanc");
        }
        destruirelescarres();
       
        controller.GetComponent<game>().jouer();
    }
   
    public void setpiesceorg(GameObject p)
    {
        lapiesce_org = p;
    }
    public void SetCoords(int x1, int y1)
    {
        x = x1;
        y = y1;
    }
    public GameObject getpiesceorg()
    {
        return lapiesce_org;
    }
    public void destruirelescarres()
    {
        GameObject[] Carres = GameObject.FindGameObjectsWithTag("CarredeMvt");
        for (int i = 0; i < Carres.Length; i++)
        {
            Destroy(Carres[i]); 
        }
    }

    



}