using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorController : Ball
{
    public Transform indicatorPosition;

    private void Update()
    {
        transform.position = indicatorPosition.position;
    }
}