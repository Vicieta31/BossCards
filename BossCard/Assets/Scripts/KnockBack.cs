using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    public float thrust;
    public float knockTime;
    public float baseDamage;
    float damage;

    private int buffAttack;

    public PowersList currentAttack;


    private void Start()
    {
        damage = baseDamage;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Player"))
        {
            Rigidbody2D rbHit = other.GetComponent<Rigidbody2D>();
            if (rbHit != null)
            {
                Vector2 difference = rbHit.transform.position - transform.position;
                difference = difference.normalized * thrust;
                rbHit.AddForce(difference, ForceMode2D.Impulse);
                if (other.gameObject.CompareTag("Enemy") && other.isTrigger)
                {
                    // Estado stagger
                    rbHit.GetComponent<enemyScript>().currentState = enemyScript.EnemyState.stagger;
                    other.GetComponent<enemyLog>().Knock(rbHit, knockTime, damage);
                }
                if (other.gameObject.CompareTag("Player") && other.isTrigger)
                {
                    if (other.GetComponent<playerScript>().currentState != PlayerState.stagger)
                    {
                        rbHit.GetComponent<playerScript>().currentState = PlayerState.stagger;
                        other.GetComponent<playerScript>().DamageSelf(knockTime, damage);
                    }
                }
            }
        }

        if (other.CompareTag("Breakable"))
        {
            other.GetComponent<breakableParent>().Break();
        }
    }

    public void QuantityPowers()
    {
        buffAttack = 0;
        foreach (int power in currentAttack.RunTimeValue)
        {
            if (power == 2)
            {
                buffAttack++;
            }
        }
        UpdatePowers();
    }
    private void UpdatePowers()
    {

        if (buffAttack == 0)
        {
            damage = 1;
        }
        else if (buffAttack == 1)
        {
            damage = 2;
        }
        else if (buffAttack == 2)
        {
            damage = 3;
        }
        else if (buffAttack == 3)
        {
            damage = 4;
        }
        Debug.Log(damage);
    }

}
