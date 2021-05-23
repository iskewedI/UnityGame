using UnityEngine;
using System.Threading.Tasks;
using System;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    private float Velocity = 100f;

    private Rigidbody rb;
    private MeshRenderer renderer;
    private GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        renderer = GetComponent<MeshRenderer>();

        renderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {   
    }

    public void Shoot()
    {
        renderer.enabled = true;
        rb.AddForce(new Vector3(0, 0, Velocity), ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && renderer.enabled)
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector2(0, 5), ForceMode.Impulse);

            //Invokes the function passed as a string after the given amount of seconds
            Invoke("BulletComeback", 1);
        }
    }

    private void BulletComeback()
    {
        //TODO: Make the bullet teleport back to the player
    }
}
