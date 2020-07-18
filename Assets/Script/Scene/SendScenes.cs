using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SendScenes : MonoBehaviour
{
    public string scenename;//公開設定場景名稱
    int pointNumber=1;
    void Start()
    {
       
        this.gameObject.tag = "Wall";//該物件的標籤'Wall'
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
  
    public void changeScene() 
    {
       
            SceneManager.LoadScene(scenename);//轉跳到該場景
            CheckInit.starPoint = pointNumber;
        
       
    }
}
