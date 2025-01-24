using UnityEngine;

public class BirdsSound : MonoBehaviour
{
    [SerializeField] VisualizeHealthbar visualizeHealthbar;

    [SerializeField] AudioClip birdHit1;
    [SerializeField] AudioClip birdHit2;
    [SerializeField] AudioClip menuHit;
    AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        visualizeHealthbar.OnHitOccurred += PlaySound;
    }

    
    public void PlaySound(GameObject obj)
    {
        int randomSound = Random.Range(1, 3);
        if (randomSound == 1)
        {
            audioSource.clip = birdHit1;
        }
        else
        {
            audioSource.clip = birdHit2;
        }
        audioSource.Play();
        
    }

    public void SetMenuSound()
    {
        audioSource.clip = menuHit;
        audioSource.Play();
    }
}
