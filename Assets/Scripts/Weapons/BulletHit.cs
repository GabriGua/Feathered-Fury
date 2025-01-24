using UnityEngine;

public class BulletHit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if(collision.tag == "Cursor" || collision.tag == "Terrain" || collision.tag == "LeftWall" || collision.tag == "RightWall")
            {
                // Disattiva il proiettile e restituiscilo al pool
                ObjectPool.Instance.ReturnBullet(gameObject);

            }

        }
        
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   