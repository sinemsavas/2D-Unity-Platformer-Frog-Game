using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//ROTATING THE IMAGE(SAW)
// z axis of rotate part should work for animation with CODE
public class Rotate : MonoBehaviour
{   
    //this value will define how many times we rotate image by 360 degrees per sec.
    //2 full rotation
    [SerializeField] private float speed = 2f;

    private void Update()
    {   //how much we want to rotate the image in axis.
        transform.Rotate(0,0,360*speed*Time.deltaTime);
    }
    
}
