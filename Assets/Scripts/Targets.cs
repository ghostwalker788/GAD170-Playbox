using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targets : MonoBehaviour
{
    public GameObject Self;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "NerfDart")
        {
            Invoke("destroy", 0.5f);
            Debug.Log("Target down");
        }
    }
    public void destroy()
    {
        Destroy(Self);
    }
}
