using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AccurancyResults : MonoBehaviour
{
    TextMeshProUGUI TextMeshProUGUI;
    [SerializeField] TextMeshProUGUI resultAim;
    [SerializeField] Image skull;
    VisualizeRounds VisualizeRounds;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        VisualizeRounds = FindAnyObjectByType<VisualizeRounds>();
        int result = VisualizeRounds.CalculateAccurancy();

        TextMeshProUGUI = GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI.text = result.ToString() + " %";
        if (result < 10 && result >= 0)
        {
            resultAim.text = "Incredibly Bad";
        }
        else if (result < 20)
        {
            resultAim.text = "Come on";
        }
        else if (result < 30)
        {
            resultAim.text = "Really?";
        }
        else if (result < 50)
        {
            resultAim.text = "Could be better";
        }
        else if (result < 65)
        {
            resultAim.text = "Average";
        }
        else if (result < 75)
        {
            resultAim.text = "Impressive";
        }
        else if (result < 85)
        {
            resultAim.text = "WOW a Pro Player";
        }
        else if (result < 90)
        {
            resultAim.text = "Feel like a God";
        }
        else if (result < 100)
        {
            resultAim.text = "Ok, relax Bro";
        }
        else if (result == 100)
        {
            resultAim.text = "";
            skull.enabled = true;
        }
        
    }
}