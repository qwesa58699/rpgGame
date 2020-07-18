using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletControl : MonoBehaviour
{

     float timer = 0;
     bool directionShot;
     

    void Start()
    {
        timer = 1;
        directionShot = play.fixX;
        ShotDirection();
        
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
        if (gameObject.tag=="Monster") 
        {
            Destroy(this.gameObject);
        }
    }
      void ShotDirection()
    {
        if (directionShot == false)
        {

            this.GetComponent<Rigidbody2D>().AddForce(new Vector3(80 * Time.deltaTime * 60, 0, 0), ForceMode2D.Impulse);//物理移動   
        }
        else
        {
            
            this.GetComponent<Rigidbody2D>().AddForce(new Vector3(-80 * Time.deltaTime * 60, 0, 0), ForceMode2D.Impulse);//物理移動 
        }

    }

}
   
