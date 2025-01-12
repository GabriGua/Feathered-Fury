using UnityEngine;

public class SpriteFading : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.tag == "Hunter")
            {
                Color currentColor = spriteRenderer.color;

                // Modifica il valore alpha mantenendo inalterati i canali rosso, verde e blu
                currentColor.a = 0.3f;

                // Applica il colore modificato con il nuovo valore alpha
                spriteRenderer.color = currentColor;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.tag == "Hunter")
            {
                Color currentColor = spriteRenderer.color;

                // Modifica il valore alpha mantenendo inalterati i canali rosso, verde e blu
                currentColor.a = 1f;

                // Applica il colore modificato con il nuovo valore alpha
                spriteRenderer.color = currentColor;
            }
        }
    }
}
