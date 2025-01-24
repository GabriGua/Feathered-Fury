using UnityEngine;

public class VisualizeHearts : MonoBehaviour
{
    [SerializeField] GameObject[] hearts;
    [SerializeField] LifePoints LifePoints;

    [SerializeField] GameObject EmptyHearts;
    [SerializeField] GameObject EmptyHearts2;
    int counterLife = 6;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        UpdateHearts();
    }

    // Update is called once per frame
    void Update()
    {

        // Aggiorna i cuori solo quando il numero di vite cambia
        if (LifePoints.life != counterLife)
        {
            UpdateHearts();
            if (LifePoints.life > 6 && LifePoints.life <= 8 && EmptyHearts.activeInHierarchy == false)
            {
                EmptyHearts.SetActive(true);

            }
            else if (LifePoints.life > 8 && LifePoints.life <= 10 && EmptyHearts2.activeInHierarchy == false)
            {
                {
                    EmptyHearts2.SetActive(true);
                }

            }
            counterLife = LifePoints.life;
        }
    }

    void UpdateHearts()
    {
        // Aggiorna lo stato di ogni cuore in base al numero di vite attuali
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].SetActive(i < LifePoints.life);

        }
    }
}