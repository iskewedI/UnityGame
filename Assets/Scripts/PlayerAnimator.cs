using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    PlayerController Player;
    Animator Animator;

    [SerializeField] private float SpeedPercent = 0; 

    [SerializeField] private float SmoothAnimation = 0.1f;

    void Start()
    {
        Player = GetComponent<PlayerController>();
        Animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Player.IsIdle)
        {
            SpeedPercent = 0;
            Debug.Log("Idle");
        }
        else if (Player.IsRunning)
        {
            SpeedPercent = 1f;
            Debug.Log("Run");
        }
        else
        {
            SpeedPercent = 0.5f;
            Debug.Log("Walk");
        }

        Animator.SetFloat("SpeedPercent", SpeedPercent, SmoothAnimation, Time.deltaTime);
    }
}
