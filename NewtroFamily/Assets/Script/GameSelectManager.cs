using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSelectManager : MonoBehaviour
{
    //UI
    public Button game1_btn, game2_btn,game3_btn,start_btn;

    //Resources
    public Sprite[] gamenum;

    //변수
    //public int count=0;
    public int[] gameflow=new int[3];
    public bool clear;
    //static int levelCount;


    public void Game1()
    {
        if(game2_btn.interactable==true && game3_btn.interactable==true)
        {
            game1_btn.GetComponent<Image>().sprite = gamenum[0];
            game1_btn.interactable = false;
        }
        else if((game2_btn.interactable==false && game3_btn.interactable==true)|| (game2_btn.interactable == true&&game3_btn.interactable==false))
        {
            game1_btn.GetComponent<Image>().sprite = gamenum[1];
            game1_btn.interactable = false;
        }
        else if(game2_btn.interactable==false && game3_btn.interactable == false )
        {
            game1_btn.GetComponent<Image>().sprite = gamenum[2];
            game1_btn.interactable = false;
            if (game1_btn.interactable == false && game2_btn.interactable == false && game3_btn.interactable == false)
            {
                start_btn.interactable = true;
                start_btn.GetComponent<Image>().sprite = gamenum[3];
            }
        }
    }
    public void Game2()
    {
        if (game1_btn.interactable == true && game3_btn.interactable == true)
        {
            game2_btn.GetComponent<Image>().sprite = gamenum[0];
            game2_btn.interactable = false;
            
        }
        else if ((game1_btn.interactable == false && game3_btn.interactable == true) || (game1_btn.interactable == true && game3_btn.interactable == false))
        {
            game2_btn.GetComponent<Image>().sprite = gamenum[1];
            game2_btn.interactable = false;
        }
        else if (game1_btn.interactable == false && game3_btn.interactable == false)
        {
            game2_btn.GetComponent<Image>().sprite = gamenum[2];
            game2_btn.interactable = false;
            if (game1_btn.interactable == false && game2_btn.interactable == false && game3_btn.interactable == false)
            {
                start_btn.interactable = true;
                start_btn.GetComponent<Image>().sprite = gamenum[3];
            }
        }
    }
    public void Game3()
    {
        if (game2_btn.interactable == true && game1_btn.interactable == true)
        {
            game3_btn.GetComponent<Image>().sprite = gamenum[0];
            game3_btn.interactable = false;
        }
        else if ((game2_btn.interactable == false && game1_btn.interactable == true) || (game2_btn.interactable == true && game1_btn.interactable == false))
        {
            game3_btn.GetComponent<Image>().sprite = gamenum[1];
            game3_btn.interactable = false;
        }
        else if (game2_btn.interactable == false && game1_btn.interactable == false)
        {
            game3_btn.GetComponent<Image>().sprite = gamenum[2];
            game3_btn.interactable = false;
            if(game1_btn.interactable == false && game2_btn.interactable == false && game3_btn.interactable == false)
            {
                start_btn.interactable = true;
                start_btn.GetComponent<Image>().sprite = gamenum[3];
            }
        }
     
    }

    public void GameStart(int num)
    {
        if(game1_btn.enabled==false&&game2_btn.enabled==false&&game3_btn.enabled==false)
        {
            switch (num)
            {
                case 1:
                    if (game1_btn.GetComponent<Image>().sprite = gamenum[0])
                    {
                        SceneManager.LoadScene("04_Game1");
                        if (clear == true)
                        {
                            if (game2_btn.GetComponent<Image>().sprite = gamenum[1])
                            {
                                clear = false;
                                SceneManager.LoadScene("05_Game2");
                                if (clear == true)
                                {
                                    clear = false;
                                    SceneManager.LoadScene("06_Game3");
                                }
                            }
                            else if (game3_btn.GetComponent<Image>().sprite = gamenum[1])
                            {
                                clear = false;
                                SceneManager.LoadScene("06_Game3");
                                if (clear == true)
                                {
                                    clear = false;
                                    SceneManager.LoadScene("05_Game2");
                                }
                            }

                        }
                    }
                    break;
                case 2:
                    if (game2_btn.GetComponent<Image>().sprite = gamenum[0])
                    {
                        SceneManager.LoadScene("05_Game2");
                        if (clear == true)
                        {
                            if (game1_btn.GetComponent<Image>().sprite = gamenum[1])
                            {
                                clear = false;
                                SceneManager.LoadScene("04_Game1");
                                if (clear == true)
                                {
                                    SceneManager.LoadScene("06_Game3");
                                }

                            }
                            else if (game3_btn.GetComponent<Image>().sprite = gamenum[1])
                            {
                                clear = false;
                                SceneManager.LoadScene("06_Game3");
                                if (clear == true)
                                {
                                    SceneManager.LoadScene("04_Game1");
                                }
                            }
                        }

                    }
                    break;
                case 3:
                    if (game3_btn.GetComponent<Image>().sprite = gamenum[0])
                    {
                        SceneManager.LoadScene("06_Game3");
                        if (clear == true)
                        {
                            if (game1_btn.GetComponent<Image>().sprite = gamenum[1])
                            {
                                clear = false;
                                SceneManager.LoadScene("04_Game1");
                                if (clear == true)
                                {
                                    SceneManager.LoadScene("05_Game2");
                                }
                            }
                            else if (game2_btn.GetComponent<Image>().sprite = gamenum[1])
                            {
                                clear = false;
                                SceneManager.LoadScene("05_Game2");
                                if (clear == true)
                                {
                                    SceneManager.LoadScene("04_Game1");
                                }
                            }

                        }
                    }
                    break;
            }
        }
     }

    }
    //변수
    /* Camera mainCam = null;
     private GameObject target;
     private Vector3 MousePos;
     private bool mousestate;

     private void Start()
     {
         mainCam = Camera.main;
     }
     private void Update()
     {
         if(true==Input.GetMouseButtonDown(0))
         {
             target = GetClickObject();

             if(target!=null)
             {
                 target.GetComponent<Image>().sprite = gamenum[0];
             }
            if(true==target.Equals(gameObject))
             {
                 target.GetComponent<Image>().sprite = gamenum[0];
                 // target.GetComponent<Image>().sprite=Resources.Load("1", typeof(Sprite)) as Sprite;
             }
         }
         if(true == mousestate)
         {
             transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
         }
         else
         {
             transform.localScale = new Vector3(1f, 1f, 1f);
         }
     }
    public void GameflowSet()
     {
         for(int i=0;i<3;i++)
         {
             if(Input.GetMouseButtonDown(0))
             {

             }
         }

         /*switch(num)
         {
             case 0:
                 if(jaegi_game.onClick.AddListener(() => Game1()))
                 {

                 }
                 break;
             case 1:
                 break;
         }

             //  jaegi_game.onClick.AddListener(()=>Game1());

             // jaegi_game = this.transform.GetComponent<Button>();

             /*if(jaegi_game.onClick.AddListener(Game1))
             {

             }


    private GameObject GetClickObject()
     {
         RaycastHit hit;
         GameObject target = null;

         Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);

         if (true == (Physics.Raycast(ray.origin, ray.direction * 10, out hit)))
         {
             target = hit.collider.gameObject;
         }

         return target;*/


