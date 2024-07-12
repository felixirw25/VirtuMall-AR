using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float acceleration;
    [SerializeField] float deceleration;
    [SerializeField] Button interactButton;
    public FixedJoystick moveJoystick;
    public Rigidbody rb;
    public Transform characterPos;
    public float speed;
    public bool isMoving;
    string currentSceneName;

    void Start(){
        DontDestroyOnLoad(this);
        this.transform.GetChild(3).GetChild(0).gameObject.SetActive(false);
        this.transform.GetChild(3).GetChild(3).gameObject.SetActive(false);
        // Get the Rigidbody component attached to the character GameObject
        characterPos = GetComponent<Transform>();

        // Freeze rotation along all axes to prevent rotation upon collision
        rb.freezeRotation = true;

        // interactButton = GameObject.FindGameObjectWithTag("InteractButton").GetComponent<Button>();
    }
    private void FixedUpdate(){
        float x = moveJoystick.Horizontal; //Equals the joystick handle's position from the center of the joystick on the horizontal axis
        float z = moveJoystick.Vertical; //Equals the joystick handle's position from the center of the joystick on the vertical axis

        if(Camera.main!=null){
            Vector3 moveDirection = Camera.main.transform.forward * x + Camera.main.transform.forward * z; //Direction of movement

            speed = Mathf.Clamp(speed, 0, 5);

            if(x!=0f || z!=0f){
                isMoving = true;
                speed += acceleration*Time.deltaTime;
            }
            else{
                isMoving = false;
                speed -= deceleration*Time.deltaTime;
            }

            animator.SetBool("IsMoving", isMoving);

            // Calculate the new position of the character
            Vector3 newPosition = transform.position + moveDirection.normalized * speed * Time.deltaTime;

            // Move the character to the new position
            rb.MovePosition(newPosition);

            // Rotate the character to face the movement direction based on the camera's rotation
            if (moveDirection != Vector3.zero)
            {
                Quaternion newRotation = Quaternion.LookRotation(moveDirection);
                rb.MoveRotation(newRotation);
            }
        }

        // Get the current scene's name
        currentSceneName = SceneManager.GetActiveScene().name;

        // Print the current scene's name to the console
        Debug.Log("Current Scene: " + currentSceneName);

        if(currentSceneName=="SuperMarket"){
            gameObject.transform.GetChild(2).GetComponent<AudioListener>().enabled = false;
            gameObject.transform.GetChild(2).GetComponent<AudioSource>().enabled = false;
        }
        else{
            gameObject.transform.GetChild(2).GetComponent<AudioListener>().enabled = true;
            gameObject.transform.GetChild(2).GetComponent<AudioSource>().enabled = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Interact"){
            interactButton.interactable = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Interact"){
            interactButton.interactable = false;
        }
    }
}
