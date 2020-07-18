using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unDestory : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        deGameObject();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void deGameObject() 
    {
        DontDestroyOnLoad(this.gameObject);
    }
}

