using UnityEngine;

public class GunRotation : MonoBehaviour
{
    public Camera mainCamera; // Assicurati di collegare la camera principale
    [SerializeField] private SpriteRenderer spRender;

    void Update()
    {
        // Ottieni la posizione del mouse in coordinate di schermo
        Vector3 mouseScreenPosition = Input.mousePosition;

        // Converte la posizione del mouse da coordinate schermo a coordinate mondo
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(new Vector3(mouseScreenPosition.x, mouseScreenPosition.y, mainCamera.nearClipPlane));

        // Ottieni la direzione dal tuo oggetto alla posizione del mouse
        Vector3 direction = mouseWorldPosition - transform.position;
        direction.z = 0; // Ignora l'asse Z, se stai lavorando in un gioco 2D

        // Calcola la rotazione desiderata
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
  
        // Applica la rotazione all'oggetto
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));

        if(angle < 90 && angle > -90)
        {
            spRender.flipY = false;

        }
        else
        {
            spRender.flipY = true;
        }
    }



}
