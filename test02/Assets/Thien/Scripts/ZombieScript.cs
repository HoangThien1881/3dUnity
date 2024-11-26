using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI; // Thêm dòng này để sử dụng Slider

public class ZombieScript : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform target;
    public float radius = 10f;
    public Vector3 originalePosition;
    public float maxDistance = 50f;
    public Health health;
    public PlayerExp playerExp; // Thêm tham chiếu tới PlayerExp
    public Animator animator;
    public DamageZone damageZone;
    public GameObject hamburgerPrefab;
    public float dropChance = 100f;

    private bool hasDroppedBurger = false;
    public Slider healthBar; // Slider để hiển thị HP
    public Canvas healthBarCanvas;

    public enum CharacterState
    {
        Normal,
        Attack,
        Die
    }
    public CharacterState currentState;

    private bool isAttacking = false;

    void Start()
    {
        originalePosition = transform.position;
        if (healthBar != null)
        {
            healthBar.maxValue = health.maxHP;
            healthBar.value = health.currentHP;
        }
    }

    void Update()
    {
        if (healthBar != null)
        {
            healthBar.value = health.currentHP;
        }

        if (currentState == CharacterState.Die)
        {
            return;
        }

        if (health.currentHP <= 0)
        {
            ChangeState(CharacterState.Die);
            playerExp.AddExp(15f); // Cộng EXP cho người chơi khi zombie chết
            return;
        }

        if (isAttacking) return;

        var distanceToOriginal = Vector3.Distance(originalePosition, transform.position);
        var distance = Vector3.Distance(target.position, transform.position);

        if (distance <= radius && distanceToOriginal <= maxDistance)
        {
            navMeshAgent.SetDestination(target.position);
            animator.SetFloat("Speed", navMeshAgent.velocity.magnitude);

            if (distance < 2f)
            {
                ChangeState(CharacterState.Attack);
            }
        }
        else
        {
            navMeshAgent.SetDestination(originalePosition);
            animator.SetFloat("Speed", navMeshAgent.velocity.magnitude);

            if (distanceToOriginal < 1f)
            {
                animator.SetFloat("Speed", 0);
            }

            ChangeState(CharacterState.Normal);
        }
    }

    private void ChangeState(CharacterState newState)
    {
        if (currentState == newState) return;

        switch (newState)
        {
            case CharacterState.Normal:
                damageZone.EndAttack();
                isAttacking = false;
                navMeshAgent.isStopped = false;
                break;

            case CharacterState.Attack:
                isAttacking = true;
                navMeshAgent.isStopped = true; // Dừng di chuyển
                animator.SetTrigger("Attack");
                damageZone.BeginAttack();
                Invoke(nameof(ResumeMovement), 1.5f); // Tiếp tục di chuyển sau 1.5 giây
                break;

            case CharacterState.Die:
                navMeshAgent.isStopped = true;
                animator.SetTrigger("Die");
                DropHamburger();
                Destroy(gameObject, 3f); // Huỷ zombie sau khi chết
                break;
        }

        currentState = newState;
    }

    private void ResumeMovement()
    {
        isAttacking = false;
        navMeshAgent.isStopped = false;
        ChangeState(CharacterState.Normal);
    }

    private void DropHamburger()
    {
        if (!hasDroppedBurger)
        {
            Instantiate(hamburgerPrefab, transform.position, Quaternion.identity);
            hasDroppedBurger = true;
        }
    }
}
