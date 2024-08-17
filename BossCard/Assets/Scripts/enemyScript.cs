using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    //Boss Battle
    public delegate void DeathAction();
    public event DeathAction OnDeath;


    public enum EnemyState
    {
        idle,
        walk,
        attack,
        stagger
    }

    BoxCollider2D bc;

    public EnemyState currentState;
    public FloatValue maxHealth;
    public float health;
    public int baseAttack;
    public float moveSpeed;

    public audioManagerScript audioM;

    // Start is called before the first frame update
    private void Awake()
    {
        GameObject auM = GameObject.FindWithTag("audio");
        audioM = auM.GetComponent<audioManagerScript>();
        health = maxHealth.initialValue;
    }
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Hurt()
    {
        Debug.Log("Auch");
    }
    private void takeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            audioM.PlaySFX(audioM.enemyDie);
            Die();
        }
        audioM.PlaySFX(audioM.enemyHurt);
    }

    //Boss battle
    void Die()
    {
        Debug.Log("Enemy is dying");
        OnDeath?.Invoke();
        Destroy(gameObject);
    }

    public void Knock(Rigidbody2D rb, float knockTime, float damage)
    {
        StartCoroutine(KnockCo(rb, knockTime));
        takeDamage(damage);
    }

    private IEnumerator KnockCo(Rigidbody2D rb, float knockTime)
    {
        if (rb != null)
        {
            yield return new WaitForSeconds(knockTime);
            rb.velocity = Vector2.zero;
            currentState = EnemyState.idle;
            rb.velocity = Vector2.zero;
        }
    }

}
