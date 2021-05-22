using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    private float Velocity = 100f;

    private Rigidbody rb;
    private MeshRenderer renderer;

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
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector2(0, 5), ForceMode.Impulse);
        }
    }
}
