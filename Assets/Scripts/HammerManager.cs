using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerManager : MonoBehaviour
{
    //Animator animator;
    public GameObject hammerObject;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var mousePosition = Input.mousePosition;
        mousePosition.z = 10;
        var pos = Camera.main.ScreenToWorldPoint(mousePosition);
        hammerObject.transform.position = pos;

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("入力されてる");
            animator.SetTrigger("Move0");
        }
        //if (Input.GetMouseButtonDown(0))
        //{

        //    var mousePosition = Input.mousePosition;
        //    mousePosition.z = 10;
        //    var pos = Camera.main.ScreenToWorldPoint(mousePosition);
        //    var cube = Instantiate(hammerObject,transform);
        //    cube.transform.position = pos;
            
        //}

        /*if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("押された");
            //animator.Play("Move@Hammer");
            var item = Instantiate(hammerObject,transform.position,transform.rotation);
            item.transform.SetParent(this.transform);
        }*/
    }
}
