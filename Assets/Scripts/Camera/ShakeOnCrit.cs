using UnityEngine;
using System.Collections;

public class ShakeOnCrit : CamShake
{

    void Awake()
    {
         base.duration = 0.1f;
         base.magnitude = 1f;
    }
}
