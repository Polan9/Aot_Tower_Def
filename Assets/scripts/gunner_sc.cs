using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UIElements;

public class gunner_sc : MonoBehaviour
{
    public int dmg = 15;
    public int rangex;
    public int rangez;
    public BoxCollider detection_area;
    private float firerate = 5f; 
    private bool can_shoot = true;
    private Vector3 enemyPos;

    private bool enemy_detected;

    public int index = 0; //index for iterating on enemies

    List<GameObject> enemies_list = new List<GameObject>();

    public ParticleSystem particlesys;

    public Light muzzle;

    public float light_timer = 1;    
    public void logic()
    {
        
        
        //Debug.Log(index);


        try{
            
            if (enemies_list[index] == null){
            index += 1;
        }else
        {
         
            if(enemies_list[index].tag == "Enemy")
            {
                enemyPos = enemies_list[index].gameObject.transform.position;
                
                if(enemies_list[index].tag == "Enemy" & can_shoot == true & enemies_list[index] != null)
                {
                    Debug.Log("i see an enemy");
                    enemy_detected = true;
                        
                    var enemies_sc = enemies_list[index].GetComponent<Enemy_sc>();
                    enemies_sc.hp -= dmg;
                    
                    
                    particlesys.Play();
                    muzzle.enabled = true;
                    can_shoot = false;
                    
                    if (light_timer <= 0)
                    {
                        light_timer = 1;
                        muzzle.enabled = false;
                    }
                    
                    if (enemies_sc.hp <= 0)
                    {
                        index += 1;
                    }
                    
                    
                    Debug.Log(enemies_sc.hp);
                            
                }
           
                        
            
            }
        }

        }catch (ArgumentOutOfRangeException)
        {
           
        }

        
        
        
    }

    void Start()
    {
        detection_area = gameObject.GetComponent<BoxCollider>();
        detection_area.size = new Vector3(rangex, 3, rangez); 
        particlesys = gameObject.GetComponent<ParticleSystem>();
        muzzle.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
     
        light_timer -= Time.deltaTime;


        if (enemy_detected == true){
            gameObject.transform.LookAt(enemyPos);
            
        }
        
        if (can_shoot == false)
            firerate -= Time.deltaTime;
            
            if (firerate <= 0)
            {
                can_shoot = true;
                firerate = 5;
            }

        logic();
    
    }



   private void OnTriggerStay(Collider other)
    {

    }





    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Enemy")
        {
            enemies_list.Add(collider.gameObject);
        }
        
    }
    
    
    



/*
            foreach(GameObject i in enemies_list)
        {
            if(other.name == "Enemy")
            {
                enemyPos = other.gameObject.transform.position;
            }
            
            if(other.name == "Enemy" & can_shoot == true)
            {
                Debug.Log("i see an enemy");
                enemy_detected = true;
                
                var enemies_sc = other.GetComponent<Enemy_sc>();
                enemies_sc.hp -= dmg;
                can_shoot = false;
                Debug.Log(enemies_sc.hp);
                Debug.Log(other);
                
            }
        }
*/}