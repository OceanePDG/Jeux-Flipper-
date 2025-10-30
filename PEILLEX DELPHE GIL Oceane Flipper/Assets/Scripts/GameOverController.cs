using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
        Time.timeScale = 1;
        
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
