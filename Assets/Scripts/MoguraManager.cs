using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoguraManager : MonoBehaviour
{
    public Collider moguraCollider;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
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
