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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        InputUpdate();
        UpdateDirVel();

        
        CheckDirection();
        playerAnimator.SetFloat("dir", (int)lastDirection);
        Debug.Log(lastDirection);
    }

    void InputUpdate()
    {
        moveInp.x = Input.GetAxisRaw("Horizontal");
        moveInp.y = Input.GetAxisRaw("Vertical");

        moveInp.Normalize();

        if (Input.GetKeyDown(KeyCode.Z) && !isAttacking)
        {
            Debug.Log("Z");
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

        if ((moveInp.x == 0) && (moveInp.y == 0))
        {
            playerAnimator.Play("idle");
        }
        if (moveInp.x > 0)
        {
            if (moveInp.y == 0)
            {
                lastDirection = dir.RIGHT;
                playerAnimator.Play("walking");
            }
        }
        else if (moveInp.x < 0)
        {
            if (moveInp.y == 0)
            {
                lastDirection = dir.LEFT;
                playerAnimator.Play("walking");
            }
        }
        else if (moveInp.y > 0)
        {
            if (moveInp.x == 0)
            {
                lastDirection = dir.UP;
                playerAnimator.Play("walking");
            }
        }
        else if (moveInp.y < 0)
        {
            if (moveInp.x == 0)
            {
                lastDirection = dir.DOWN;
                playerAnimator.Play("walking");
            }
        }
    }

}
