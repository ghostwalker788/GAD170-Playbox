using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int AttempCount = 0;
    public int TRPC;
    public NerfDartBehaviour Dart;
    public NerfDartBehaviour[] Dartlist;
    public int DLC;
    public NerfGunItem gun;
    // Start is called before the first frame update
    void Start()
    {
        gun = FindObjectOfType<NerfGunItem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (AttempCount == 0)
        {
            gun.TRoff();
        }
        if (Input.GetKeyDown(KeyCode.Backslash))
        {
            targetRangeOn();
        }

    }
    public void Targethit(int amount)
    {
        if (AttempCount > 0)
        {
            TRPC += amount;
            Debug.Log("ding +" + amount + " points total is now " + TRPC);
            Debug.Log("Atempts left " + AttempCount);
        }
        else if (AttempCount == 0)
        {
            Debug.Log("please press the button to start");
        }
    }
    public void SendTRSC()
    {
        Dartlist = FindObjectsOfType<NerfDartBehaviour>();
        DLC = Dartlist.Length;
        Dart = Dartlist[DLC-1];
        Dart.ReciveTRSC(AttempCount);
        //Debug.Log(Dart);
        //Debug.Log("request recived seding data");
    }
    public void GunFired()
    {
        AttempCount -= 1;
        gun.FireRateCalc();
    }
    public void targetRangeOn()
    {
        AttempCount = 15;
        gun.TRA();
        TRPC = 0;
        Debug.Log("target range on");
    }
}

//need to on button press spawn target and tell the gun the range is on
// send core to board
// reset on second button press
//keep highest score but display most recent score
// when the range stops destroy the target after 2 seconds
//have a counter in the booth (optional)

