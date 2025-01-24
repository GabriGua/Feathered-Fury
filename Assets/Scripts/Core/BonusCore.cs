using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class BonusCore : MonoBehaviour
{
    [SerializeField] LifePoints lifePoints;
    [SerializeField] WeaponsSystem weaponsSystem;


    [SerializeField] BonusScripableObjects[] bonusChosen;

    [SerializeField] TextMeshProUGUI firstSelection;
    [SerializeField] TextMeshProUGUI secondSelection;
    [SerializeField] TextMeshProUGUI thirdSelection;

    [SerializeField] GameObject BonusSelection;

    [SerializeField] GameObject slowSpeed;
    [SerializeField] GameObject slowSpeedEggs;
    Image slowSpeedIMG;
    Image slowSpeedIMGEgg;


    public int speed = 10;
    public float gravity = 0.75f;
    public event Action OnBonusB_End;
  

    // Inizializza un componente TextMeshProUGUI per visualizzare il nome del bonus selezionato
    TextMeshProUGUI bonusName;
    bool bonusSelected = false;
    int i = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        
        slowSpeedIMG = slowSpeed.GetComponent<Image>();
        slowSpeedIMGEgg = slowSpeedEggs.GetComponent<Image>();
        // Assicurati che bonusName sia assegnato a un componente di testo esistente
        bonusName = new GameObject("BonusName").AddComponent<TextMeshProUGUI>();
    }

    public void ExecuteBonus(int selection)
    {
        // Seleziona il nome del bonus in base all'input
        switch (selection)
        {
            case 0:
                bonusName.text = firstSelection.text;
                
                break;
            case 1:
                bonusName.text = secondSelection.text;
                
                break;
            case 2:
                bonusName.text = thirdSelection.text;
                
                break;
            default:
                Debug.LogWarning("Selezione non valida!");
                return; // Esci dal metodo se la selezione è invalida
        }

        // Cerca il bonus corrispondente nel vettore BonusChosen
        while (!bonusSelected && i < bonusChosen.Length)
        {
            if (bonusChosen[i].bonusName == bonusName.text)
            {
                bonusSelected = true;
                BonusSelection.SetActive(false);
                switch (i)
                {
                    case 0:
                        
                        
                        lifePoints.AddHeart(); // Aggiungi un cuore
                        
                        
                        break;
                    case 1:
                        // Aggiungi una munizione

                        weaponsSystem.MoreAmmo();
                        break;
                    case 2:
                        // Gli uccelli sono piú lenti
                        StartCoroutine(LowerSpeedBirds());


                        break;
                    case 3:
                        StartCoroutine(LowerSpeedEggs());

                        break;
                }
                Time.timeScale = 1;
            }
            i++;
        }

        // Se nessun bonus corrisponde, aggiungi un log per indicare l'errore
        if (!bonusSelected)
        {
            Debug.LogWarning("Nessun bonus trovato corrispondente a: " + bonusName.text);
        }

        // Resetta 'i' e 'bonusSelected' per il prossimo utilizzo di ExecuteBonus
        i = 0;
        bonusSelected = false;

    }



    IEnumerator LowerSpeedEggs()
    {
        gravity = 0.75f;
        float timer = 30;
        slowSpeedIMGEgg.fillAmount = 1;
        while (timer > 0)
        {
            slowSpeedEggs.SetActive(true);
            slowSpeedIMGEgg.fillAmount = timer / 30;
            yield return new WaitForSeconds(1);
            timer--;

        }

        slowSpeedEggs.SetActive(false);
        gravity = 1f;
        



    }

    IEnumerator LowerSpeedBirds()
    {
        speed = 5;
        float timer = 30;
        slowSpeedIMG.fillAmount = 1;
        while (timer > 0)
        {
            slowSpeed.SetActive(true);
            slowSpeedIMG.fillAmount = timer / 30;
            yield return new WaitForSeconds(1);
            timer--;
            
        }
        
        slowSpeed.SetActive(false);
        speed = 10;
        OnBonusB_End?.Invoke();
        
        

    }
}

