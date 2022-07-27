using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class FinPartie : MonoBehaviour
{   public GameObject controller; 
    public GameObject MenuFin;
    public Button Buttonquiter;
    public Text Winner; 
    // Start is called before the first frame update
    public void afficherfinpartie(int gagnant)
    {
        controller = GameObject.FindGameObjectWithTag("GameController");
        game a = controller.GetComponent<game>();
        a.setfinPartie(true); 
        MenuFin.SetActive(true);
        
        if (gagnant == 1)
            Winner.text = "Victoire : BLANC";
        else
            Winner.text = "Victoire : NOIR";
    }
    public void rejouer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        MenuFin.SetActive(false);
    }
    public void quitter()
    {
        Buttonquiter.interactable = false;
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
