using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class game : MonoBehaviour
{
    public GameObject menudebut; 
    public GameObject chesspiece;
    private GameObject[,] plateau = new GameObject[8, 8]; 
    private GameObject[] joueurNoir =new GameObject [16];
    private GameObject[] joueurBlanc =new GameObject [16];
    private bool FinPartie=false; 
    private int tj=1;
    
    
    public void charger()
    {   menudebut.SetActive(false);            
            int i = 0, k = 0;
            string[] pieces = new string[32];

            StreamReader sr = new StreamReader("echec.txt");
            while (!sr.EndOfStream)
            {
                pieces = sr.ReadLine().Split(',');
                int x = int.Parse(pieces[1]); int y = int.Parse(pieces[2]);
                if (pieces[0].EndsWith("noir") || pieces[0].EndsWith("noire"))
                {
                    joueurNoir[i] = Create(pieces[0], x, y);  setposition2(joueurNoir[i], x, y);i++;
                }
                else
                {
                    joueurBlanc[k] = Create(pieces[0], x, y);  setposition2(joueurBlanc[k], x, y);k++;
                }

            }
        }
    
    public void nvpartie()
    {menudebut.SetActive(false);
        joueurNoir = new GameObject[]{
            Create("tour_noire",0,7),Create("cavalier_noir",1,7),Create("fou_noir",2,7),Create("reine_noire",3,7),
            Create("roi_noir",4,7),Create("fou_noir",5,7),Create("cavalier_noir",6,7),Create("tour_noire",7,7) ,
            Create("pion_noir",0,6),Create("pion_noir",1,6),Create("pion_noir",2,6),Create("pion_noir",3,6),
            Create("pion_noir",4,6),Create("pion_noir",5,6),Create("pion_noir",6,6),Create("pion_noir",7,6)
        };

        joueurBlanc = new GameObject[]{
            Create("tour_blanche",0,0),Create("cavalier_blanc",1,0),Create("fou_blanc",2,0),Create("reine_blanche",3,0),
            Create("roi_blanc",4,0),Create("fou_blanc",5,0),Create("cavalier_blanc",6,0),Create("tour_blanche",7,0),
            Create("pion_blanc",0,1),Create("pion_blanc",1,1),Create("pion_blanc",2,1),Create("pion_blanc",3,1),
            Create("pion_blanc",4,1),Create("pion_blanc",5,1),Create("pion_blanc",6,1),Create("pion_blanc",7,1)
        };
        for (int i = 0; i < 16; i++)
        {
            setposition(joueurNoir[i]);
            setposition(joueurBlanc[i]);
        } 
    }


    // Start is called before the first frame update
    void Start()
    {
        menudebut.SetActive(true);
        
        } 
    
   public GameObject Create(string nompiece,int x,int y) {
       GameObject obj = Instantiate(chesspiece, new Vector3(0, 0, -2), Quaternion.identity);
       chessman cm = obj.GetComponent<chessman>();
       cm.name = nompiece;
       cm.setXboard(x); // cree la piece dans la place convenable 
       cm.setYboard(y);
       cm.activer();
       return obj; 
        }
    public void setposition(GameObject obj){
        chessman cm=obj.GetComponent<chessman>();
        plateau[cm.getXboard(), cm.getYboard()]=obj;
        
    }
    public void setposition2(GameObject obj,int x,int y){
         plateau[x, y]=obj;
    }
    public GameObject getposition(int x, int y)
    {
        return plateau[x,y]; 
    }
    public bool PositionDansPlateau(int x,int y){
        if (x < 0 || y < 0 || x >= plateau.GetLength(0) || y >= plateau.GetLength(1))
            return false;
        return true; 
    }
    public int gettj()
    {
        return tj; 
    }
    public bool GetfinPartie()
    {
        if (FinPartie)
            return true;
        else return false; 
    }
    public void setfinPartie(bool fp)
    {
        FinPartie=fp; 
    }
    public void jouer()
    {
        if (tj == 2)
            tj = 1;
        else tj = 2; 
    }
    public void viderlacase(int x,int y)
    {
        plateau[x, y] = null; 
    }
    public void chercherking(ref int  x,ref int  y,string roi){
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if(getposition(i,j)!=null && getposition(i,j).name==roi)
                {
                    x = i; y = j;
                    i = 8; j = 8;
                }
            }
        }
    }
     public void Update()
    {
        //Debug.Log("afen");
         if (tj == 1)
        {
            //GameObject.FindGameObjectWithTag("Player").GetComponent<Text>().enabled=true;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Text>().text = "          Tour : Blanc";
        }
         else 
         {
             GameObject.FindGameObjectWithTag("Player").GetComponent<Text>().text = "          Tour : Noir";

         }
         if(FinPartie)
             GameObject.FindGameObjectWithTag("Player").GetComponent<Text>().text = "          Fin Partie";

     }
    // Update is called once per frame
    // public void SetPositionEmpty(int x, int y)
    //{
    //  position[x, y] = null;
    //}
}
