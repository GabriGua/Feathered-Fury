using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetAnimation : MonoBehaviour
{
    Animator animator;
    public bool Reloaded = false;
    AudioSource ExplosiveAC;
    private void Start()
    {
        animator = GetComponent<Animator>();
        ExplosiveAC = GetComponent<AudioSource>();
    }
    public void OnShootAnimationEnd()
    {
        animator.SetBool("IsShooting", false); // Resetta il parametro bool
    }
    public void OnReloadAnimationEnd()
    {
        Reloaded = false;
        animator.SetBool("IsReloading", false);
        // Resetta il parametro bool
    }

    public void ActuallyReloaded()
    {
        Reloaded = true;
    }

    public void DestroyEgg() // Egg Animation
    {
        Destroy(gameObject);
    }

    public void PlayExplosion()
    {
        ExplosiveAC.Play();
    }

    public void MoveToScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
