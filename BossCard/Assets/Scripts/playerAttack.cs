using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            // i want to insted of enemyScript is the script that the other has
            other.GetComponent<enemyScript>().Hurt();
        }

        if (other.CompareTag("Breakable"))
        {
            other.GetComponent<breakableParent>().Break();
        }
    }
}
