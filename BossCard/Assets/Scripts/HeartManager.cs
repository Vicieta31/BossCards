using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite threeQuarterHeart;
    public Sprite halfHeart;
    public Sprite quarterHeart;
    public Sprite emptyHeart;

    public FloatValue heartContainers;
    public FloatValue playerCurrentHP;

    // Start is called before the first frame update
    void Start()
    {
        InitHearts();
    }

    public void InitHearts()
    {
        for (int i = 0; i < heartContainers.initialValue; i++)
        {
            hearts[i].gameObject.SetActive(true);
            hearts[i].sprite = fullHeart;
        }
    }

    public void UpdateHearts()
    {
        // Assume playerCurrentHP.initialValue is an integer and represents the player's health.
        int tempHealth = Mathf.CeilToInt(playerCurrentHP.RunTimeValue);

        // Loop through all hearts
        for (int i = 0; i < hearts.Length; i++)
        {
            // Calculate the remaining health for this heart
            int heartHealth = Mathf.Clamp(tempHealth - (i * 4), 0, 4);

            // Determine the correct sprite based on the heartHealth
            switch (heartHealth)
            {
                case 4:
                    hearts[i].sprite = fullHeart;
                    break;
                case 3:
                    hearts[i].sprite = threeQuarterHeart;
                    break;
                case 2:
                    hearts[i].sprite = halfHeart;
                    break;
                case 1:
                    hearts[i].sprite = quarterHeart;
                    break;
                default:
                    hearts[i].sprite = emptyHeart;
                    break;
            }
        }
    }
   
}
