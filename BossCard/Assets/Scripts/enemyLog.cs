using UnityEngine;
using System.Collections;

public class enemyLog : enemyScript
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Hurt()
    {
        // Your hurt logic here
        Debug.Log("Auch i'm a Log");
    }
}
