using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GameManager : MonoBehaviour
{
    public int BallCount = 3;
    public GameObject ballPrefab;
    public GameObject Spawner;
    public KeyCode menuKey = KeyCode.Escape;
    public bool isMenuOpen;
    public GameObject menuGO;
    public void Start()
    {
        CreateBall();
    }

    public void LoseBall(GameObject Ball)
    {
        BallCount--;
        //Debug.Log("Lose Ball, ball left : " + BallCount );
        
        Destroy(Ball);
        if (BallCount > 0)
        {
            CreateBall();
        }
        else
        {
            Debug.Log("Game Over");
        }

        
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

    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
        Time.timeScale = 1;
        
    }

    public void Quit()
    {
        Application.Quit();
    }
}
