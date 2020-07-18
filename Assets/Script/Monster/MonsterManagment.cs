using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManagment : MonoBehaviour
{
    public float speed;//給予速度
    public static bool isFace;//判斷方向
    protected float timer;//快取時間
    protected float shootTime=0.3f;
    protected float shootNeedTimer = 0.3f;
    protected int Hp = 0;
    protected int Max_hp = 0;
    protected float dectionPostition;
    protected Vector3 initPosition;
    public GameObject bulletPab;//攻擊:子彈
    public GameObject hp_bar;//血條
    public Collider2D wall_right;//傳送牆
    public Collider2D wall_left;
    protected Transform monsterTransform;//快取怪物座標
    public Transform playUnit;//快取玩家座標
    public static SpriteRenderer trunFace;//怪物轉頭
    protected enum Status { idle, walk, atk };//存取狀態欄
    protected Status status;
    private float diatanceToPlayrer;
  
    protected void statusManagment() //狀態管理方法
    {
        dectionPostition = Mathf.Abs(playUnit.position.x - monsterTransform.position.x);




        switch (status)//判斷狀態
        {

            case Status.idle:

                if (dectionPostition > 8f)
                {

                    status = Status.walk;//行走
                }

                break;

            case Status.walk://走路狀態

                if (monsterTransform.position.x >= playUnit.position.x)//判斷向左走還是向右走
                {
                    isFace = false;//左走
                    trunFace.flipX = false;//面向左
                    monsterTransform.position -= new Vector3(speed * timer, 0, 0);
                }
                else
                {
                    isFace = true;//右走
                    trunFace.flipX = true;//面向右
                    monsterTransform.position += new Vector3(speed * timer, 0, 0);
                }
                switch (isFace)//走路的方向 
                {
                    case false:
                        monsterTransform.position -= new Vector3(speed * timer, 0, 0);
                        break;
                    case true:
                        monsterTransform.position += new Vector3(speed * timer, 0, 0);
                        break;
                }
                if (dectionPostition < 6f && dectionPostition >= 5)
                {
                    status = Status.atk;

                }
                if (Mathf.Abs(playUnit.position.x - monsterTransform.position.x) >= 8f)
                { 
                    status = Status.idle;
                }
                break;

            case Status.atk:

                AIshoot();
                if (dectionPostition >= 6f)
                {
                    status = Status.walk;

                }
                break;
        }
    }
    void AIshoot() 
    {
        if (shootTime <= 0) 
        {
            shootTime = shootNeedTimer;
            Instantiate(bulletPab, this.gameObject.transform.position, Quaternion.identity);//生成子彈

        }
        else
        {
            shootTime -= Time.deltaTime;
        }
    }
   
}
