using System.Collections.Generic;
using UnityEngine;

public class Accelerateur : MonoBehaviour
{
    public List<Transform> ballsTransforms;
    public float           speedBall      = 1;
    void OnTriggerEnter(Collider other)
    {
        ballsTransforms.Add(other.transform);
        
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
            ballsTransforms[i].GetComponent<Rigidbody>().AddForce(force*speedBall, ForceMode.Impulse);
        }
        
    }
    
}

