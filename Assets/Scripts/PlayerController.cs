using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float WalkingSpeed = 2.4f;
    [SerializeField]
    private float RunningSpeed = 4f;
    [SerializeField]
    private float JumpForce = 5.6f;
    [SerializeField]
    private float MovementNormalizer = 0.025f;

    private Rigidbody Rb;
    private bool IsJumping = false;

    // Start es llamado una �nica vez, al inicio de la ejecuci�n
    private void Start()
    {
        Rb = GetComponent<Rigidbody>();
    }

    // Update es llamado una vez por frame, de forma continua
    void Update()
    {
        if (Input.GetButton("Jump") && !IsJumping)
        {
            Jump();
        }
    }

    // FixedUpdate se ejecuta sincr�nicamente con el physics engine, siendo independiente de la cantidad de fps que pueda renderizar el equipo
    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        /* TODO: intent� implementar que si se presiona el left shift, que el personaje corriera, me parece que tengo que especificar que tienen que presionarse
                 tanto el left shift como los botones de direccionamiento. Me parece que lo que ocurre es que espera a que solo se presione el left shift para
                 activarse, pero si el left shift se presiona s�lo, los valores de vertical y horizontal son 0, por lo que no habr�a nada de movimiento */

        //if (Input.GetKeyDown(KeyCode.LeftControl))
        //{
        //    MoveCharacter(Input.GetAxis("Horizontal") * Time.deltaTime, Input.GetAxis("Vertical") * Time.deltaTime, RunningSpeed);
        //}

        MoveCharacter(horizontal * Time.deltaTime, vertical * Time.deltaTime, WalkingSpeed);
    }

    private void MoveCharacter(float horizontal, float vertical, float speed)
    {
        /* TODO: Normalize hace que un vector tenga distancia de 1, manteniendo su mismo sentido de direcci�n
           (se supone facilita los c�lculos con vectores, investigar qu� tan cierto es eso en Unity) */

        // TODO: probar con valores independientes de la c�mara
        Vector3 forward = Camera.main.transform.forward;
        forward.y = 0;
        forward.Normalize();

        Vector3 right = Camera.main.transform.right;
        right.y = 0;
        right.Normalize();

        // Se mueve el personaje en la direcci�n y velocidad indicadas
        transform.position += horizontal * speed * right + vertical * speed * forward;

        /* Me fijo si horizontal o vertical son diferentes a 0, porque si me muevo constantemente en base a esos valores
           va a ocurrir que cuando el jugador deje de moverse, esos valores retornen a cero y mi personaje rote a su posici�n inicial
           en vez de mantenerse viendo al lado al que apunt� por �ltima vez la caminata indicada por el usuario */

        if (horizontal != 0 || vertical != 0)
        {
            // Obtengo el sentido de la rotaci�n de mi personaje en base al input de movimiento recibido por parte del usuario
            Vector3 lookRotation = new Vector3(horizontal, 0, vertical);

            // Cambio la rotaci�n en base al dato anterior, de la manera m�s "smooth" posible (tiene que haber una mejor forma de hacerlo)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookRotation.normalized), MovementNormalizer);
        }
    }

    private void Jump()
    {
        Rb.AddForce(new Vector3(0, JumpForce, 0), ForceMode.Impulse);
        IsJumping = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            IsJumping = false;
        }
    }
}
