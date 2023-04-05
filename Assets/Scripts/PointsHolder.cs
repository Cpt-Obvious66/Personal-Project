using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsHolder : MonoBehaviour
{
    [SerializeField] private int pointValue;
    public int GetPointValue()
    {
        return pointValue;
    }
}
