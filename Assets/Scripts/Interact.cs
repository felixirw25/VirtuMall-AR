using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interact : MonoBehaviour
{
    [SerializeField] Button interactButton;
    [SerializeField] GameObject furnitureCanvas;
    private void Start(){
        interactButton = GetComponent<Button>();
        interactButton.interactable = false;
        furnitureCanvas = GameObject.Find("FurnitureCanvas");
        if(furnitureCanvas!=null){
            furnitureCanvas.SetActive(false);
        }
    }

    private void Update(){
        if(furnitureCanvas==null){
            furnitureCanvas = GameObject.Find("FurnitureCanvas");
        }
    }

    // Assign this method to the Button component's OnClick event in the Unity Editor
    public void OnButtonClick()
    {
        // Handle the button click logic here
        Debug.Log("Button Clicked!");
        furnitureCanvas.GetComponent<Canvas>().enabled = true;
        Camera.main.gameObject.SetActive(false);
    }
}
