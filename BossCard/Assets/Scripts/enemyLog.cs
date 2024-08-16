using UnityEngine;
using System.Collections;

public class enemyLog : enemyScript
{

    // Use this for initialization
    void Start()
    {
        currentState = EnemyState.idle;

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void ChangeState(EnemyState newState)
    {
        if (currentState != newState)
        {
            currentState = newState;
        }
    }

    public override void Hurt()
    {
        // Your hurt logic here
        Debug.Log("Auch i'm a Log");
    }
}
