using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class WeaponsSystem : MonoBehaviour
{

    [SerializeField] GameObject Healthbar;
    VisualizeHealthbar visualizeHealthbar;
    BirdLife birdLife;
    public ResetAnimation resetAnimation;
    // ParticleSystem psBird;
    // GameObject bird;
    [SerializeField] private Animator shotgunAnimator;
    Ray ray;
    RaycastHit2D hit;
    [SerializeField] LayerMask clickableLayer;
    [SerializeField] GameObject Bird;
    public int ammo = 5;

  

    private void Start()
    {
        visualizeHealthbar = Healthbar.GetComponent<VisualizeHealthbar>();
    }


    public void MouseShooting(InputAction.CallbackContext cxt)
    {
        if (cxt.performed)
        {
            // Ottieni la posizione del mouse in coordinate di schermo

            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, clickableLayer);

            if (hit.collider != null)
            {



                if (ammo > 0)
                {
                    shotgunAnimator.SetBool("IsShooting", true);
                    ammo--;

                    if (hit.collider.gameObject.tag == "Bird" || hit.collider.gameObject.tag == "BlueBird")
                    {
                        // bird = hit.collider.gameObject;

                        Healthbar.SetActive(true);
                        //psBird = bird.GetComponentInChildren<ParticleSystem>();
                        //psBird.Play();
                        

                        birdLife = hit.collider.gameObject.GetComponent<BirdLife>();

                        birdLife.HitReceived();
                        visualizeHealthbar.BirdHitOccured(hit.collider.gameObject);






                    }

                }
                else
                {
                    shotgunAnimator.SetBool("IsReloading", true);


                }


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
            ammo = 5;
        }



    }




}
