using UnityEngine;

public class GameWinUI : MonoBehaviour
{    
    public string nextLevel; 
    
    public void NextLevel()
    {
        Time.timeScale = 1;
        if (!string.IsNullOrEmpty(nextLevel))
        {
            Application.LoadLevel(nextLevel);
        }
        else
        {
            Application.LoadLevel("MainMenu");
        }
    }
    public void Quit()
    {
        Application.Quit();
    }
}
