using UnityEngine;
using System.Collections;
public class RedBirdEgg : MonoBehaviour
{
    [SerializeField] GameObject EggSpawn;
    [SerializeField] private GameObject Egg;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnEggs());
        
    }
    IEnumerator SpawnEggs()
    {
        while (true) // Loop infinito
        {
            // Calcola un ritardo casuale aggiuntivo
            float randomDelay = Random.Range(2f, 5f);

            // Attendi l'intervallo di base più il ritardo casuale
            yield return new WaitForSeconds(randomDelay);

            // Genera l'oggetto
            Instantiate(Egg, EggSpawn.transform.position, Quaternion.identity);
        }
    }


}
