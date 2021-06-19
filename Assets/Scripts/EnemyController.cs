using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private int life = 3;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 0)
        {
            Debug.Log("Dead");
            Destroy(this.gameObject, 100);
        }
    }

    public void TakeDamage(int damage)
    {
        life -= damage;
    }
}
