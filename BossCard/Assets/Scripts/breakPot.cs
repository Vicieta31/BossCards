using UnityEngine;
using System.Collections;

public class breakPot : breakableParent
{
    public Animator myAnimator;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Break()
    {
        // Your hurt logic here
        Debug.Log("Auch i'm a pot");
        myAnimator.Play("breaking");
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }
}
