using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private void Update()
    {
        transform.Translate(0,-0.0005f,0);
        if (transform.position.y <-4.74f)
        {
            transform.position = new Vector3(0,4.74f,0);
        }
    }

}
