using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    bool player_detection = false;

    private void Update()
    {
       if (player_detection && Input.GetKeyDown(KeyCode.E))
        {
            print("Test text");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "FPSPlayer")
        {
            player_detection = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "PlayerBody")
        {
            player_detection = false;
        }
    }
}
