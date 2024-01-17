using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagment : MonoBehaviour
{
    public void openGameScene()
    {
        SceneManager.LoadScene(1);
    }
    
    public void openMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}