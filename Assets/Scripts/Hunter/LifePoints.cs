using UnityEngine;

public class LifePoints : MonoBehaviour
{
    [SerializeField] ExplosiveArea ExplosiveArea;
    public int life = 6;
    int counterlife = 6;
    public bool GameOver=false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
                }

            }

        }
    }
    //Explosive egg
    public void FirstCircle()
    {
        
        counterlife--;

    }
    public void SecondCircle()
    {
        
        counterlife--;
    }
}
