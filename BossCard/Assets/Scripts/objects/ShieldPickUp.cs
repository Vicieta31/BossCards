using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPickUp : PickUpBase
{
    public PowersList currentPowers;
    // Start is called before the first frame update
    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            for (int i = 0; i < currentPowers.RunTimeValue.Count; i++)
            {
                if (currentPowers.RunTimeValue[i] == 0)
                {
                    currentPowers.RunTimeValue[i] = 3;
                    break;
                }
            }
            context.Raise();

            Destroy(gameObject);
        }
    }

}