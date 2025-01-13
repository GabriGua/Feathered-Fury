using UnityEngine;
using TMPro;

public class VisualizeRounds : MonoBehaviour
{
    Animator animator;
    TextMeshProUGUI textMeshProUGUI;
    int DysplayRounds = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        textMeshProUGUI.text = "Round " + DysplayRounds;
    }

   

    public void NextRound()
    {
        animator.Play("NextRound");
        DysplayRounds++;
        textMeshProUGUI.text = "Round " + DysplayRounds;
    }
}
