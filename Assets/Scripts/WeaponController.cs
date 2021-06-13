using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private int WeaponDamage = 1;

    private PlayerController PlayerController;

    private bool IsCollisioning = false;
    
    private void Start()
    {
        PlayerController = GetComponentInParent<PlayerController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!IsCollisioning)
        {
            IsCollisioning = true;

            if (collision.gameObject.CompareTag("Enemy") && PlayerController.IsAttacking)
            {
                EnemyController controller = collision.gameObject.GetComponent<EnemyController>();
                controller.TakeDamage(WeaponDamage);
            }
        }
    }
    private void OnCollisionExit()
    {
        IsCollisioning = false;
    }
}
