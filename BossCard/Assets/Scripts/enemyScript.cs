using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
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


    // Start is called before the first frame update
    private void Awake()
    {
        health = maxHealth.initialValue;
    }
    private void Start()
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
            this.gameObject.SetActive(false);
        }
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
