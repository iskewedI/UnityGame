using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float MovementNormalizer = 0.025f;
    [SerializeField] private float WalkingSpeed = 4f;
    [SerializeField] private float RunningSpeed = 4f;


    [SerializeField] private float JumpForce = 5.6f;

    private Rigidbody Rb;
    // Hice p�blicos estos campos porque importo el PlayerController en PlayerAnimation y utilizo estos campos ah�
    public bool IsIdle = true;
    public bool IsRunning => Input.GetKey(KeyCode.LeftShift); // GetKey Pregunta si el bot�n se mantiene presionado
    public bool IsJumping = false;
    public bool isAttacking = false;

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

        /* Me fijo si horizontal o vertical son diferentes a 0, porque si me muevo constantemente en base a esos valores
        va a ocurrir que cuando el jugador deje de moverse, esos valores retornen a cero y mi personaje rote a su posici�n inicial
        en vez de mantenerse viendo al lado al que apunt� por �ltima vez la caminata indicada por el usuario */
        if (horizontal != 0 || vertical != 0)
        {
            // Identificamos si el jugador est� corriendo, guardamos el hecho en una variable por si la llegaramos a necesitar en otros casos
            if (IsRunning)
            {
                MoveCharacter(horizontal * Time.deltaTime, vertical * Time.deltaTime, RunningSpeed);
                IsIdle = false;
            }
            else
            {
                MoveCharacter(horizontal * Time.deltaTime, vertical * Time.deltaTime, WalkingSpeed);
                IsIdle = false;
            }
        }
        else
        {
            IsIdle = true;
        }
    }

    private void MoveCharacter(float horizontal, float vertical, float speed)
    {
        Vector3 forward = Camera.main.transform.forward;
        forward.y = 0;
        forward.Normalize(); // Normalize convierte los vectores en vectores unitarios (reduce la magnitud del vector a 1, el dato del sentido es igual)

        Vector3 right = Camera.main.transform.right;
        right.y = 0;
        right.Normalize();

        // Se mueve el personaje en la direcci�n y velocidad indicadas
        transform.position += horizontal * speed * right + vertical * speed * forward;

        // Obtengo el sentido de la rotaci�n de mi personaje en base al input de movimiento recibido por parte del usuario
        Vector3 lookRotation = new Vector3(horizontal, 0, vertical);

        // Cambio la rotaci�n en base al dato anterior, de la manera m�s "smooth" posible (tiene que haber una mejor forma de hacerlo)
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookRotation.normalized), MovementNormalizer);
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
