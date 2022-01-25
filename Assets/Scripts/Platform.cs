using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    private PlatformEffector2D effector;
    // Start is called before the first frame update
    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            effector.rotationalOffset = 180f;
        }
        else
        {
            effector.rotationalOffset = 0f;
        }
    }
}
