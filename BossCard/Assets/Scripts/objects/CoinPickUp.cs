using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : PickUpBase
{
    public PowersList currentPowers;
    /*
    public FloatValue playerHealth;
    public FloatValue playerMaxHealth;
    public float increase;
    */
    // Start is called before the first frame update
    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            /*
            playerHealth.RunTimeValue += increase;
            if (playerHealth.RunTimeValue > playerMaxHealth.initialValue)
            {
                playerHealth.RunTimeValue = playerMaxHealth.initialValue;
            }
            */

            for (int i = 0; i < currentPowers.RunTimeValue.Count; i++)
            {
                if (currentPowers.RunTimeValue[i] == 0)
                {
                    currentPowers.RunTimeValue[i] = 1;
                    break;
                }
            }
            context.Raise();

            Destroy(gameObject);
        }
    }

}