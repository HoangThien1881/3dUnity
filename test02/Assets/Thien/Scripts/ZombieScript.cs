using UnityEngine.AI;
using UnityEngine;

public class ZombieScript : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform target; // m?c ti�u

    public float radius = 10f; // b�n k�nh t�m ki?m m?c ti�u
    public Vector3 originalePosition; // v? tr� ban ??u
    public float maxDistance = 50f; // kho?ng c�ch t?i n?i
    public Health health;

    public Animator animator; // khai b�o component

    public DamageZone damageZone;
    public GameObject hamburgerPrefab; // hamburger prefab
    public float dropChance = 0.25f; // t? l? r?i hamburger (25%)

    private bool hasDroppedBurger = false; // C? ki?m tra xem zombie ?� r?i hamburger ch?a

    // state machine
    public enum CharacterState
    {
        Normal,
        Attack,
        Die
    }
    public CharacterState currentState; // tr?ng th�i hi?n t?i

    void Start()
    {
        originalePosition = transform.position;
    }

    void Update()
    {
        if (health.currentHP <= 0)
        {
            ChangeState(CharacterState.Die);
        }
        if (target != null)
        {
            var lookPos = target.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 5);
        }
        if (currentState == CharacterState.Die)
        {
            return;
        }

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

        if (distance > radius || distanceToOriginal > maxDistance)
        {
            navMeshAgent.SetDestination(originalePosition);
            animator.SetFloat("Speed", navMeshAgent.velocity.magnitude);

            distance = Vector3.Distance(originalePosition, transform.position);
            if (distance < 1f)
            {
                animator.SetFloat("Speed", 0);
            }

            ChangeState(CharacterState.Normal);
        }
    }

    private void ChangeState(CharacterState newState)
    {
        switch (currentState)
        {
            case CharacterState.Normal:
                break;
            case CharacterState.Attack:
                break;
            case CharacterState.Die:
                break;
        }

        switch (newState)
        {
            case CharacterState.Normal:
                damageZone.EndAttack();
                break;
            case CharacterState.Attack:
                animator.SetTrigger("Attack");
                damageZone.BeginAttack();
                break;
            case CharacterState.Die:
                animator.SetTrigger("Die");
                DropHamburger(); // G?i h�m DropHamburger khi zombie ch?t
                Destroy(gameObject, 3f); // H?y zombie sau khi animation ch?t
                break;
        }
        currentState = newState;
    }

    // H�m ?? r?i hamburger khi zombie ch?t v?i t? l? 25%
    private void DropHamburger()
    {
        // Ki?m tra xem hamburger ?� r?i ch?a v� zombie ch?a ch?t
        if (!hasDroppedBurger && Random.value <= dropChance)
        {
            // T?o hamburger t?i v? tr� c?a zombie
            Instantiate(hamburgerPrefab, transform.position, Quaternion.identity);
            hasDroppedBurger = true; // ?�nh d?u l� hamburger ?� r?i
            Debug.Log("Zombie ?� r?i hamburger!");
        }
    }
}
