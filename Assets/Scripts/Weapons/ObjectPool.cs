using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;

    public GameObject bulletPrefab;
    public int poolSize = 8;

    private List<GameObject> bulletPool;
    public GameObject bulletContainer; // Questo sarà il GameObject vuoto nella gerarchia

    private void Awake()
    {
        Instance = this;
        if (bulletContainer == null)
        {
            bulletContainer = new GameObject("bulletContainer"); // Crea un nuovo GameObject vuoto nella scena
        }
        InitializePool();
    }

    private void InitializePool()
    {
        bulletPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.SetParent(bulletContainer.transform); // Imposta il bulletContainer come parent
            bullet.SetActive(false);
            bulletPool.Add(bullet);
        }
    }

    public GameObject GetBullet()
    {
        foreach (GameObject bullet in bulletPool)
        {
            if (bullet != null)
            {
                if (!bullet.activeInHierarchy)
                {
                    bullet.SetActive(true);
                    return bullet;
                }
            }
        }

        // Se tutti i proiettili sono in uso, ritorna null (o puoi espandere il pool)
        return null;
    }

    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
    }
}
