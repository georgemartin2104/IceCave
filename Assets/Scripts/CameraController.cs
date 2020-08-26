using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float cameraSpeed;
    public float mouseSensitivity;
    public GameObject liftPlatform;
    public float delay;
    public float currentTime = 0;
    private Vector3 lastMouse = new Vector3(255, 255, 255); // Sets the mouse to the middle of the screen
    private float runTime = 1.0f;
   
    // Update is called once per frame
    void Update()
    {
        Vector3 offset = new Vector3(0, 6, 0);
        currentTime = currentTime + Time.deltaTime;
        if (currentTime < delay)
        {
            this.transform.position = liftPlatform.transform.position + offset;
        }

        // Mouse controls for camera
        lastMouse = Input.mousePosition - lastMouse;
        lastMouse = new Vector3(-lastMouse.y * mouseSensitivity, lastMouse.x * mouseSensitivity, 0);
        lastMouse = new Vector3(transform.eulerAngles.x + lastMouse.x, transform.eulerAngles.y + lastMouse.y, 0);
        transform.eulerAngles = lastMouse;
        lastMouse = Input.mousePosition;

        if (currentTime > delay)
        {
            Vector3 p = GetInput();
            runTime = Mathf.Clamp(runTime * 0.5f, 1f, 1000f);
            p = p * cameraSpeed;
            p = p * Time.deltaTime;
            transform.Translate(p);
        }
    }

    // Get Keyboard commands
    private Vector3 GetInput()
    {
        Vector3 direction = new Vector3();
        if (Input.GetKey (KeyCode.W))
        {
            direction += new Vector3(0, 0, 1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += new Vector3(0, 0, -1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += new Vector3(1, 0, 0);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            direction += new Vector3(0, 1, 0);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            direction += new Vector3(0, -1, 0);
        }
        return direction;
    }
}
