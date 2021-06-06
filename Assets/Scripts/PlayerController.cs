using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float WalkingSpeed = 2.4f;
    [SerializeField]
    private float RunningSpeed = 4f;
    [SerializeField]
    private float JumpForce = 5.6f;
    [SerializeField]
    private float MovementNormalizer = 0.025f;

    private Rigidbody Rb;
    private bool IsJumping = false;

    // Start is called once at the beginning
    private void Start()
    {
        Rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump") && !IsJumping)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //if (Input.GetKeyDown(KeyCode.LeftControl))
        //{
        //    MoveCharacter(Input.GetAxis("Horizontal") * Time.deltaTime, Input.GetAxis("Vertical") * Time.deltaTime, RunningSpeed);
        //}

        MoveCharacter(horizontal * Time.deltaTime, vertical * Time.deltaTime, WalkingSpeed);
    }

    private void MoveCharacter(float horizontal, float vertical, float speed)
    {
        Vector3 forward = Camera.main.transform.forward;
        forward.y = 0;
        forward.Normalize();

        Vector3 right = Camera.main.transform.right;
        right.y = 0;
        right.Normalize();

        transform.position += horizontal * speed * right + vertical * speed * forward;

        if (horizontal != 0 || vertical != 0)
        {
            Vector3 lookRotation = new Vector3(horizontal, 0, vertical);

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookRotation.normalized), MovementNormalizer);
        }
    }

    private void Jump()
    {
        Rb.AddForce(new Vector3(0, JumpForce, 0), ForceMode.Impulse);
        IsJumping = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            IsJumping = false;
        }
    }
}
