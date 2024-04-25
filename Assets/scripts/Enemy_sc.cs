using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_sc : MonoBehaviour
{
    public int hp = 100;
    public bool can_attack = true;
    public int dmg = 25;
    public ParticleSystem particleSystem1;
    public float attack_speed = 3;
    private Base_script base_sc;


    void Start()
    {
        particleSystem1 = gameObject.GetComponent<ParticleSystem>();
    }


    void Attack()
    {
        if(can_attack == true & base_sc != null)
        {         
            base_sc.hp -= dmg;
            can_attack = false;    
        
        }

    }



    void Update()
    {
        Attack();
        attack_speed -= Time.deltaTime;
        if (attack_speed <= 0)
        {
            can_attack = true;
            attack_speed = 3;
        }


        if(hp <= 0)
        {
            particleSystem1.Play();            
            
            Destroy(gameObject,particleSystem1.main.duration);

        }
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        
        if (other.tag == "Baza")
        {
            base_sc = other.GetComponent<Base_script>();
        }


    }

}
