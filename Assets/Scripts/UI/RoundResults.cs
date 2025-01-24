using TMPro;
using UnityEngine;

public class RoundResults : MonoBehaviour
{
    TextMeshProUGUI TextMeshProUGUI;
    VisualizeRounds VisualizeRounds;
    [SerializeField]GameObject newRecord;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        VisualizeRounds = FindAnyObjectByType<VisualizeRounds>();
        TextMeshProUGUI = gameObject.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI.text = VisualizeRounds.DisplayRounds.ToString();
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("RecordRound"))
        {
            if (VisualizeRounds.DisplayRounds > PlayerPrefs.GetInt("RecordRound"))
            {
                PlayerPrefs.SetInt("RecordRound", VisualizeRounds.DisplayRounds);
                newRecord.SetActive(true);
            }
        }
        else 
        {
            PlayerPrefs.SetInt("RecordRound", VisualizeRounds.DisplayRounds);
            newRecord.SetActive(true);
        }
    }

}