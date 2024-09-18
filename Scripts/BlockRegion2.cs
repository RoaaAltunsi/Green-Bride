using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockRegion2 : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // Check if the user presses the '4'
        if (Input.GetKeyDown(KeyCode.Alpha4))
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
