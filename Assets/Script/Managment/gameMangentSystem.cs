using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//使用遊戲影情中的場景管理

public class gameMangentSystem : MonoBehaviour
{
    GameObject playEnd;
    void Start()
    {
        playEnd = GameObject.Find("Meun-playDead");

        playEnd.SetActive(false);
        


    }

    // Update is called once per frame
    void Update()
    {
        if (play.isDead == true) 
        {
            playEnd.SetActive(true);
        }

    }
   
    public void GameStar() 
    {
        SceneManager.LoadScene("level-1");//轉場景到重置玩家場景
    }
    public void ExitGame()
    {
        Application.Quit();//離開應用程式
    }
}
