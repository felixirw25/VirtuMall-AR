using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FurnitureSelection : MonoBehaviour
{
    [SerializeField] GameObject furnitureCanvas;
    [SerializeField] GameObject AR;
    [SerializeField] GameObject player;
    public List<Texture> furnitureTextures; // List of sprites to choose from
    public List<Sprite> imageSprites; // List of sprites to choose from
    public Image imageDisplay; // Image component to display the selected sprite
    private int currentIndex = 0; // Index of the currently displayed sprite

    void Start()
    {
        furnitureCanvas = GameObject.FindGameObjectWithTag("FurnitureCanvas");
        player = GameObject.FindGameObjectWithTag("Player");
        // furnitureCanvas.GetComponent<Canvas>().enabled = false;
        // Ensure there are sprites in the list
        if (imageSprites.Count > 0)
        {
            // Set the initial sprite
            UpdateImageDisplay();
        }
        else
        {
            Debug.LogError("No sprites assigned to the imageSprites list.");
        }
    }

    public void NextImage()
    {
        // Move to the next sprite in the list
        currentIndex = (currentIndex + 1) % imageSprites.Count;
        UpdateImageDisplay();
    }

    public void PreviousImage()
    {
        // Move to the previous sprite in the list
        currentIndex = (currentIndex - 1 + imageSprites.Count) % imageSprites.Count;
        UpdateImageDisplay();
    }

    public void Exit()
    {
        furnitureCanvas.GetComponent<Canvas>().enabled = false;
        player.transform.GetChild(2).gameObject.SetActive(true);
        player.transform.GetChild(3).GetChild(0).gameObject.SetActive(false);
        player.transform.GetChild(3).GetChild(1).gameObject.SetActive(true);
        player.transform.GetChild(3).GetChild(2).gameObject.SetActive(true);
        player.transform.GetChild(3).GetChild(3).gameObject.SetActive(false);
        Camera.main.gameObject.SetActive(true);
    }

    private void UpdateImageDisplay()
    {
        // Update the displayed sprite
        imageDisplay.sprite = imageSprites[currentIndex];
    }

    public void Preview()
    {
        // AR.SetActive(true);
        furnitureCanvas.GetComponent<Canvas>().enabled = false;
        AR.transform.GetChild(0).GetComponent<Camera>().enabled = true;
        AR.transform.GetChild(1).GetComponent<AR>().enabled = true;
        AR.transform.GetChild(currentIndex+2).gameObject.SetActive(true);
        player.transform.GetChild(3).GetChild(0).gameObject.SetActive(true);
        // player.transform.GetChild(3).GetChild(1).gameObject.SetActive(false);
        // player.transform.GetChild(3).GetChild(2).gameObject.SetActive(false);
        // player.transform.GetChild(3).GetChild(3).gameObject.SetActive(true);
    }
}

