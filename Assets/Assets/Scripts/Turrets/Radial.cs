using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radial : Turret
{
    [Header("Radial Turret Settings")]
    public int barrelCount;
    public float turretRadius;

    private float rotateSpread;
    private GameObject[] barrel;
    private Quaternion barrelRot;

    // Use this for initialization
    void Start()
    {
        SpreadBarrels(barrelCount, turretRadius);
    }

    // Update is called once per frame
    protected override void Update()
    {
        LoadAndShoot();
    }

    // Used to evenly spread barrels across radius
    void SpreadBarrels(int barrelCount, float turretRadius)
    {
        barrel = new GameObject[barrelCount];
        float rotSpreadY;
        rotateSpread = (turretRadius / barrelCount);


        for (int i = 0; i < barrelCount; i++)
        {
            barrel[i] = barrelPrefab;
            rotSpreadY = rotateSpread * i;
            barrelRot = Quaternion.Euler(new Vector3(0, (rotSpreadY), 0));
            barrel[i].transform.rotation = barrelRot;

            Instantiate(barrel[i], gameObject.transform.position, barrelRot, gameObject.transform);
        }
    }

    // Used to shoot bullets from multiple barrels
    protected override void Shoot()
    {
        foreach (Transform item in GetComponentInChildren<Transform>())
        {
            Instantiate(bullet, item.transform.position, item.transform.rotation);
        }
    }
}
