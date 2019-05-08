using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targets : MonoBehaviour
{
    public GameObject Self;
    public Vector3 MoveDerection;
    public Transform LeftTrancform;
    public Transform RightTrancform;
    // Start is called before the first frame update
    void Start()
    {
        MoveDerection = RightTrancform.position;
        //move vector x at -1m/s
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, MoveDerection, 1 * Time.deltaTime);
        if (MoveDerection == RightTrancform.position)
        {
            if (Vector3.Distance(transform.position, MoveDerection) <= 1.0f)
            {

                if (MoveDerection == RightTrancform.position)
                {
                    MoveDerection = LeftTrancform.position;
                }
            }
        }

        //Debug.Log(Vector3.Distance(transform.position, MoveDerection));

        if (MoveDerection == LeftTrancform.position)
        {
            if (Vector3.Distance(transform.position, MoveDerection) <= 1.0f)
            {
                if (MoveDerection == LeftTrancform.position)
            {
                MoveDerection = RightTrancform.position;
            }
        }
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "NerfDart")
        {
            //Invoke("destroy", 0.5f);
            Debug.Log("Target hit");
        }
        /*if (other.gameObject.tag == "right wall")
        {
            //move vector x at 1m/s
            MoveDerection = LeftTrancform.position;
            Debug.Log("Hit right wall");
        }
        if (other.gameObject.tag == "left wall")
        {
            //move vector x at -1m/s
            MoveDerection = RightTrancform.position;
            Debug.Log("Hit left wall");
        }*/
    }
    public void destroy()
    {
        Destroy(Self);
    }
}
//make the targo go from left to right
//when hit wall bounce to the outher wall
