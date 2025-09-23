using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GameManager : MonoBehaviour
{
    public int BallCount = 3;
    public GameObject ballPrefab;
    public GameObject Spawner;

    public void Start()
    {
        CreateBall();
    }

    public void LoseBall(GameObject Ball)
    {
        BallCount--;
        Debug.Log("Lose Ball, ball left : " + BallCount );
        
        Destroy(Ball);
        if (BallCount >= 0)
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
        
}
