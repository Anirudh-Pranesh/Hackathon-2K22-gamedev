using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float movespeed = 9f;
    float horizontalmovement;
    float verticalmovement;
    Vector3 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb.freezeRotation = true;
    }

    void myinput()
    {
        horizontalmovement = Input.GetAxisRaw("Horizontal");
        verticalmovement = Input.GetAxisRaw("Vertical");

        moveDirection = transform.forward * verticalmovement + transform.right * horizontalmovement;

    }

    // Update is called once per frame
    void Update()
    {
        myinput();

        if (Input.GetKeyDown("space"))
        {
            rb.AddForce(0, 300, 0, ForceMode.Acceleration);
        }
    }

    private void FixedUpdate()
    {
        moveplayer();
    }

    void moveplayer()
    {
        rb.AddForce(moveDirection.normalized * movespeed , ForceMode.Acceleration);
    }
}
