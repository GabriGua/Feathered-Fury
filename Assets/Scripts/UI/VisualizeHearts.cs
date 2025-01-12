using UnityEngine;

public class VisualizeHearts : MonoBehaviour
{
    [SerializeField] GameObject[] hearts;
    [SerializeField] LifePoints LifePoints;
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
