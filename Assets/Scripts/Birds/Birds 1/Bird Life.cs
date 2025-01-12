using Unity.VisualScripting;
using UnityEngine;


public class BirdLife : MonoBehaviour
{
    BirdsSpawn birdsSpawn;
    SpriteRenderer sR;
    public float life;
    float damage = 50;
    int speed = 10;
    Rigidbody2D rb;
    BoxCollider2D bCol;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        birdsSpawn = FindAnyObjectByType<BirdsSpawn>();
        sR = GetComponent<SpriteRenderer>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        bCol = gameObject.GetComponent<BoxCollider2D>();

        if (rb.position.x<0)
        { 
            rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);
            sR.flipX = true;
        }
        else
        {
            speed *= -1;
            rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y); 
        }
    }

   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider!=null)
        {
            if (collision.collider.tag == "RightWall")
            {  
                speed *= -1;
                rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);
                sR.flipX = false;
            }
            if (collision.collider.tag == "LeftWall")
            {  
                speed *= -1;
                rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);
                sR.flipX = true;
            }

        }
    }

    public void HitReceived()
    {
        if (life > 0)
        {
            life = life - damage;

            if(life <= 0)
            {
                
                Destroy(gameObject);
            }
        }
        else
        {
            
            Destroy(gameObject);
        }
    }
    
    private void OnDestroy()
    {
            if (birdsSpawn != null)
            { 
                birdsSpawn.BirdDecount(); 
            }
            
    }
    
    
}
