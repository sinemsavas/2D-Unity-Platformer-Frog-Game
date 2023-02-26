using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{   private Rigidbody2D rb;
    private Animator anim;//switching death animation


    [SerializeField] private AudioSource deathSoundEffect;

    // Start is called before the first frame update
    void Start()
    {   
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
            if ( collision.gameObject.CompareTag("Trap"))//equal sign creates error so CompareTag is efficient.
            {   
                
                Die();

            }
    }

    private void Die()
    {  
        deathSoundEffect.Play();
        //Set Rigidbody dynamic to static
        rb.bodyType = RigidbodyType2D.Static;

        //setting trigger which we called death
        anim.SetTrigger("death");
        
    }

    private void RestartLevel()
    {   //Loading current scene(level)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
