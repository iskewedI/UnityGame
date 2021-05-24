using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    private float Velocity = 100f;
    [SerializeField]
    private Transform Player;

    [SerializeField]
    private EnemyController Enemy;
    [SerializeField]
    private float damage = 5f;

    private Rigidbody rb;
    private MeshRenderer renderer;
    private readonly Vector3 offset = new Vector3(0, -0.2319999f, 1.07f);

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        renderer = GetComponent<MeshRenderer>();

        renderer.enabled = false;
    }

    public void Shoot(Quaternion rotation)
    {
        renderer.enabled = true;
        transform.rotation = rotation;

        rb.AddForce(new Vector3(0, 0, Velocity), ForceMode.Impulse);

        //Invokes the function passed as a string after the given amount of seconds
        Invoke("BulletComeback", 1);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && renderer.enabled)
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector2(0, 5), ForceMode.Impulse);
            collision.gameObject.GetComponent<EnemyController>().LoseLife(damage);
        }
    }

    private void BulletComeback()
    {
        renderer.enabled = false;

        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        transform.position = Player.position + offset;
    }
}
