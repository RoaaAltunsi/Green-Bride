using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockRegion1 : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // Check if the user presses the '3'
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            DeleteObject();
        }

    }
    void DeleteObject()
    {
        // Destroy the GameObject this script is attached to
        Destroy(gameObject);
    }
}
