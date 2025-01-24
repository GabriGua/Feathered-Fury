using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;
    public int destroyAtSceneIndex = 1; // Indice della scena in cui vogliamo distruggere l'oggetto (la terza scena)

    void Awake()
    {
        // Se l'istanza non esiste, crea e mantieni l'oggetto
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Fa in modo che l'oggetto non venga distrutto tra le scene
            SceneManager.sceneLoaded += OnSceneLoaded; // Ascolta il caricamento delle scene
        }
        else
        {
            Destroy(gameObject); // Se esiste già un'istanza, distruggi il duplicato
        }
    }

    // Metodo chiamato quando viene caricata una nuova scena
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Controlla se l'indice della scena attuale è quello in cui vogliamo distruggere l'oggetto
        if (scene.buildIndex == destroyAtSceneIndex)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded; // Rimuovi il listener per evitare problemi futuri
            Destroy(gameObject); // Distruggi l'oggetto
        }
    }

    void OnDestroy()
    {
        // Rimuovi il listener nel caso l'oggetto venga distrutto
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}

