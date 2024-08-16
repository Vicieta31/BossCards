using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static enemyScript;

enum dir { UP, DOWN, LEFT, RIGHT }
public enum PlayerState
{
    walk,
    attack,
    interact,
    stagger
}

public class playerScript : MonoBehaviour
{
    public PowersList currentPowers;

    public PlayerState currentState;
    public float baseSpeed;
    float speed;
    private Vector2 moveInp;
        
    Rigidbody2D rb;
    bool mRight;
    bool mLeft;
    bool mUp;
    bool mDown;

    int buffSpeed;
    int buffAttack;
    int buffShield;
    int shield = 0;

    public Animator playerAnimator;

    bool isAttacking = false;
    dir lastDirection;
    public FloatValue currentHealth;
    public MySignal playerHealthSignal;

    // Start is called before the first frame update
    void Start()
    {
        speed = baseSpeed;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        InputUpdate();
        if (currentState != PlayerState.stagger)
        {
            UpdateDirVel();
        }
        CheckDirection();
        playerAnimator.SetFloat("dir", (int)lastDirection);
    }

    public void DamageSelf(float knockTime, float damage)
    {
        damage -= shield;
        if (damage <=0)
        {
            damage = 1;
        }

        currentHealth.RunTimeValue -= damage;
        playerHealthSignal.Raise();
        StartCoroutine(KnockCo(knockTime));

        if (currentHealth.RunTimeValue <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }
    
    public void QuantityPowers()
    {
        buffSpeed = 0;
        buffAttack = 0;
        buffShield = 0;
        foreach (int power in currentPowers.RunTimeValue)
        {
            if (power == 1) 
            {
                buffSpeed++;
            }
            if (power == 2)
            {
                buffAttack++;
            }
            if (power == 3)
            {
                buffShield++;
            }
        } 
        UpdatePowers();
    }
    private void UpdatePowers()
    {
        if (buffSpeed == 0)
        {
            speed = baseSpeed;
        }
        else if (buffSpeed == 1)
        {
            speed = 6.7f;
        }
        else if (buffSpeed == 2)
        {
            speed = 8.3f;
        }
        else if (buffSpeed == 3)
        {
            speed = 10f;
        }

        if (buffShield == 0)
        {
            shield = 0;
        }
        else if (buffShield == 1)
        {
            shield = 1;
        }
        else if (buffShield == 2)
        {
            shield = 2;
        }
        else if (buffShield == 3)
        {
            shield = 3;
        }
    }

    private IEnumerator KnockCo(float knockTime)
    {
        if (rb != null)
        {
            yield return new WaitForSeconds(knockTime);
            rb.velocity = Vector2.zero;
            currentState = PlayerState.walk;
            rb.velocity = Vector2.zero;
        }
    }

    void InputUpdate()
    {
        moveInp.x = Input.GetAxisRaw("Horizontal");
        moveInp.y = Input.GetAxisRaw("Vertical");

        moveInp.Normalize();

        if (Input.GetKeyDown(KeyCode.Z) && !isAttacking)
        {
            Attack();
        }
    }
    void UpdateDirVel()
    {
        if (!isAttacking)
        {
            //Debug.Log("No se mueve por stagger");
            rb.velocity = moveInp * speed;
        }
        else
        {
            rb.velocity = Vector2.zero; // Detiene el movimiento durante el ataque
        }
    }
    void Attack()
    {
        isAttacking = true;
        playerAnimator.Play("ataking");

        StartCoroutine(EndAttack());
    }
    IEnumerator EndAttack()
    {
        // Espera la duración de la animación de ataque
        isAttacking = true;
        yield return null;

        // Termina el ataque y permite otras animaciones
        yield return new WaitForSeconds(playerAnimator.GetCurrentAnimatorStateInfo(0).length);
        isAttacking = false;
    }
    void CheckDirection()
    {
        if (isAttacking) return;

        if (moveInp == Vector2.zero)
        {
            playerAnimator.Play("idle");
        }
        else
        {
            if (moveInp.x > 0)
            {
                lastDirection = dir.RIGHT;
            }
            else if (moveInp.x < 0)
            {
                lastDirection = dir.LEFT;
            }

            if (moveInp.y > 0)
            {
                lastDirection = dir.UP;
            }
            else if (moveInp.y < 0)
            {
                lastDirection = dir.DOWN;
            }
            playerAnimator.Play("walking");
        }
    }

}
