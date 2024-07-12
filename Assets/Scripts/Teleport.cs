using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    [SerializeField] string targetScene;
    public Canvas teleportCanvas;
    public Text warningText;
    public Text countdownText;
    [SerializeField] private bool isTeleporting = false;
    [SerializeField] int i = 3;

    void Start()
    {
        i = 3;
        isTeleporting = false;
        teleportCanvas.gameObject.SetActive(false);
    }

    void Update(){
        if(i==0 && isTeleporting && targetScene=="SuperMarket"){
            // Load the target scene after countdown
            SceneManager.LoadScene(targetScene);

            // Set the character's position after teleporting to the new scene
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                player.transform.position = new Vector3(1.218f, 0.22f, 2.168f);
            }
        }

        if(i==0 && isTeleporting && targetScene=="City"){
            // Load the target scene after countdown
            SceneManager.LoadScene(targetScene);

            // Set the character's position after teleporting to the new scene
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                player.transform.position = new Vector3(28.67f, 0.22f, 98.42f);
            }
        }
    }

    // OnTriggerEnter is called when this object enters another collider marked as trigger
    void OnTriggerEnter(Collider other)
    {
        if (!isTeleporting && other.tag == "Player" && this.tag == "Teleporter")
        {
            Debug.Log("other: " + other.name);
            StartCoroutine(StartTeleportation());
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (isTeleporting && other.tag == "Player" && this.tag == "Teleporter")
        {
            // If player exits the trigger, cancel the teleportation
            StopTeleportation();
        }
    }

    IEnumerator StartTeleportation()
    {
        i = 3;
        isTeleporting = true;
        teleportCanvas.gameObject.SetActive(true);
        warningText.text = "Kamu akan pergi ke " + targetScene;

        // Display countdown
        for (i = 3; i > 0; i--)
        {
            countdownText.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }
    }

    void StopTeleportation()
    {
        Debug.Log("Batal Teleportasi");
        // Stop the coroutine if it is running
        if (isTeleporting)
        {
            StopCoroutine(StartTeleportation());
            isTeleporting = false;
            i = 3;
            warningText.text = "";
            countdownText.text = "";
            teleportCanvas.gameObject.SetActive(false);
        }
    }
}
