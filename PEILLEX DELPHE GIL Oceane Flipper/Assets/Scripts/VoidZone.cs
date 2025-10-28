using System.Collections.Generic;
using UnityEngine;

public class VoidZone : MonoBehaviour
{
	public List<Transform> ballsTransforms;
    public float           strength      = 1;
    public int             scoreToAdd    = 10;
    public float             strenghtBalls = 2;
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
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < ballsTransforms.Count; i++)
        {
            Vector3 force = transform.position - ballsTransforms[i].position;
            ballsTransforms[i].GetComponent<Rigidbody>().AddForce(force*strength, ForceMode.Impulse);
        }
        
    }

    void Update(float strengthBalls)
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Vector3 force = transform.up * strengthBalls;
        }
    }
}
