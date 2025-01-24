using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class VisualizeRounds : MonoBehaviour
{
    public static VisualizeRounds instance;
    public int destroyAtSceneIndex = 0;
    public int destroyAtSceneIndex2 = 1;
    [SerializeField]Animator animator;
    
    [SerializeField]TextMeshProUGUI textMeshProUGUI;

    
    public static int DisplayRounds;
    int ClickAccurancy;
    public static int goodClick = 0;
    public static int totalClick = 0;
    

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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DisplayRounds = 1;
        
        
        textMeshProUGUI.text = "Round " + DisplayRounds;
    }



    public void NextRound()
    {
        if (animator != null)
        {
            animator.Play("NextRound");
        }
        
        DisplayRounds++;
        textMeshProUGUI.text = "Round " + DisplayRounds;
        
    }

    private void Update()
    {
        
        
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
        else if(scene.buildIndex == destroyAtSceneIndex2)
        {
            DisplayRounds = 1;
            goodClick = 0;
            totalClick = 0;
            
        }
        
    }

    void OnDestroy()
    {
        // Rimuovi il listener nel caso l'oggetto venga distrutto
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void ThatsAGoodClick()
    {
        goodClick++;
        totalClick++;
    }

    public void ThatsABadClick()
    {
        totalClick++;
    }

    public int CalculateAccurancy()
    {
        ClickAccurancy = (goodClick * 100)/totalClick;
        return ClickAccurancy;
    }

    
}
