using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OffPreview : MonoBehaviour
{
    [SerializeField] GameObject arCamera;
    [SerializeField] GameObject furnitureCanvas;
    private void Start(){
        arCamera = GameObject.FindGameObjectWithTag("ARCamera");
        furnitureCanvas = GameObject.FindGameObjectWithTag("FurnitureCanvas");
    }

    // Assign this method to the Button component's OnClick event in the Unity Editor
    public void PreviewOff()
    {
        for(int i = 2; i < arCamera.transform.childCount; i++){
            arCamera.transform.GetChild(i).gameObject.SetActive(false);
        }
        furnitureCanvas.GetComponent<Canvas>().enabled = true;
        arCamera.transform.GetChild(0).GetComponent<Camera>().enabled = false;
        arCamera.transform.GetChild(1).GetComponent<AR>().enabled = false;
        furnitureCanvas.GetComponent<Canvas>().enabled = true;
    }
}
