using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    private int counter = 0;

    [SerializeField] private TextMeshProUGUI counterText;

    [SerializeField] private AudioSource collectionSoundEffect;

   private void OnTriggerEnter2D(Collider2D collision)
   {
        if(collision.gameObject.CompareTag("Fruits"))
        {  
            collectionSoundEffect.Play();
            //Destroy fruit when collide
            Destroy(collision.gameObject);
            counter++;
            //Debug.Log("Collected: " + counter );
            counterText.text = "Counter: " + counter;
        }
   }
   

}
