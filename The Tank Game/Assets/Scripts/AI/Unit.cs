using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public int unitNumber
    {
        get { return unitNumber; }

        set 
        {
            if (value != 1 && value != 2)
            {
                throw new IndexOutOfRangeException("Unit number is not valid on: " + gameObject.name);
            }
            unitNumber = value;
        }
    }
}
