using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Movement
    [SerializeField]
    private float walkSpeed = 5f;
    [SerializeField]
    private float runSpeed = 15f;
    [SerializeField]
    private float currentSpeed = 0;

    private Vector3 direction;
    private Vector3 gravityVelocity;

    [SerializeField]
    private float gravityForce = -9.81f;
    [SerializeField]
    private float jumpHeight;

    [SerializeField]
    private Transform footsPosition;

    //States
    [SerializeField]
    private bool isGrounded;
    [SerializeField]
    private float groundCheckerSize;
    [SerializeField]
    private LayerMask groundMask;

    //Components
    private CharacterController controller;
    private Animator animator;

    // Start is called before the first frame update
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        MoveCharacter();

        if (isGrounded)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                StartCoroutine(Attack(1, 1.6f));
            }

            if (Input.GetButtonDown("Fire2"))
            {
                StartCoroutine(Attack(2, 2.8f));
            }
        }

    }

    private void MoveCharacter()
    {
        isGrounded = Physics.CheckSphere(footsPosition.position, groundCheckerSize, groundMask);

        float moveZ = Input.GetAxis("Vertical");

        direction = new Vector3(0, 0, moveZ);

        /* 
        Setea el forward de la direccion al forward actual del personaje, y no al general del mundo.
        Esto hará que rote dinamicamente y siempre vaya para adelante dependiendo de a donde esté mirando el personaje. 
        */
        direction = transform.TransformDirection(direction);

        if (isGrounded)
        {
            if (gravityVelocity.y < 0)
            {
                // Stop adding gravity
                gravityVelocity.y = -2f;
            }

            if (direction != Vector3.zero)
            {
                if (Input.GetAxis("Run") <= 0)
                {
                    //Walk
                    currentSpeed = walkSpeed;
                    animator.SetFloat("Speed", .5f, .1f, Time.deltaTime);
                }
                else
                {
                    //Run
                    currentSpeed = runSpeed;
                    animator.SetFloat("Speed", 1f, .1f, Time.deltaTime);

                }
            }
            else
            {
                //Idle
                animator.SetFloat("Speed", 0f, .1f, Time.deltaTime);
            }

            direction *= currentSpeed;

            if (Input.GetAxis("Jump") > 0)
            {
                //Jump
                gravityVelocity.y = Mathf.Sqrt(jumpHeight * -2 * gravityForce);
            }
        }

        controller.Move(direction * Time.deltaTime);

        gravityVelocity.y += gravityForce * Time.deltaTime;
        controller.Move(gravityVelocity * Time.deltaTime);
    }

    private IEnumerator Attack(int type, float waitTime)
    {
        int attackLayerIndex = animator.GetLayerIndex("Attack Layer");

        animator.SetLayerWeight(attackLayerIndex, 1);
        animator.SetTrigger($"Attack{type}");

        yield return new WaitForSeconds(waitTime);

        animator.SetLayerWeight(attackLayerIndex, 0);
    }
}
