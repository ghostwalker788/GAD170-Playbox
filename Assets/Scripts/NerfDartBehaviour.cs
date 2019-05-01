using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Aligns self to velocity, if speed is above a small tolerance. Purely visual niceity.
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class NerfDartBehaviour : MonoBehaviour
{
    public GameObject Self;
    protected new Rigidbody rigidbody;
    public int APT = 0;
    public int TRPC = 0;
    public int TRSC = 1;
    public int TRPG = 0;
    public Target target;
    public NerfGunItem Nerf;


    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        Invoke("Despawn", 20.0f);
        APT = 1;
        target = FindObjectOfType<Target>();
        Invoke("GatherTRSC", 0.0f);
    }

    private void LateUpdate()
    {
        //align to direction of travel if we are moving fast enough, small tolerance prevents jitter due to forcing a rotation on
        // an object with colliders that will then have new overlaps and be physic'ed apart
        if (rigidbody.velocity.sqrMagnitude > 0.5f)
            transform.rotation = Quaternion.LookRotation(rigidbody.velocity.normalized, Vector3.up);
    }
    private void Despawn()
    {
        Destroy(Self);
    }
    public void GatherTRSC()
    {
        target.SendTRSC();
        //Debug.Log("looking for target range shot cout");
    }
    public void ReciveTRSC(int amount)
    {
        //Debug.Log("data recived");
        if(amount > 0)
        {
            TRPG = 1;
            TRSC = amount;
            //Debug.Log("still have shots");
        }
        
    }



    private void OnCollisionEnter(Collision collision)
    { 
            if (collision.gameObject.tag == "bulls eye")
            {
                if (APT == 1)
                {
                    APT = 0;
                     
                    
                        TRPC = 15;
                        target.Targethit(TRPC);
                    
                }
            }
            if (collision.gameObject.tag == "10 pints")
            {
                if (APT == 1)
                {
                    APT = 0;
                     
                    
                        TRPC = 10;
                        target.Targethit(TRPC);
                    
                }
            }
            if (collision.gameObject.tag == "8 ponts")
            {
                if (APT == 1)
                {
                    APT = 0;
                     
                    
                        TRPC = 8;
                        target.Targethit(TRPC);
                    
                }
            }
            if (collision.gameObject.tag == "6 ponts")
            {
                if (APT == 1)
                {
                    APT = 0;
                     
                    
                        TRPC = 6;
                        target.Targethit(TRPC);
                    
                }
            }
            if (collision.gameObject.tag == "4 points")
            {
                if (APT == 1)
                {
                    APT = 0;
                     
                    
                        TRPC = 4;
                        target.Targethit(TRPC);
                    
                }
            }
            if (collision.gameObject.tag == "2 points")
            {
                if (APT == 1)
                {
                    APT = 0;
                     
                    
                        TRPC = 2;
                        target.Targethit(TRPC);
                }
            }
        }
}
