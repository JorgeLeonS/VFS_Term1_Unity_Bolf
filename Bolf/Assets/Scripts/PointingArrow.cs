using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointingArrow : MonoBehaviour
{
    public float start;
    public float end;

    public float speed = 2.0f;

    // Update is called once per frame
    void Update()
    {
        SetPos(start, end);
    }

    void SetPos(float start, float end)
    {
        float rotZ = Mathf.SmoothStep(start, end, Mathf.PingPong(Time.time * speed, 1));
        transform.rotation = Quaternion.Euler(90, 90, rotZ);
    }
}
