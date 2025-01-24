using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BonusDisplayer : MonoBehaviour
{
    [SerializeField] BonusScripableObjects[] bonusDefault;
     BonusScripableObjects[] bonus;

    [SerializeField] Image bonusImage1;
    [SerializeField] TextMeshProUGUI bonusName1;
    [SerializeField] TextMeshProUGUI bonusDescription1;

    [SerializeField] Image bonusImage2;
    [SerializeField] TextMeshProUGUI bonusName2;
    [SerializeField] TextMeshProUGUI bonusDescription2;
    
    [SerializeField] Image bonusImage3;
    [SerializeField] TextMeshProUGUI bonusName3;
    [SerializeField] TextMeshProUGUI bonusDescription3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        bonus = new BonusScripableObjects[bonusDefault.Length];
        for (int j = 0; j < bonusDefault.Length; j++)
        {
            bonus[j] = bonusDefault[j];
        }

        int i = Random.Range(0, bonus.Length);
        bonusImage1.sprite = bonus[i].bonusSprite;
        bonusName1.text = bonus[i].bonusName;
        bonusDescription1.text = bonus[i].bonusDescription;

        for (int j = i; j < bonus.Length; j++)
        {
            if (j < bonus.Length-1)
            {
                bonus[j] = bonus[j+1];
            }
        }
        i = Random.Range(0, bonus.Length-1);

        bonusImage2.sprite = bonus[i].bonusSprite;
        bonusName2.text = bonus[i].bonusName;
        bonusDescription2.text = bonus[i].bonusDescription;

        for (int j = i; j < bonus.Length; j++)
        {
            if (j < bonus.Length - 1)
            {
                bonus[j] = bonus[j + 1];
            }
        }

        i = Random.Range(0, bonus.Length - 2);
        bonusImage3.sprite = bonus[i].bonusSprite;
        bonusName3.text = bonus[i].bonusName;
        bonusDescription3.text = bonus[i].bonusDescription;
    }
}
