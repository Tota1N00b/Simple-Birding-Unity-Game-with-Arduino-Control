using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class CamMove : MonoBehaviour
{
    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    public float minXRotation = -10f; // The minimum rotation on the x axis
    public float maxXRotation = 25f; // The maximum rotation on the x axis
    public float minYRotation = -50f; // The minimum rotation on the y axis
    public float maxYRotation = 17f; // The maximum rotation on the y axis

    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        Cursor.visible = false;
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        yaw = Mathf.Clamp(yaw, minXRotation, maxXRotation);
        //the rotation range
        pitch = Mathf.Clamp(pitch, minYRotation, maxYRotation);
        //the rotation range

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }

}
