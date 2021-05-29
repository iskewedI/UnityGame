using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour

{
    [SerializeField]
    private float Speed = 1.0f;
    [SerializeField]
    private float JumpForce = 1.0f;

    private Rigidbody Physics;
    private bool isJumping;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Physics = GetComponent<Rigidbody>();
    }


    void Update()
    {
        //Movimiento del jugador//
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horizontal, 0.0f, vertical) * Time.deltaTime * Speed);

        //Salto// 
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            Physics.AddForce(new Vector3(0, JumpForce, 0), ForceMode.Impulse);
            isJumping = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isJumping = false;
        }
    }
}
