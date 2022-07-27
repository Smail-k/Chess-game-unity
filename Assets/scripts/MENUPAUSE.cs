using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; 
public class MENUPAUSE : MonoBehaviour
{
    public GameObject controller; 
    public GameObject MenuPause;
    public static bool pause = false; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pause)
                continuer();
            else
                Pause(); 
        } 

    }
    public void continuer()
    {
        MenuPause.SetActive(false);
        Time.timeScale = 1f;
        pause = false; 
    }

    public void Pause()
    {
        MenuPause.SetActive(true);
        Time.timeScale = 0f;
        pause = true; 
    }
    public void sauvegarder()
    {
        StreamWriter sw = new StreamWriter("echec.txt");
        controller = GameObject.FindGameObjectWithTag("GameController");
        game a = controller.GetComponent<game>();
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (a.getposition(i, j) != null)
                    sw.WriteLine(a.getposition(i, j).name + "," + i + "," + j);              
            }
        }
        sw.Close();
    }




}
