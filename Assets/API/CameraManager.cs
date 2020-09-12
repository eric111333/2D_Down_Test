using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public float downSpeed;
    private Transform tra;
    void Start()
    {
        tra = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(0, -downSpeed * Time.deltaTime, 0);
    }
}
