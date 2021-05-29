using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField]
    private BulletController Bullet;

    [SerializeField]
    private Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        Bullet = GameObject.FindGameObjectsWithTag("Bullet")[0].GetComponent<BulletController>();
    }

    // Update is called once per frame
    public void PullTrigger()
    {
        Bullet.Shoot(camera.transform.forward);
    }
}
