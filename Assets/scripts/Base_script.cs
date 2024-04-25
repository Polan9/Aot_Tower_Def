using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base_script : MonoBehaviour
{
    
    public int hp = 1000;
    
    

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log(hp);
        }
    }
}
