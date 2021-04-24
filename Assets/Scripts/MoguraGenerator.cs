using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoguraGenerator : MonoBehaviour
{
    public GameObject moguraPrefab;
    bool isThereMogura;
    public Collider moguraCollider;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SpawnMogura()
    {
        GameObject monster = Instantiate(moguraPrefab);
        monster.transform.SetParent(transform, false);
        isThereMogura = true;
        if (isThereMogura == true)
        {
            Debug.Log("成功");
        }
    }
    public void HideColliderMogura()
    {
        moguraCollider.enabled = false;
    }
    public void ShowColliderMogura()
    {
        moguraCollider.enabled = true;
    }
}

