using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class firstScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
