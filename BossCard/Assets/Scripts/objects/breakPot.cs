using UnityEngine;
using System.Collections;

public class breakPot : breakableParent
{
    public Animator myAnimator;

    public GameObject spawnObject;
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

    public void SpawnHeart()
    {
        Instantiate(spawnObject, transform.position, transform.rotation);
        spawnObject.transform.localScale = new Vector3(0.75f,0.75f,1);
        audioM.PlaySFX(audioM.heartAppear);
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }
}
