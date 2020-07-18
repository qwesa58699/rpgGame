using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MonsterScript :MonsterManagment    
{


    GameObject GO ;//喧染畫面
    
    
    void Start()
    {
        trunFace = this.transform.GetComponent<SpriteRenderer>();//抓取座標物件的元件(SpriteRenderer)
        monsterTransform = this.transform;//快取物件座標
        status =Status.idle;
        GO = GameObject.Find("title");//尋找物件名稱
        Max_hp = 10;
        Hp = 10;
        // 是否場景轉換
        wall_right.isTrigger = false;
        wall_left.isTrigger = false;
        isFace = this.gameObject.GetComponent<SpriteRenderer>().flipX;//抓取元件的屬性
        timer = Time.deltaTime;//快取時間方法
        if (GameObject.Find("player") != null)//判斷是否抓到玩家的物件 
        { 
            playUnit = GameObject.Find("player").transform;//沒有要去找到玩家物件
        }

    }
    [System.Obsolete]
    // Update is called once per frame
    void Update()
    {

        MonsterDie();
        statusManagment();
    }

    [System.Obsolete]
    private void MonsterDie() 
    {
        //角色死亡
        if (Hp == 0)
        {
            GO.gameObject.SetActiveRecursively(true);//將Canvas中的子類別顯示出來
            Destroy(this.gameObject);//刪除這個物件
            wall_right.isTrigger = true;//傳送裝置開啟(穿透碰撞)
            wall_left.isTrigger = true;
        }

        hp_bar.transform.localScale = new Vector3(((float)Hp / (float)Max_hp), hp_bar.transform.localScale.y, hp_bar.transform.localScale.z);//血條扣血
    }

   

    private void OnTriggerEnter2D(Collider2D coll)
    {
        //被子彈打到
        if (coll.gameObject.tag == "Bullet")
        {
            Hp -= 1;
            print(Hp);
            Destroy(coll.gameObject);//子彈打到物件消除
        }

    }
    
}

