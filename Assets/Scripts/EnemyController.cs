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

        //  if(life == 0)
        /* Que pasaria si la vida se reduce a -1? El oponente nunca morir�a. 
        Esta l�gica supone que el dmg va a ser siempre "1", pero si se a�aden fuentes de da�o o se cambia a 3 o m�s, nunca "life" va a ser igual a 0 y por ende
        nunca va a morir (esto teniendo en cuenta que inicia con 10 de vida).
        */
        if (life == 0)
        {
            renderer.material.color = Color.red;
            Debug.Log("Morido");
        }
    }
}
