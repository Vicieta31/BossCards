using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBase : MonoBehaviour
{
    BoxCollider2D bc;

    public MySignal context;

    public audioManagerScript audioM;

    void Start()
    {
        GameObject auM = GameObject.FindWithTag("audio");
        audioM = auM.GetComponent<audioManagerScript>();
        bc = GetComponent<BoxCollider2D>();
    }
    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            context.Raise();
        }
        audioM.PlaySFX(audioM.collect);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            context.Raise();
        }
    }
}
