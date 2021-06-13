using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField]
    private int WeaponDamage = 1;
    [SerializeField]
    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        // if(!collisioning){

        // }
        if (collision.gameObject.CompareTag("Enemy") && playerController.isAttacking)
        {
            EnemyController controller = collision.gameObject.GetComponent<EnemyController>();
            controller.TakeDamage(WeaponDamage);
        }
    }
    void OnCollisionExit()
    {
        // collisioning = false;
    }
}
