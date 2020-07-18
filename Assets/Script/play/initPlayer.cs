using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class initPlayer : MonoBehaviour//來初始化角色
{
    public string starName;//公開設定字串 (level-1)
    void Start()
    {
        if (CheckInit.deBugScenName == null)//如果場景名稱是空白的
        {
            SceneManager.LoadScene(starName);//轉跳到設定場景(level-1)
        }
        else //相反
        {
            SceneManager.LoadScene(CheckInit.deBugScenName);//轉跳到該場景畫面;
            CheckInit.deBugScenName = null;//轉完再釋放出來
        }
       
    }

}
