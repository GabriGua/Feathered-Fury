using System.Collections.Generic;
using UnityEngine;

public class BirdsPool : MonoBehaviour
{
    public static BirdsPool Instance;

    public GameObject birdPrefab;
    public int poolSize = 40;

    private List<GameObject> birdPool;

    public GameObject birdContainer; // Questo sarà il GameObject vuoto nella gerarchia

    private void Awake()
    {
        Instance = this;

        // Controllo se il prefab è assegnato correttamente
        if (birdPrefab == null)
        {
            Debug.LogError("Il prefab degli uccelli non è stato assegnato.");
            return; // Evita di continuare se non c'è il prefab
        }

        // Se birdContainer non è stato impostato via inspector, lo creiamo dinamicamente
        if (birdContainer == null)
        {
            birdContainer = new GameObject("BirdContainer"); // Crea un nuovo GameObject vuoto nella scena
        }

        InitializePool();
    }

    private void InitializePool()
    {
        birdPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject bird = Instantiate(birdPrefab);

            bird.transform.SetParent(birdContainer.transform); // Imposta il birdContainer come parent
            bird.SetActive(false);
            birdPool.Add(bird);
        }
    }

    public GameObject GetBird()
    {
        // Cicla attraverso il pool e restituisci il primo uccello inattivo
        foreach (GameObject bird in birdPool)
        {
            if (bird != null && !bird.activeInHierarchy)
            {
                
                return bird;
            }
        }

        // Se tutti gli uccelli sono in uso, espandi il pool
        ExpandPool(1); // Espandi il pool di 1 uccello
        GameObject newBird = birdPool[birdPool.Count - 1]; // Prendi l'ultimo uccello creato
        newBird.SetActive(true); // Attiva il nuovo uccello
        return newBird;
    }

    public void ReturnBird(GameObject bird)
    {
        if (bird != null)
        {
            bird.SetActive(false); // Disattiva l'uccello per "restituirlo" al pool
            bird.transform.position = Vector3.zero; // Reimposta la posizione se necessario
        }
    }

    public void ExpandPool(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject bird = Instantiate(birdPrefab);

            if (birdContainer != null)
            {
                bird.transform.SetParent(birdContainer.transform); // Imposta il birdContainer come parent
            }

            bird.SetActive(false); // Aggiungiamo gli uccelli inattivi
            birdPool.Add(bird);
        }
    }
}
