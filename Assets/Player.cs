using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rigidbody;

    private Animator animator;

    [SerializeField]
    private float Fuerza = 20f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            // transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
            // rigidbody.AddForce(transform.up *  Fuerza, ForceMode.Impulse);
            animator.SetBool("isJumping", true);
            
            
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
        }

   
    }
}
