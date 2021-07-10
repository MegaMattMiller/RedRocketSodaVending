
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class SodaCan : UdonSharpBehaviour
{
    public GameObject particleSystemHolder;
    public VRC_Pickup pickup;

    private bool isTipped = false;

    void Start()
    {
        particleSystemHolder.SetActive(false);
        isTipped = false;
    }

    void FixedUpdate()
    {
        float tilt = transform.up.y;
        // Debug.Log("tilt: " + tilt.ToString());

        if (tilt < 0.7f)
        {
            isTipped = true;
        }
        else
        {
            isTipped = false;
        }

        // Debug.Log("isTipped: " + isTipped.ToString());
        // Debug.Log("isHeld: " + pickup.IsHeld.ToString());

        if (pickup.IsHeld && isTipped)
        {
            particleSystemHolder.SetActive(true);
        }
        else
        {
            particleSystemHolder.SetActive(false);
        }
    }
}
