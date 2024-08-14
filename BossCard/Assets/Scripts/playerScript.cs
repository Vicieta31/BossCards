using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    public float speed;
    private Vector2 moveInp;
        
    Rigidbody2D rb;
    bool mRight;
    bool mLeft;
    bool mUp;
    bool mDown;

    int playerDir;

    public Animator playerAnimator;

    int lastDir = 0;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovemnt();
        checkDirection();
        UpdateDirVel();
    }

    void UpdateMovemnt()
    {
        moveInp.x = Input.GetAxisRaw("Horizontal");
        moveInp.y = Input.GetAxisRaw("Vertical");

        moveInp.Normalize();

    }
    void UpdateDirVel()
    {
        rb.velocity = moveInp * speed;
    }

    void checkDirection()
    {
        if ((moveInp.x == 0) && (moveInp.y == 0))
        {
            if(lastDir == 1)
            {
                playerAnimator.Play("idleRight");
            }
            if (lastDir == 2)
            {
                playerAnimator.Play("idleLeft");
            }
            if (lastDir == 0)
            {
                playerAnimator.Play("idleMe");
            }
            if (lastDir == 3)
            {
                playerAnimator.Play("idleUp");
            }
                        
        }
        if (moveInp.x > 0)
        {
            if (mUp != true && mDown != true)
            {
                mRight = true;
                lastDir = 1;
                playerAnimator.Play("walkRMe");
            }
        }

        else
        {
            mRight = false;
        }
        if (moveInp.x < 0)
        {
            if (mUp != true && mDown != true)
            {
                lastDir = 2;
                mLeft = true;
                playerAnimator.Play("walkLMe");
            }
            
        }
        else
        {
            mLeft = false;
        }

        if (moveInp.y > 0)
        {
            if (mLeft != true && mRight != true)
            {
                lastDir = 3;
                mUp = true;
                playerAnimator.Play("walkUMe");
            }
        }
        else
        {
            mUp = false;
        }

        if (moveInp.y < 0)
        {
            if (mLeft != true && mRight != true)
            {
                lastDir = 0;
                mDown = true;
                playerAnimator.Play("walkDMe");
            }
        }
        else
        {
            mDown = false;
        }
    }

}
