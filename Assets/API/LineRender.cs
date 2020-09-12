using System;
using System.Collections.Generic;
using System.Security.Principal;
using UnityEngine;
using System.Collections;

public class LineRender : MonoBehaviour
{
    LineRenderer line;
    public Transform star;
    public Transform end;

    void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    void Update()
    {
        line.SetPosition(0,star.position);
        line.SetPosition(1,end.position);

    }

}
