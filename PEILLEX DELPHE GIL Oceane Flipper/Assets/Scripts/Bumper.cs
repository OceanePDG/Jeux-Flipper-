using UnityEngine;

public class Bumper : MonoBehaviour
{
    public float strength   = 1;
    public int   scoreToAdd = 10;
    public Animation anim;
    void OnCollisionEnter(Collision other)
    {
        Vector3 direction = other.transform.position - transform.position;
        other.rigidbody.AddForce(direction.normalized * strength, ForceMode.Impulse);

        ScoreManager.instance.AddScore(scoreToAdd);
        anim.Play();
    }
}