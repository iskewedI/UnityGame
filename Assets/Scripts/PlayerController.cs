using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float Speed = 1f;
    [SerializeField]
    private float JumpForce = 1f;

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
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horizontal, 0f, vertical) * Time.deltaTime * Speed);

        if (Input.GetButton("Jump") && !IsJumping)
        {
            Physics.AddForce(new Vector3(0, JumpForce, 0), ForceMode.Impulse);
            IsJumping = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            IsJumping = false;
        }
    }
}
