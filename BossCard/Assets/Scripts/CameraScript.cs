using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    bool freeCam = true;
    public Transform objective;
    public Transform cardObjective;

    Vector3 targetPosition2;
    // Start is called before the first frame update
    void Start()
    {
        targetPosition2 = cardObjective.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            freeCam = false;
        }


        if(freeCam == true)
        {
            Vector3 targetPosition = objective.transform.position;

            transform.position = new Vector3(targetPosition.x,targetPosition.y, transform.position.z);
        }else
        {
            transform.position = new Vector3(targetPosition2.x, targetPosition2.y, transform.position.z);
        }
    }
}
