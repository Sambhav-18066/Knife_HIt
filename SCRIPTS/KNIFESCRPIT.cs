using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KNIFESCRPIT : MonoBehaviour
{
    [SerializeField]
    private Vector2 throwForce;

    private bool isActive = true;

    private Rigidbody2D rb;

    private BoxCollider2D knifeColider;

    public score score;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        knifeColider = rb.GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0)&& isActive)
        {
            rb.AddForce(throwForce, ForceMode2D.Impulse);
            rb.gravityScale = 1;
            GameController.instance.GameUI.decrementDisplayKniveCount();

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isActive)
            return;

        isActive = false;

        if (collision.collider.tag == "Log")
        {
         
            GetComponent<ParticleSystem>().Play();

            rb.velocity = new Vector2(0, 0);
            rb.bodyType = RigidbodyType2D.Kinematic;
            this.transform.SetParent(collision.collider.transform);


            knifeColider.offset = new Vector2(knifeColider.offset.x, -0.4f);
            knifeColider.size = new Vector2(knifeColider.size.x, 1.2f);
           
            GameController.instance.OnSuccessfulKniveHit(           
            GameController.instance.GetV());

            
            

        }

       

        else if (collision.collider.tag == "Knife")
        {
            rb.velocity = new Vector2(rb.velocity.x, -2);
            GameController.instance.StartGameOverSequence(false);
        }

    }
}  


