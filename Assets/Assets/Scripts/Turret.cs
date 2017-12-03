using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TurretClass : IComparable<TurretClass>
{
    public string name;
    public int cost;
    public float detail;

    public TurretClass(string newName, int newCost, float newDetail)
    {
        name = newName;
        cost = newCost;
        detail = newDetail;
    }

    public int CompareTo(TurretClass other)
    {
        if (other == null)
        {
            return 1;
        }

        return cost - other.cost;
    }
}
