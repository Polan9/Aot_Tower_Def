using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    public int speed = 100;

    private Vector2 wektor2;
    private Vector3 wektor3;
    private Vector2 smoothdampvelocity;

    [SerializeField]
    private float Soomthinputspeed = 0.2f;

    private Vector2 CurrentVector;

    private CharacterController controller;


    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }



    private void movement()
    {
        var axis = Input.GetAxis("Vertical");

        var axis2 = Input.GetAxis("Horizontal");


        wektor2 = new Vector2(axis,axis2);

        CurrentVector = Vector2.SmoothDamp(CurrentVector, wektor2, ref smoothdampvelocity, Soomthinputspeed);

        wektor3 = new Vector3(CurrentVector.y,0,CurrentVector.x);        


        controller.Move(wektor3 * Time.deltaTime * speed);

    }



                           
//                           #a * (1.0 - f) + b * f



    void Update()
    {
        movement();


    }
}
