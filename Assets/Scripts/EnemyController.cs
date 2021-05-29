using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private float life = 10f;

    private MeshRenderer renderer;

    private void Start()
    {
        renderer = GetComponent<MeshRenderer>();
    }
    public void LoseLife(float damage)
    {
        life -= damage;

        if (life < 1)
        {
            renderer.material.color = Color.red;
            Debug.Log("Morido");
        }
    }
}
