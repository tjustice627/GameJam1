using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController player = other.GetComponent<PlayerController>();

        if (player != null)
        {
            if(player.currentHealth < player.maxHealth)
            {
                player.ChangeHealth(1);
                Destroy(gameObject);
            }
        }
    }
}
