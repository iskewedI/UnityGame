using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private int life = 3;

    public bool IsDead = false;

    // Update is called once per frame
    void Update()
    {
        if (life <= 0)
        {
            Debug.Log("Dead");
            IsDead = true;

            Destroy(this.gameObject, 100);
        }
    }

    public void TakeDamage(int damage)
    {
        life -= damage;
    }
}
