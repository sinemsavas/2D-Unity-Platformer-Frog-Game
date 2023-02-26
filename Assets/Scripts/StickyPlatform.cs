using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{ 
//layer set as ground on unity, so we can jump on platform

//stickyplatform as class
/*

  //entering the platform
    private void OnCollisionEnter2D(Collision2D collision)
    {   //this will executed if the sticky platform collides with another collider and
        //if this other collider has the name Player.
        //Tag'a gerek yok çünkü 1 tane player'ımız var.
        if(collision.gameObject.name == "Player")
        {   //this will set player as a child of this platform
            //player GameObject to follow the movements of this GameObject, creating a sticky platform effect.
            collision.gameObject.transform.SetParent(transform);
        }
    }

    //leaving the platform
    //method is calles when another collider exits the collider attached to platform.
    private void OnCollisionExit2D(Collision2D collision)
    {   
        if(collision.gameObject.name == "Player")
        {   //we want to remove the parent as null, means no value
            //this is no longer a child of any other gameobject,
            //so it means that player to move independently from moving platform, breaks sticky platform effect.
            collision.gameObject.transform.SetParent(null);
        }
    }
    */
//we dont want this part because, we dont want anything to happen when we touch the outer parts.


    //ontrigger allowing a respond to the collision in code
    //using on; opening doors, picking up items, triggering cutscenes.
    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if(collision.gameObject.name == "Player")
        {   
            collision.gameObject.transform.SetParent(transform);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {   
        if(collision.gameObject.name == "Player")
        {   //we want to remove the parent as null, means no value
            //this is no longer a child of any other gameobject,
            //so it means that player to move independently from moving platform, breaks sticky platform effect.
            collision.gameObject.transform.SetParent(null);
        }

    }
}
