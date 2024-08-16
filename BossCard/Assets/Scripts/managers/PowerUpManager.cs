using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpManager : MonoBehaviour
{
    public Image[] powers;
    public Sprite coin;
    public Sprite fire;
    public Sprite shield;
    public Sprite noneS;

    public PowersList currentPowers;

    // Start is called before the first frame update
    void Start()
    {
        InitPowers();
    }

    public void InitPowers()
    {
        for (int i = 0; i < currentPowers.RunTimeValue.Count; i++)
        {
            powers[i].gameObject.SetActive(true);
            powers[i].sprite = noneS;
        }
        
    }

    public void UpdatePowers()
    {
        // Assume playerCurrentHP.initialValue is an integer and represents the player's health.

        // Loop through all hearts
        for (int i = 0; i < powers.Length; i++)
        {
            int powerAct = currentPowers.RunTimeValue[i];
            // Determine the correct sprite based on the heartHealth
            switch (powerAct)
            {
                case 3:
                    powers[i].sprite = shield;
                    break;
                case 2:
                    powers[i].sprite = fire;
                    break;
                case 1:
                    powers[i].sprite = coin;
                    break;
                default:
                   powers[i].sprite = noneS;
                    break;
            }
        }
    }

}
