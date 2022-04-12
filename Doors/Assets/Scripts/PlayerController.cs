using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    [Header("Movement")]
    [SerializeField] Transform playerCamera = null;
    public float moveSpeed = 6f;
    float movementMultiplier = 10f;
   
    float rbDrag = 6;
    float horizontalMovement;
    float verticalMovement;
    
    Vector3 moveDirection;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        
    }

    // Update is called once per frame
    private void Update()
    {  
        
    
        MyInput();
        ControlDrag();
        //RotatePlayer();
    }

    void MyInput()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");

        moveDirection = transform.forward * verticalMovement + transform.right * horizontalMovement;
    }

    void ControlDrag()
    {
        rb.drag = rbDrag;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        rb.AddForce(moveDirection.normalized * moveSpeed * movementMultiplier, ForceMode.Acceleration);
    }

    void RotatePlayer()
    {
        var speed = 0.01f;
        if (Input.GetKey(KeyCode.Q))
      transform.Rotate(Vector3.right, speed * Time.deltaTime);
     
  if (Input.GetKey(KeyCode.E))
      transform.Rotate(-Vector3.right, speed * Time.deltaTime);
    }

}
