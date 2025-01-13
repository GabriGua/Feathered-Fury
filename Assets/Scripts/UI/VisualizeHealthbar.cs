using System;
using UnityEngine;
using UnityEngine.UI;

public class VisualizeHealthbar : MonoBehaviour
{
    [SerializeField] WeaponsSystem weaponSystem;
    BirdLife BirdLife;
    float life;
    [SerializeField]GameObject bar;
    [SerializeField] GameObject barShadow;
    GameObject bird;
    bool follow = false;

    Image barImage;
    Image barImageShadow;
    //event
    public event Action<GameObject> OnHitOccurred;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        barImage = bar.GetComponent<Image>();
        barImageShadow = barShadow.GetComponent<Image>();
        OnHitOccurred += HitOccured;
    }

    public void HitOccured(GameObject hitObject)
    {
        follow = true;
        bird = hitObject;
        BirdLife = bird.GetComponent<BirdLife>();
        life = BirdLife.life;
        
        barImageShadow.fillAmount = life/100;
        barImage.fillAmount = (life - 5f)/100;
        if(life <= 0)
        {
            gameObject.SetActive(false);
        }
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (follow)
        {
            gameObject.transform.position  = new Vector2 (bird.transform.position.x, bird.transform.position.y + 0.5f);
        }
    }
    public void BirdHitOccured(GameObject hitBirdGO)
    {
        OnHitOccurred?.Invoke(hitBirdGO);
        
    }
}