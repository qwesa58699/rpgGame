using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//使用遊戲引擎的介面


public class play : MonoBehaviour
{
   float speed = 1;//給予速度
    private bool isGround;//判斷是否在地板
    private int Max_SpeedX = 0;//最高限速
    private int Max_SpeedY = 0;//跳高的高度
    Rigidbody2D rigid;//鋼體變數
    public static int Hp = 0;//公開靜態血
    int Max_hp = 0;//最大血量
    public GameObject bulletPerfab;//連接預設物件(子彈)
    public Image play_bar;//連接畫面(血條)
    public Animator player_Ani;//動畫設定
    public SpriteRenderer playSr;//設定角色翻面
    public static bool fixX;
    public static bool isDead;
    
    void Start()
    {
        isDead=false;
        
        DontDestroyOnLoad(this.gameObject);//轉場景不要釋放該物件的數值
        
        rigid = this.gameObject.GetComponent<Rigidbody2D>();//設定鋼體的物件
        Max_SpeedX = 5;
        Max_SpeedY = 4;
        Max_hp = 10;
        Hp = Max_hp;
        

    }

    // Update is called once per frame
    void Update()
    {
        bool IsWalk = false;
        if (Hp == 0) 
        {
            isDead = true;
            Debug.Break();
        }
        //移動管理
         if (Input.GetKey ( KeyCode.RightArrow)) 
        {
            if (playSr.flipX == true)
            {
                playSr.flipX = false;
                fixX = false;
                
            }
           
            IsWalk = true;
        player_Ani.SetInteger("walk",1);
        rigid.velocity=new Vector2((10 * speed), 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (playSr.flipX == false) 
            {
                playSr.flipX = true;
                fixX = true;
            }
            IsWalk = true;
            player_Ani.SetInteger("walk", 1);
            rigid.velocity = new Vector2((-10 * speed), 0);
        }
        if (IsWalk)
        {
            if (player_Ani.GetInteger("walk") == 0)
            {
                player_Ani.SetInteger("walk", 1);
            }
        }
        else 
        {
            if (player_Ani.GetInteger("walk") == 1) 
            {
                player_Ani.SetInteger("walk", 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGround)//如果我按下空白建且沒有離開地板的話
        {
            rigid.AddForce(new Vector2(rigid.velocity.x,200000 ),ForceMode2D.Force);//我要使物件跳躍
           
            
                isGround = false;//離開地板 用來控制跳躍次數
            
        }
        
        if (Input.GetKeyDown(KeyCode.Z)) 
        {
            Instantiate(bulletPerfab, this.gameObject.transform.position, Quaternion.identity);//生成子彈
        }
        //限速機制
        if (rigid.velocity.x> Max_SpeedX) 
        {
            rigid.velocity = new Vector2(Max_SpeedX, rigid.velocity.y);
          
        }
        if (rigid.velocity.x < -Max_SpeedX) 
        {
            rigid.velocity = new Vector2(-Max_SpeedX, rigid.velocity.y);
        }
        if (rigid.velocity.y > Max_SpeedY) 
        {
            rigid.velocity = new Vector2(rigid.velocity.x, Max_SpeedY);
        }
        
    }
    
    void OnCollisionEnter2D(Collision2D coll) 
    {
        
        if (coll.gameObject.tag == "Floor") //如果碰到地板
        {
            isGround = true;//在地板上
        }
        if (coll.gameObject.tag == "Monster") //如果碰到怪物
        {
            print(coll.gameObject.name);
            Hp -= 2;//要扣血
           
        }
        if (coll.gameObject.tag == "Bullet") 
        {
            Hp -= 1;
        }
        play_bar.transform.localScale = new Vector3((float)Hp / (float)Max_hp, play_bar.transform.localScale.y, play_bar.transform.localScale.z);//血條扣血

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")//如果我碰到空氣牆
        {
            collision.gameObject.transform.GetComponent<SendScenes>().changeScene();//轉場景
          
        }
      
    }
}
    


