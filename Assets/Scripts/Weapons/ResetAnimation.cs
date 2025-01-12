using UnityEngine;

public class ResetAnimation : MonoBehaviour
{
    Animator animator;
    public bool Reloaded = false;
    private void Start()
    {
        animator = GetComponent<Animator>();
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
}
