using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerManager : MonoBehaviour
{
    //Animator animator;
    public GameObject hammerObject;
    Collider2D hammerCollider;
    Animator animator;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        animator =　GetComponent<Animator>();
        hammerCollider = GetComponent<Collider2D>();
        HideColliderHammer();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.resultPanal.activeSelf == false)
        {
            ShowHammer();
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("入力されてる");
                animator.SetTrigger("Move0");
            }
        }
       
    }

    void ShowHammer()
    {
        var mousePosition = Input.mousePosition;
        mousePosition.z = 10;
        var pos = Camera.main.ScreenToWorldPoint(mousePosition);
        hammerObject.transform.position = pos;
    }

    public void HideColliderHammer()
    {
        hammerCollider.enabled = false;
        Debug.Log("ハンマーコライダーが消えた");
    }
    public void ShowColliderHammer()
    {
        hammerCollider.enabled = true;
        Debug.Log("ハンマーコライダーがついた");
    }


}
