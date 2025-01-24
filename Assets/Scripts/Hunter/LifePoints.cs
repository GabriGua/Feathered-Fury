using UnityEngine;

public class LifePoints : MonoBehaviour
{
    [SerializeField] ExplosiveArea ExplosiveArea;
    [SerializeField] GameObject playButton;
    [SerializeField] ResetAnimation ResetAnimation;
    [SerializeField] BirdsSpawn birdsSpawn;
    public int life = 6;
    int counterlife = 6;
    public bool GameOver=false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    private void Awake()
    {
        Time.timeScale = 1f;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(life>counterlife)
        {
            life = counterlife;
        }
        else if (life == 0)
        {
            
            GameOver = true;
        }
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider != null)
        {
            //Normal Egg
            if (collision.collider.tag == "Egg")
            {
                if(counterlife > 0)
                {
                    counterlife--;
                    IsDead();
                }
                
            }
            //Explosive Egg
            if (collision.collider.tag == "XEgg")
            {
                if (counterlife > 0)
                {
                    counterlife--;
                    counterlife--;
                    counterlife--;
                    IsDead();
                }

            }

        }
    }
    //Explosive egg
    public void FirstCircle()
    {
        
        counterlife--;
        IsDead();

    }
    public void SecondCircle()
    {
        
        counterlife--;
        IsDead();
    }

    void IsDead()
    {
        if(counterlife <= 0)
        {
            birdsSpawn.StopCoroutines();
            ResetAnimation.MoveToScene(2);
            
        }
    }

    public void AddHeart()
    {
        if (life > 0 && life < 10 && life != 9)
        {

            life = life + 2;
            counterlife = counterlife + 2;
        }
        else if (life == 9)
        {
            life++;
            counterlife++;
        }

    }
}
