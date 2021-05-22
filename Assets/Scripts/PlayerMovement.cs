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

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Physics = GetComponent<Rigidbody>();
    }


    void Update()
    {
        //Movimiento del jugador//
        float horitzontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horitzontal, 0.0f, vertical) * Time.deltaTime * Speed);

        //Salto// 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Physics.AddForce(new Vector3(0, JumpForce, 0), ForceMode.Impulse);
        }
    }
}
