using System.Collections.Generic;
using UnityEngine;

public class VoidZone : MonoBehaviour
{
	public List<Transform> ballsTransforms;
    public float           strength      = 1;
    public int             scoreToAdd    = 10;
    public float           strengthBalls = 2;
    public KeyCode         key           = KeyCode.Space;
    public float           spamTime      = 1f;
    public int             spamThreehold = 3;
    public float           time          = 0;
    public Rigidbody       rb;
    public float           gravity = -1.6f;
    void OnTriggerEnter(Collider other)
    {
        ballsTransforms.Add(other.transform);
        ScoreManager.instance.score += scoreToAdd;
        ScoreManager.instance.AddScore(scoreToAdd);
        BallEnterZone();
    }

    void OnTriggerExit(Collider other)
    {
	    ballsTransforms.Remove(other.transform);
        gravity = -9.2f;
    }
    void Update()
    {
        for (int i = 0; i < ballsTransforms.Count; i++)
        {
            Vector3 force = transform.position - ballsTransforms[i].position;
            ballsTransforms[i].GetComponent<Rigidbody>().AddForce(force*strength, ForceMode.Force);
        }
        
        if (key == KeyCode.Space)
        {
            int clickCount = 0;
            clickCount ++;
            time += Time.deltaTime;
            if (time >= spamTime)
            {
                if (clickCount >= spamThreehold)
                {
                    Debug.Log("Spam");
                    for (int i = 0; i < ballsTransforms.Count; i++)
                    {
                        Vector3 pushBall = ballsTransforms[i].position - transform.position;
                        ballsTransforms[i].GetComponent<Rigidbody>().AddForce(pushBall*strengthBalls, ForceMode.Impulse);
                    }
                }
                
            }
            clickCount = 0;
            time       = 0;
            
        }
        
    }

    void BallEnterZone()
    {
        rb.mass = gravity;
        rb.linearVelocity = Vector3.zero;
    }
    
    
       
    
}
