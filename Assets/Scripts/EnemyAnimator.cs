using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    EnemyController Enemy;
    Animator Animator;

    [SerializeField] private float Life = 0f;
    [SerializeField] private float SmoothAnimation = 0.1f;

    void Start()
    {
        Enemy = GetComponent<EnemyController>();
        Animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Enemy.IsDead)
        {
            Life = 1f;
        }

        Animator.SetFloat("Life", Life, SmoothAnimation, Time.deltaTime);
    }
}
