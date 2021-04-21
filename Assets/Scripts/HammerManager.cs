using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerManager : MonoBehaviour
{
    //Animator animator;
    public GameObject hammerObject;

    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("押された");
            //animator.Play("Move@Hammer");
            var item = Instantiate(hammerObject,transform.position,transform.rotation);
            item.transform.SetParent(this.transform);
        }
    }
}
