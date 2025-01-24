using UnityEngine;

public class EggSystem : MonoBehaviour
{
    CapsuleCollider2D eggCollider;
    Animator animator;
    Rigidbody2D rb;

    BonusCore bonusCore;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        eggCollider = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        bonusCore = FindAnyObjectByType<BonusCore>();

        rb.gravityScale = bonusCore.gravity;
    }

  

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider != null)
        {
            if(collision.collider.tag == "Terrain" || collision.collider.tag == "Hunter")
            {
                eggCollider.enabled = false;
                animator.Play("Destruction");
            }
            
        }
    }
}
