using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleControl : MonoBehaviour
{
    Camera cam;
    float step = 1f;

    void Start()
    {
        cam = Camera.main;
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.I))
        {
            if (PublicVars.scale <= 38 && PublicVars.scale > 0)
                PublicVars.scale -= step;
        }
        else if (Input.GetKey(KeyCode.O))
        {
            if (PublicVars.scale < 38 && PublicVars.scale >= 0)
                PublicVars.scale += step;
        }

        // Robustness
        if (PublicVars.scale > 38)
            if (Input.GetKey(KeyCode.I))
                PublicVars.scale -= step;
        if (PublicVars.scale < 0)
            if (Input.GetKey(KeyCode.O))
                PublicVars.scale += step;

        //update the fov value
        cam.fieldOfView = Mathf.Abs(PublicVars.scale);
    }
}
