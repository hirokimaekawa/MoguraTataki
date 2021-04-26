using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoguraManager : MonoBehaviour
{
    Collider2D moguraCollider;
    Animator animator;
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        animator = GetComponent<Animator>();
        moguraCollider = GetComponent<Collider2D>();
        HideColliderMogura();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void HideColliderMogura()
    {
        moguraCollider.enabled = false;
        Debug.Log("モグラコライダーが消えた");
    }
    public void ShowColliderMogura()
    {
        moguraCollider.enabled = true;
        Debug.Log("モグラコライダーがついた");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //次やること、攻撃を受けたら、得点が追加される
        animator.SetTrigger("Hurt");
        gameManager.AddScore();
        HideColliderMogura();
    }
}
