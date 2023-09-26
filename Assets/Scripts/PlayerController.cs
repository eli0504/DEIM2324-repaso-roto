using System;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static PlayerController sharedInstance;

    [SerializeField] private float movementSpeed = 10.0f;
    [SerializeField] private float rotationSpeed = 50.0f;

    private float horizontalInput, verticalInput;

    private float defaultLimit = 25;
    private float leftLimit, rightLimit, forwardLimit, backLimit;

    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        ChangeMovementLimits(-defaultLimit, defaultLimit, defaultLimit, -defaultLimit);
    }

    private void update()
    {
        Movement();
        KeepBetweenLimits();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        } 
    }

    private void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Horizontal");
        
        // Rotamos con el eje horizontal
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime * verticalInput);
        // Movemos con el eje vertical
        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime * verticalInput);
    }

    public void ChangeMovementLimits(float left, float right, float forward, float back)
    {
        leftLimit = left;
        rightLimit = right;
        forwardLimit = forward;
        backLimit = back;
    }

    private void KeepBetweenLimits()
    {
        Vector3 pos = transform.position;

        if (pos.x < leftLimit)
        {
            transform.position = new Vector3(leftLimit, pos.y, pos.z);
            return;
        }
        
        if (pos.x > rightLimit)
        { 
            transform.position = new Vector3(rightLimit, pos.y, pos.z);
            return;
        }
        
        if (pos.z < backLimit)
        {
            transform.position = new Vector3(pos.x, pos.y, backLimit);
            return;
        }
        
        if (pos.z > forwardLimit)
        {
            transform.position = new Vector3(pos.x, pos.y, forwardLimit);
            return;
        }
    }
}
