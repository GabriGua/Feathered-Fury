using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class BirdLife : MonoBehaviour
{
    BirdsSpawn birdsSpawn;
    BonusCore bonusCore;
    SpriteRenderer sR;
    public float life;
    float damage = 50;
    int speed;
   
    Rigidbody2D rb;
    BoxCollider2D bCol;

    //BirdBonus
  
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        bonusCore = FindAnyObjectByType<BonusCore>();
        birdsSpawn = FindAnyObjectByType<BirdsSpawn>();
        sR = GetComponent<SpriteRenderer>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        bCol = gameObject.GetComponent<BoxCollider2D>();
       

        bonusCore.OnBonusB_End += StopLowerSpeed;
        speed = bonusCore.speed;
        
        if (rb.position.x<0)
        { 
            rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);
            sR.flipX = true;
        }
        else
        {
            speed *= -1;
            sR.flipX = false;
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

                /*if (gameObject.tag == "Bird")
                {
                    rb.linearVelocity = Vector3.zero;
                    BirdsPool.Instance.ReturnBird(gameObject);
                    birdsSpawn.BirdDecount();
                }
                else
                { 
                    Destroy(gameObject);
                }*/
                Destroy(gameObject);

                bonusCore.OnBonusB_End -= StopLowerSpeed;
            }
        }
        else
        {
            /*if (gameObject.tag == "Bird")
            {
                rb.linearVelocity = Vector3.zero;
                BirdsPool.Instance.ReturnBird(gameObject);
                birdsSpawn.BirdDecount();
            }
            else
            { 
                Destroy(gameObject); 
            }*/
            Destroy(gameObject);
            bonusCore.OnBonusB_End -= StopLowerSpeed;
        }
    }

    private void OnDestroy()
    {
        if (birdsSpawn != null)
        {
            birdsSpawn.BirdDecount();
        }

        

    }


    public void StopLowerSpeed()
    {
        if (sR.flipX == true)
        {
            speed = bonusCore.speed;
        }
        else
        {
            speed = bonusCore.speed;
            speed *= -1;
        }

        

    }
}
