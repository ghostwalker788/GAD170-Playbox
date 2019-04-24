using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int AttempCount = 15;
    public int TRPC;
    public NerfDartBehaviour Dart;
    public NerfDartBehaviour[] Dartlist;
    public int DLC;
    public NerfGunItem gun;
    public player
    // Start is called before the first frame update
    void Start()
    {
        gun = FindObjectOfType<NerfGunItem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(AttempCount == 0)
        {
            gun.TRoff();
        }
        if(Input.GetKeyDown(KeyCode.Backslash))
        {
            targetRangeOn();
        }

    }
    public void Targethit(int amount)
    {
        TRPC += amount;
        Debug.Log("ding +" + amount + " points total is now " + TRPC);
    }
    public void SendTRSC()
    {
        Dartlist = FindObjectsOfType<NerfDartBehaviour>();
        DLC = Dartlist.Length;
        Dart = Dartlist[DLC-1];
        Dart.ReciveTRSC(AttempCount);
    }
    public void GunFired()
    {
        AttempCount -= 1;
    }
    public void targetRangeOn()
    {
        gun.TRA();
    }
}
