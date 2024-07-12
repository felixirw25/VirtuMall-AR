using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private void Start()
    {
        // Check if the player object with the tag "Player" already exists in the scene
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        // If player object does not exist, instantiate it (Don'tDestroyOnLoad ensures it persists across scenes)
        if (player == null)
        {
            GameObject playerPrefab = Resources.Load<GameObject>("Character"); // Load player prefab from Resources folder
            player = Instantiate(playerPrefab);
            player.tag = "Player"; // Ensure the instantiated player has the correct tag
            DontDestroyOnLoad(player);
        }
    }
}
