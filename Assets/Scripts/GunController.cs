using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField]
    private BulletController Bullet;

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
            Bullet.Shoot();
        }
    }
}