using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 0.05f;
    [SerializeField] private float MovementNormalizer = 0.025f;
    [SerializeField] private float WalkingSpeed = 4f;
    [SerializeField] private float RunningSpeed = 4f;
    [SerializeField] private float JumpForce = 5.6f;

    private Vector3 movementDirection;
    // private Rigidbody Rb;
    private CharacterController controller;
    private Camera mainCamera;

    // Hice publicos estos campos porque importo el PlayerController en PlayerAnimation y utilizo estos campos ahi
    public bool IsIdle = true;
    public bool IsRunning => Input.GetKey(KeyCode.LeftShift); // GetKey Pregunta si el boton se mantiene presionado
    public bool IsJumping = false;
    public bool IsAttacking = false;

    // Start es llamado una unica vez, al inicio de la ejecucion
    private void Start()
    {
        // Rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
        controller = GetComponent<CharacterController>();
    }

    // Update es llamado una vez por frame, de forma continua
    void Update()
    {
        if (Input.GetButton("Jump") && !IsJumping)
        {
            // Jump();
        }
    }

    // FixedUpdate se ejecuta sincronamente con el physics engine, siendo independiente de la cantidad de FPS que pueda renderizar el equipo
    private void FixedUpdate()
    {

        MoveCharacter();
        /* Me fijo si horizontal o vertical son diferentes a 0, porque si me muevo constantemente en base a esos valores
        va a ocurrir que cuando el jugador deje de moverse, esos valores retornen a cero y mi personaje rote a su posicion inicial
        en vez de mantenerse viendo al lado al que apunto por ultima vez la caminata indicada por el usuario */
        // if (horizontal != 0 || vertical != 0)
        // {
        // Identificamos si el jugador esta corriendo, guardamos el hecho en una variable por si la llegaramos a necesitar en otros casos
        // if (IsRunning)
        // {
        //     MoveCharacter(horizontal * Time.deltaTime, vertical * Time.deltaTime, RunningSpeed);
        // }
        // else
        // {
        //     MoveCharacter(horizontal * Time.deltaTime, vertical * Time.deltaTime, WalkingSpeed);
        // }

        // IsIdle = false;
        // }
        // else
        // {
        //     IsIdle = true;
        // }
    }

    private void MoveCharacter()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (new Vector3(horizontal, vertical).sqrMagnitude <= 0) return;

        float speed = IsRunning ? RunningSpeed : WalkingSpeed;

        // Normalize convierte los vectores en vectores unitarios (reduce la magnitud del vector a 1, el dato del sentido es igual)
        Vector3 forwardLook = mainCamera.transform.forward;
        forwardLook.y = 0f;
        forwardLook.Normalize();

        Vector3 rightLook = mainCamera.transform.right;
        rightLook.y = 0f;
        rightLook.Normalize();

        movementDirection = forwardLook * vertical + rightLook * horizontal;

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movementDirection), rotationSpeed);

        controller.Move(movementDirection * Time.deltaTime * speed);
        // Se mueve el personaje en la direccion y velocidad indicadas
        // transform.position += horizontal * speed * right + vertical * speed * forward;

        // Obtengo el sentido de la rotacion de mi personaje en base al input de movimiento recibido por parte del usuario
        // Vector3 lookRotation = new Vector3(horizontal, 0, vertical);

        // Cambio la rotacion en base al dato anterior, de la manera mas "smooth" posible (tiene que haber una mejor forma de hacerlo)
        // transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookRotation.normalized), MovementNormalizer);
    }

    // private void Jump()
    // {
    //     Rb.AddForce(new Vector3(0, JumpForce, 0), ForceMode.Impulse);
    //     IsJumping = true;
    // }

    // private void OnCollisionEnter(Collision collision)
    // {
    //     if (collision.gameObject.CompareTag("Floor"))
    //     {
    //         IsJumping = false;
    //     }
    // }
}
