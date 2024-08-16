using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPickUp : PickUpBase
{
    public FloatValue playerHealth;
    public FloatValue playerMaxHealth;
    public float increase;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            playerHealth.RunTimeValue += increase;
            if (playerHealth.RunTimeValue > playerMaxHealth.initialValue)
            {
                playerHealth.RunTimeValue = playerMaxHealth.initialValue;
            }
            context.Raise();

            Destroy(gameObject);
        }
    }

} 

    
