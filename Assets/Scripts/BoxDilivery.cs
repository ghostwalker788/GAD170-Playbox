using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BoxDilivery : MonoBehaviour
{
    public UnityEvent DiliveryTask;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "blue box")
        {
            //add point to box dilivery task
            DiliveryTask?.Invoke();
            //remove the box in questiuon
            Destroy(collision.transform.gameObject);
        }

    }
}
