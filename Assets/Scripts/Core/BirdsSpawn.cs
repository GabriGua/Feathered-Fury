using UnityEngine;
using System.Collections;

public class BirdsSpawn : MonoBehaviour
{
    [SerializeField] VisualizeRounds visualizeRounds;

    [SerializeField] private GameObject birds;
    [SerializeField] private GameObject BlueBirds;
    private int round = 1;
    int redBird, blueBird;
    int countred = 0, countblue = 0;
    int totalbird = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FirstRound();
    }

    void FirstRound()
    {
        redBird = 4;
        blueBird = 2;
        StartCoroutine(SpawningBirds(redBird));
        StartCoroutine(SpawningBlueBirds(blueBird));

    }
    void NextRound()
    {
        redBird = CoreRoundSystem(round)/3*2;
        blueBird = redBird / 2;
        Debug.Log(redBird);
        StartCoroutine(SpawningBirds(redBird));
        StartCoroutine(SpawningBlueBirds(blueBird));
    }

    //Red Bird
    IEnumerator SpawningBirds(int bird)
    {
        countred = 0;
        while (countred < bird) // Loop infinito
        {
            totalbird++;
            int randomDelay = Random.Range(1, 4);
            yield return new WaitForSeconds(randomDelay);

            int randomSide = Random.Range(1, 3);

            if (randomSide == 1)
            {
                float randomY = Random.Range(1f, 4.1f);
                Vector3 spawnPosition = new Vector3(-7.5f, randomY, 0);
                Instantiate(birds, spawnPosition, Quaternion.identity);
                countred++;
            }
            else
            {
                float randomY = Random.Range(1f, 4.1f);
                Vector3 spawnPosition = new Vector3(7.5f, randomY, 0);
                Instantiate(birds, spawnPosition, Quaternion.identity);
                countred++;
            }
        }
        

    }

    //Blue Bird

    IEnumerator SpawningBlueBirds(int blue)
    {
        countblue = 0;
        while (countblue < blue) // Loop infinito
        {
            totalbird++;
            int randomDelay = Random.Range(1, 4);
            yield return new WaitForSeconds(randomDelay);

            int randomSide = Random.Range(1, 3);

            if (randomSide == 1)
            {
                float randomY = Random.Range(2.5f, 4.1f);
                Vector3 spawnPosition = new Vector3(-7.5f, randomY, 0);
                Instantiate(BlueBirds, spawnPosition, Quaternion.identity);
                countblue++;
            }
            else
            {
                float randomY = Random.Range(2.5f, 4.1f);
                Vector3 spawnPosition = new Vector3(7.5f, randomY, 0);
                Instantiate(BlueBirds, spawnPosition, Quaternion.identity);
                countblue++;
            }
        }
        

    }

    public void BirdDecount()
    {
        if (totalbird > 0)
        { totalbird--; }
        
        if (totalbird <= 0)
        {
            round++;
            NextRound();
            visualizeRounds.NextRound();
        }
    }
    public int CoreRoundSystem(float x, float maxValue = 40f, float speed = 6f)
    {
        // Evita divisione per zero
        if (x + speed == 0)
        {
            Debug.LogWarning("Divisione per zero evitata. Assicurati che (x + speed) non sia zero.");
            return 0;
        }

        // Calcola il valore iperbolico e arrotonda all'intero più vicino
        float rawValue = (maxValue * x) / (x + speed);
        return Mathf.RoundToInt(rawValue);
    }
    private void Update()
    {
        
        Debug.Log("Total Bird: " + totalbird);
        Debug.Log("Total Round: " + round);
        Debug.Log("Total Reds: " + redBird);
    }
}