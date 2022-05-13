using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private int _unitNumber;
    public int UnitNumber
    {
        get { return _unitNumber; }
    
         set 
        {
            if (value != 1 && value != 2)
            {
                throw new IndexOutOfRangeException("Unit number is not valid on: " + gameObject.name);
            }
            _unitNumber = value;
        }
    }
    private void Start()
    {
        UnitNumber = 1;
    }
}
