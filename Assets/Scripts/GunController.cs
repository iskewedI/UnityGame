using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField]
    private BulletController Bullet;

    public Quaternion direction;

    // Start is called before the first frame update
    void Start()
    {
        Bullet = GameObject.FindGameObjectsWithTag("Bullet")[0].GetComponent<BulletController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Esto iria en PLAYER MOVEMENT 
        if (Input.GetButtonDown("Fire1"))
        {
            Bullet.Shoot(direction);
        }
    }
   
    public void SetPosition(Quaternion rotation)
    {
        transform.localRotation = Quaternion.AngleAxis(rotation.y, Vector3.right);
        direction = rotation;
    }
}
