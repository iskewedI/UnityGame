using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    PlayerController Player;
    Animator Animator;

    /* El valor de SpeedPercent determina qu� animaci�n se va a mostrar. Est�n organizadas por un par�metro llamado "SpeedPercent",
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
        if (Input.GetButtonDown("Fire1"))
        {
            AttackProcess();

            // 1er argumento: función a invocar. 2do argumento: segundos a esperar antes de invocar la función
            Invoke("AttackProcess", 1);
        }

        if (Player.IsIdle)
        {
            SpeedPercent = 0;
        }
        else if (!Player.IsRunning)
        {
            SpeedPercent = 0.5f;
        }
        else
        {
            SpeedPercent = 1f;
        }

        // Se le asigna el valor de nuestra variable al par�metro del animador, y le a�adimos el resto para que se vea m�s fluido el movimiento.
        Animator.SetFloat("SpeedPercent", SpeedPercent, SmoothAnimation, Time.deltaTime);
    }

    private void AttackProcess()
    {
        if (!Player.IsAttacking)
        {
            Animator.SetTrigger("Attack");
            Player.IsAttacking = true;
        }
        else
        {
            Player.IsAttacking = false;
        }
    }
}
