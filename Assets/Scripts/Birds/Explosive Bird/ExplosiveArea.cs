using UnityEngine;
using System;

public class ExplosiveArea : MonoBehaviour
{
    [SerializeField] LifePoints LifePoints;
    public event Action OnCollisionOccurred;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LifePoints = FindAnyObjectByType<LifePoints>();
        OnCollisionOccurred += LifePoints.FirstCircle;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.tag == "Hunter")
            {
                
                OnCollisionOccurred?.Invoke();

               

            }

        }
    }
}
