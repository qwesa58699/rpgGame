using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMonster : MonoBehaviour
{  
    float timer = 0;
    bool directionShot;
    SpriteRenderer bulletFace;
 
    void Start()
    {
        timer = 0.5f;
        directionShot =MonsterScript.isFace;
        ShotDirection();
        bulletFace = this.transform.GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        //子彈消除機制
        if (timer <= 0)
        {
            Destroy(this.gameObject);
        }
        if (gameObject.tag == "player")
        {
            Destroy(this.gameObject);
        }
    }
     void ShotDirection()
    {
        if (directionShot == false)
        {
            this.GetComponent<Rigidbody2D>().AddForce(new Vector3(-80 * Time.deltaTime * 60, 0, 0), ForceMode2D.Impulse);//物理移動   
        }
        else
        {
  
            this.GetComponent<Rigidbody2D>().AddForce(new Vector3(+80 * Time.deltaTime * 60, 0, 0), ForceMode2D.Impulse);//物理移動 
        }

    }


}
