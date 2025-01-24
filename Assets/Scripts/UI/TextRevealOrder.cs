using UnityEngine;

public class TextRevealOrder : MonoBehaviour
{
    [SerializeField] GameObject[] textToShow;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    int i = 0;
    public void ShotThisText()
    {
        if (i < textToShow.Length)
        {
            textToShow[i].gameObject.SetActive(true);
            i++;
        }
    }
    
}
