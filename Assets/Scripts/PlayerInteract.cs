using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    bool player_detection = false;
    public static bool gameInShop;
    public GameObject ShopScreen;

    private void Update()
    {
       if (player_detection && Input.GetKeyDown(KeyCode.E))
        {
            gameInShop = !gameInShop;
            ShopScreen.SetActive(false);
            ShopOpen();
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
        if (other.name == "FPSPlayer")
        {
            player_detection = false;
        }
    }

    void ShopOpen()
    {
        if (gameInShop)
        {
            ShopScreen.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            ShopScreen.SetActive(false);
            Time.timeScale = 1f;
        }
    }

}
