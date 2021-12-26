using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class gamemanager : MonoBehaviour
{
    public float bookgamescore,scoreadd,scorethreshhold;
    public int chars,losethreshhold;
    public int side;
    public int gamestate;
    public float barfill;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        GameObject.FindGameObjectWithTag("barfill").GetComponent<Image>().fillAmount = barfill;
        if (side == 1)   
        {
            barfill = bookgamescore / 10;
           
                if(bookgamescore<0)
                {
                    gamestate -= 1;
                    bookgamescore = 10;
                }
                if(bookgamescore>10)
                {
                    gamestate += 1;
                    bookgamescore = 0;
                }
            if (gamestate < 2)
            { SceneManager.LoadScene(SceneManager.GetActiveScene().name); }

        }//barfill and state changer
        if (side == -1)
        {
            GameObject.FindGameObjectWithTag("barfill").GetComponent<Image>().color = Color.red;
            barfill = bookgamescore / -10;

            if (bookgamescore > 0)
            {
                gamestate += 1;
                bookgamescore = -10;
            }
            if (bookgamescore < -10)
            {
                gamestate -= 1;
                bookgamescore = 0;
            }

            if(gamestate>7)
            { SceneManager.LoadScene(SceneManager.GetActiveScene().name); }
        }//barfill and state changer bad side


    }
    public void incrementbook()
    {
        bookgamescore = bookgamescore + scoreadd;
    } 
    public void incrementgames()
    {
        bookgamescore = bookgamescore - scoreadd;
    }
    public void sidechoose1()
    {
        side = 1;
        Time.timeScale = 1;
    }   
    public void sidechoose2()
    {
        side = -1;
        Time.timeScale = 1;
    }    
}
