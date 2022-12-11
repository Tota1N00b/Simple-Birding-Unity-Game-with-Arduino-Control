using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class FocusControl : MonoBehaviour
{
    public PostProcessVolume volume;
    DepthOfField dof;
    float step = 0.1f;

    Camera cam;
    float camStep = 1f;

    void Start()
    {
        volume.profile.TryGetSettings(out dof);
        cam = Camera.main;
    }

    private void FixedUpdate()
    {
        /*---------- Focus ----------*/
        if (Input.GetKey(KeyCode.Q))
        {
            if(PublicVars.focus<=10 && PublicVars.focus > -10)
                PublicVars.focus -= step;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            if (PublicVars.focus < 10 && PublicVars.focus >= -10)
                PublicVars.focus += step;
        }

        // Robustness
        if (PublicVars.focus > 10)
            if (Input.GetKey(KeyCode.Q))
                PublicVars.focus -= step;
        if (PublicVars.focus < -10)
            if (Input.GetKey(KeyCode.E))
                PublicVars.focus += step;

        //update the focus value
        dof.focalLength.value = Mathf.Abs(PublicVars.focus);

        /*---------- Cam scale ----------*/
        if (Input.GetKey(KeyCode.I))
        {
            if (PublicVars.scale <= 38 && PublicVars.scale > 0)
            {
                PublicVars.scale -= camStep;
                blur();
            }
        }
        else if (Input.GetKey(KeyCode.O))
        {
            if (PublicVars.scale < 38 && PublicVars.scale >= 0)
            {
                PublicVars.scale += camStep;
                blur();
            }
        }

        // Robustness
        if (PublicVars.scale > 38)
            if (Input.GetKey(KeyCode.I))
                PublicVars.scale -= camStep;
        if (PublicVars.scale < 0)
            if (Input.GetKey(KeyCode.O))
                PublicVars.scale += camStep;

        //update the fov value
        cam.fieldOfView = Mathf.Abs(PublicVars.scale);
    }

    void blur()
    {
        if (PublicVars.focus >= 0)
        {
            if (PublicVars.focus < 10)
                PublicVars.focus += step * 5;
        }
        else
        {
            if (PublicVars.focus > -10)
                PublicVars.focus -= step * 5;
        }
    }
}
