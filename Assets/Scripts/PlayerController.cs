using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float WalkingSpeed = 4f;
    [SerializeField]
    private float JumpForce = 5f;

    private Rigidbody Physics;
    private bool IsJumping = false;

    // Start is called once at the beginning
    private void Start()
    {
        Physics = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        Walk(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (Input.GetButton("Jump") && !IsJumping)
        {
            Jump();
        }
    }

    private void Walk(float horizontal, float vertical)
    {
        //transform.Translate(new Vector3(horizontal, 0f, vertical) * Time.deltaTime * WalkingSpeed);

        Vector3 forward = Camera.main.transform.forward;
        forward.y = 0;
        forward.Normalize();
        Vector3 right = Camera.main.transform.right;
        right.y = 0;
        right.Normalize();
        transform.position += horizontal * Time.deltaTime * WalkingSpeed * right + vertical * Time.deltaTime * WalkingSpeed * forward;
    }

    private void Jump()
    {
        Physics.AddForce(new Vector3(0, JumpForce, 0), ForceMode.Impulse);
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
