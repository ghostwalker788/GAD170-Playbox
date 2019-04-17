using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Item that when used while held acts as a physics based projectile instantiator
/// </summary>
public class NerfGunItem : InteractiveItem
{
    public GameObject nerfDartPrefab;
    public Transform nerfDartSpawnLocation;
    public float fireRate = 1;
    public float launchForce = 10;
    protected float fireRateCounter;
    public int canFire = 1;

    protected void Update()
    {
    }

    public override void OnUse()
    {
        if (canFire == 1)
        {
            base.OnUse();
            FireNow();
            canFire = 0;
            Invoke("FireRateCalc", fireRate);
        }
        //TODO: we need to determine if we can fire and if so, make the thing
    }

    public void FireNow()
    {
        //TODO: this is where we would actually create the thing and get it on its way

        GameObject clone = Instantiate(nerfDartPrefab, nerfDartSpawnLocation.position, Quaternion.identity);
        clone.GetComponent<Rigidbody>().AddForce(nerfDartSpawnLocation.forward * launchForce);
    }
    public void FireRateCalc()
    {
        canFire = 1;
    }
}
