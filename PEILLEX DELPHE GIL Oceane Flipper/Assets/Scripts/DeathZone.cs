using System;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public GameManager  gameManager;
    private void OnTriggerEnter(Collider other)
    {
        gameManager.LoseBall(other.gameObject);
    }
   
}
