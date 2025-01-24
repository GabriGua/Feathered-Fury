using TMPro;
using UnityEngine;

public class RecordResults : MonoBehaviour
{
    TextMeshProUGUI TextMeshProUGUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TextMeshProUGUI = GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI.text = PlayerPrefs.GetInt("RecordRound").ToString();
        
    }

}
