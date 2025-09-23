using UnityEngine;

public class Bumper : MonoBehaviour
{
   public float strenght = 1;
   void OnCollisionEnter(Collision other)
   {
      Vector3 direction = other.transform.position - transform.position;
      other.rigidbody.AddForce(direction.normalized * strenght, ForceMode.Impulse);
   }
}
