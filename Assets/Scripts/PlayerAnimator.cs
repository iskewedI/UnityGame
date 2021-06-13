using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    PlayerController Player;
    Animator Animator;

    /* El valor de SpeedPercent determina qué animación se va a mostrar. Están organizadas por un parámetro llamado "SpeedPercent",
    El cual puede tener un valor dentro del rango de 0 y 1f, desde Idle, pasando por Walk, hasta Run. */
    [SerializeField] private float SpeedPercent = 0; 
    [SerializeField] private float SmoothAnimation = 0.1f;

    void Start()
    {
        // Obtengo PlayerController para saber el estado en el que se encuentra el jugador
        Player = GetComponent<PlayerController>();
        Animator = GetComponent<Animator>();
    }

    void Update()
    {

        if (Player.IsIdle)
        {
            SpeedPercent = 0;
            Debug.Log("Player is standing still.");
        }
        else if (!Player.IsRunning)
        {
            SpeedPercent = 0.5f;
            Debug.Log("Player is walking.");
        }
        else
        {
            SpeedPercent = 1f;
            Debug.Log("Player is running.");
        }

        // Se le asigna el valor de nuestra variable al parámetro del animador, y le añadimos el resto para que se vea más fluido el movimiento.
        Animator.SetFloat("SpeedPercent", SpeedPercent, SmoothAnimation, Time.deltaTime); 
    }
}
