using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformEffector : MonoBehaviour
{

    private PlatformEffector2D effector;
    public float waitTime;

    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    void Update()
    {

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            effector.rotationalOffset = 0;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {

            effector.rotationalOffset = 180f;

        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }
}





