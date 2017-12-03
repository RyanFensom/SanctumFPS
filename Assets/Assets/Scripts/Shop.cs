using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        List<TurretClass> turrets = new List<TurretClass>();

        turrets.Add(new TurretClass("singleShot", 50, 0));
        turrets.Add(new TurretClass("speedShot", 150, 1));
        turrets.Add(new TurretClass("spreadShot", 250, 4));

        turrets.Sort();

        foreach (TurretClass turret in turrets)
        {
            print(turret.name + " " + turret.cost);
        }

        turrets.Clear();
    }
}
