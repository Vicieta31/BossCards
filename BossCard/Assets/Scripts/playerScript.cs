using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    enum dir { UP, DOWN, LEFT, RIGHT }
    public float speed;
    private Vector2 moveInp;
        
    Rigidbody2D rb;
    bool mRight;
    bool mLeft;
    bool mUp;
    bool mDown;

    public Animator playerAnimator;

    bool isAttacking = false;
    dir lastDirection;

    struct playerData
    {
        public int hp;
        public int money;
    }

    playerData pStats = new();




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pStats.hp = 10;
        pStats.money = 0;
    }

    // Update is called once per frame
    void Update()
    {
        InputUpdate();
        UpdateDirVel();

        
        CheckDirection();
        playerAnimator.SetFloat("dir", (int)lastDirection);


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
