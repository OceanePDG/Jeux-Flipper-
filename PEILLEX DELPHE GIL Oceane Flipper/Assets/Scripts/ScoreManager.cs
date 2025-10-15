using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI scoreText;
    public int             score;

    void Awake()
    {
        instance = this;
    }
    
    void Start()
    {
        RefreshText();
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        RefreshText();
    }
    
    void RefreshText()
    {
        scoreText.text = "Score: " +  score;
    }
   
}