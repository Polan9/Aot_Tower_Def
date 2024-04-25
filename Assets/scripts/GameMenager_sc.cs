using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameMenager_sc : MonoBehaviour
{
    
    public int gold = 100;
    
    
    public Vector2 mousepos;

    public GameObject gunner;



    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit , 100))
            {
                print("Hit something!");
                Instantiate(gunner,hit.point, hit.transform.rotation);
                Debug.DrawLine(ray.origin,hit.point);
                Debug.Log(hit.collider.name);
            }
        }
    }
}
