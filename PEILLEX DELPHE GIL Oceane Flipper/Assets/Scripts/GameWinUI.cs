using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWinUI : MonoBehaviour
{
    public string nextLevel;
    
    public void NextLevel()
    {
        Time.timeScale = 1;

        if (!string.IsNullOrEmpty(nextLevel))
        {
            SceneManager.LoadScene(nextLevel);
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
