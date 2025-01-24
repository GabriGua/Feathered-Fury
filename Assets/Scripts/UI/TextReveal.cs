using System.Collections;
using UnityEngine;
using TMPro;

public class TextReveal : MonoBehaviour
{
    [SerializeField] TextRevealOrder order;
    TextMeshProUGUI textComponent; // Collegare il componente TextMeshPro dalla scena.
    public float delay = 0.1f; // Ritardo tra la comparsa di ogni lettera.

    [SerializeField] AudioSource textSource;
    private string fullText; // Il testo completo che vogliamo rivelare.

    void Start()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
        
        // Prendere il testo completo dall'oggetto TextMeshPro.
        fullText = textComponent.text;
        textComponent.text = ""; // Imposta il testo inizialmente vuoto.

        // Inizia l'animazione.
        StartCoroutine(RevealText());
    }

    IEnumerator RevealText()
    {
        // Rivela una lettera alla volta.
        for (int i = 0; i <= fullText.Length; i++)
        {
            
            textComponent.text = fullText.Substring(0, i);
            textSource.Play(); // Aggiorna il testo.
            yield return new WaitForSeconds(delay); // Aspetta il tempo specificato prima di mostrare la prossima lettera.
            
        }
        order.ShotThisText();
    }
}

