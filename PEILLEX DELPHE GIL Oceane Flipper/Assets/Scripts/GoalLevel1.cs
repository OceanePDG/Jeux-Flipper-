using UnityEngine;

public class GoalLevel1 : MonoBehaviour
{
    public int targetScore = 1000;
    public ScoreManager scoreManager;

    void Update()
    {
        if (scoreManager.score >= targetScore)
        {
            Debug.Log("Level 1 terminé !");
            FindObjectOfType<GameManager>().WinGame();
        }
    }
}

