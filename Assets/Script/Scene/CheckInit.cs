using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckInit : MonoBehaviour
{
   public static string deBugScenName;//用來存取當前的場景
    public static int starPoint;
     GameObject playObject;
   
    void Start()
    {
        playObject = GameObject.Find("player");
        if (!playObject) //如果找不到玩家物件
        {
            SceneManager.LoadScene("initScene");//轉跳到初始化玩家場景
            deBugScenName = SceneManager.GetActiveScene().name;//存取當前場景的名稱      
        }
        if (starPoint != 0) 
        {
            GameObject X = GameObject.Find(starPoint.ToString()) as GameObject;//設定起始點的物件名稱
        if (X != null) //如果有東西
         {
                playObject.transform.position = X.transform.position;//玩家起始座標更動
         }
            starPoint = 0;//釋放起始點
        }
        
    }

    
}
