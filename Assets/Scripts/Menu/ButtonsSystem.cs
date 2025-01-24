using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsSystem : MonoBehaviour
{
    [SerializeField] GameObject buttonPlay;
    [SerializeField] GameObject buttonOption;
    [SerializeField] GameObject buttonCredits;
    public void MoveToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }


    public void DeactivateOBJ()
    {
        buttonCredits.SetActive(false);
        buttonOption.SetActive(false);
        buttonPlay.SetActive(false);
    }
}