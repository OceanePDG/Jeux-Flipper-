using System.Collections.Generic;
using UnityEngine;

public class VoidZone : MonoBehaviour
{
    public List<Transform> ballsTransforms;
    public float           strength      = 1;
    public int             scoreToAdd    = 10;
    public float             strengthBalls = 2;
    void OnTriggerEnter(Collider other)
    {
        ballsTransforms.Add(other.transform);
        ScoreManager.instance.score += scoreToAdd;
        ScoreManager.instance.AddScore(scoreToAdd);
    }

    void OnTriggerExit(Collider other)
    {
        ballsTransforms.Remove(other.transform);
    }
    
    void Update()
    {
        AttractionForce();
        GetBallsOut();
    }

    private void AttractionForce()
    {
        foreach (var ballT in ballsTransforms)
        {
            Vector3 force = Vector3.up;
            ballT.GetComponent<Rigidbody>().AddForce(force*strength, ForceMode.Force);
        }
    }
    
    private void GetBallsOut()
    {
        if (!Input.GetKey(KeyCode.Space)) return;

        foreach (var ballT in ballsTransforms)
        {
            Vector3 pushBall = ballT.position - transform.position;
            ballT.GetComponent<Rigidbody>().AddForce(pushBall*strengthBalls, ForceMode.Impulse);
        }
    }
       
    
}