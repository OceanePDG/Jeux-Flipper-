using System;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int BallCount = 3;
    public GameObject ballPrefab;
    public GameObject Spawner;
    
    public KeyCode menuKey = KeyCode.Escape;
    public bool isMenuOpen;
    public GameObject menuGO;
    public GameObject gameOver;
    public GameObject gameWin;
    
    public int targetScore = 1000;
    public ScoreManager scoreManager;
    
    public void Start()
    {
        CreateBall();
    }

    public void LoseBall(GameObject Ball)
    {
        if (Ball.CompareTag("Ball"))
        {
            BallCount--;
            //Debug.Log("Lose Ball, ball left : " + BallCount );
            if (BallCount > 0)
            {
                CreateBall();
            }
            else
            {
                Debug.Log("Game Over");
                GameOver();
            }
        }
        Destroy(Ball);
        Debug.Log("ball destroy");
    }
    void CreateBall()
    {
        GameObject ballInstance= Instantiate(ballPrefab,  transform.position, Quaternion.identity, transform.parent);
        ballInstance.transform.position = Spawner.transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(menuKey))
        {
            ChangeMenuState();
        }

        if (scoreManager != null && scoreManager.score >= targetScore)
        {
            Debug.Log("Niveau terminé !");
            WinGame();
        }
    }


    public void ChangeMenuState()
    {
            isMenuOpen = !isMenuOpen;
            menuGO.SetActive(isMenuOpen);

            if (isMenuOpen)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        
    }

    public void RestartInGame()
    {
       //Application.LoadLevel(Application.loadedLevel);
       SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        Time.timeScale = 1;
        gameOver.SetActive(gameOver);
    }
    
    public void WinGame()
    {
        Time.timeScale = 1;
        gameWin.SetActive(gameWin);
    }
}
