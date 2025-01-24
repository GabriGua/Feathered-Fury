using UnityEngine;

public class Shooter : MonoBehaviour
{
    public Transform gunMuzzle; // Punto di partenza del proiettile (bocca del fucile)
    float speed = 65f;
   

    public void Shoot()
    {
        GameObject bullet = ObjectPool.Instance.GetBullet();

        if (bullet != null)
        {
            // Posiziona il proiettile alla bocca del fucile
            bullet.transform.position = gunMuzzle.position;
            bullet.transform.rotation = gunMuzzle.rotation;

            // Calcola la direzione verso il mouse
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (mousePosition - (Vector2)gunMuzzle.position).normalized;

            Vector2 force = direction * speed;
            // Applica una forza al proiettile
            bullet.GetComponent<Rigidbody2D>().linearVelocity = force ; 
        }
    }
}
