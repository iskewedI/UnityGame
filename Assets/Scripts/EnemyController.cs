using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private float life = 10f;
    
    public void LoseLife(float damage)
    {
        life -= damage;

        if (life == 0)
        {
            Debug.Log("Morido");
        }
    }
}