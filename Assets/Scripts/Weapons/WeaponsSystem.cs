using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class WeaponsSystem : MonoBehaviour
{
    [SerializeField] GameObject cursorCollider;

    [SerializeField] GameObject Healthbar;
    VisualizeHealthbar visualizeHealthbar;
    [SerializeField] VisualizeRounds visualizeRounds;
    [SerializeField] Shooter shooter;
    BirdLife birdLife;
    public ResetAnimation resetAnimation;
    
    // ParticleSystem psBird;
    // GameObject bird;

    [SerializeField] private Animator shotgunAnimator;
    [SerializeField] private AudioSource shotgunAudio;
    AudioSource reloadAudio;

    Ray ray;
    RaycastHit2D hit;
    [SerializeField] LayerMask clickableLayer;
    [SerializeField] GameObject Bird;
    public int ammo = 5;
    public int maxAmmo = 5;
    int i = 0;



    private void Start()
    {
        cursorCollider.SetActive(false);
        reloadAudio = GetComponent<AudioSource>();
        visualizeHealthbar = Healthbar.GetComponent<VisualizeHealthbar>();
    }


    public void MouseShooting(InputAction.CallbackContext cxt)
    {
        if (cxt.performed)
        {
            // Ottieni la posizione del mouse in coordinate di schermo
            Vector2 mousePosition = Input.mousePosition;

            // Verifica se il mouse è all'interno della finestra di gioco
            if (mousePosition.x >= 0 && mousePosition.x <= Screen.width &&
                mousePosition.y >= 0 && mousePosition.y <= Screen.height)
            {
                ray = Camera.main.ScreenPointToRay(mousePosition);
                cursorCollider.SetActive(true);
                cursorCollider.transform.position = ray.origin;
                hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, clickableLayer);

                if (hit.collider != null)
                {
                    if (ammo > 0)
                    {
                        shooter.Shoot();
                        shotgunAnimator.SetBool("IsShooting", true);
                        ammo--;
                        shotgunAudio.Play();
                        i = 0;

                        if (hit.collider.gameObject.tag == "Bird" || hit.collider.gameObject.tag == "BlueBird")
                        {
                            birdLife = hit.collider.gameObject.GetComponent<BirdLife>();
                            Healthbar.SetActive(true);
                            birdLife.HitReceived();
                            visualizeHealthbar.BirdHitOccured(hit.collider.gameObject);
                            visualizeRounds.ThatsAGoodClick();
                        }
                        else
                        {
                            visualizeRounds.ThatsABadClick();
                        }
                    }
                    else
                    {
                        shotgunAnimator.SetBool("IsReloading", true);

                        if (i == 0)
                        {
                            reloadAudio.Play();
                            i++;
                        }
                    }
                }
            }
            else
            {
                Debug.Log("Il mouse è fuori dalla finestra di gioco.");
            }
        }
    }

    public void Shotgun()
    {

    }


    private void Update()
    {
        if (resetAnimation.Reloaded)
        {
            ammo = maxAmmo;
        }

    }

    public void MoreAmmo()
    {
        if (ammo <= 8)
        {
            maxAmmo++;
        }
        
    }


}
