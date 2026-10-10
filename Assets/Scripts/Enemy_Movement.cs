using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    public float speed;
    public int FacingDirection = -1;
    public float attackRange = 2;
    public float attackCooldown = 2;
    public float playerDetectRange = 5;
    public Transform detectionPoint;
    public LayerMask playerLayer;

    private float attackColldownTimer;
    private Animator anim;
    private EnemyState enemyState;
    private Rigidbody2D rb;
    private Transform player;
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
        ChangeState(EnemyState.Idle);
    }
    void Update()
    {
        if (enemyState != EnemyState.Knockback)
        {
            CheckForPlayer();
            if (attackColldownTimer > 0)
            {
                attackColldownTimer -= Time.deltaTime;
            }
            if (enemyState == EnemyState.Chasing)
            {
                Chase();
            }
            else if (enemyState == EnemyState.Attacking)
            {
                rb.linearVelocity = Vector2.zero;
            }
        }

        
        
    }
    void Chase()
    { 
        if (player.position.x > transform.position.x && FacingDirection == -1 ||
            player.position.x < transform.position.x && FacingDirection == 1)
        {
            Flip();
        }
        Vector2 direction = (player.position - transform.position).normalized;
        rb.linearVelocity = direction * speed;
    }
    void Flip()
    {
        FacingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
    private void CheckForPlayer()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(detectionPoint.position, playerDetectRange,playerLayer);
        if (hits.Length > 0)
        {
            player=hits[0].transform;
            if (Vector2.Distance(transform.position, player.position) <= attackRange && attackColldownTimer <= 0)
            {
                attackColldownTimer = attackCooldown;
                ChangeState(EnemyState.Attacking);
            }
            else if (Vector2.Distance(transform.position, player.position) > attackRange && enemyState !=EnemyState.Attacking)
            {
                ChangeState(EnemyState.Chasing);
            }
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
            ChangeState(EnemyState.Idle);
        }
    }

    public void ChangeState(EnemyState newState)
    {
        //�˳���ǰ״̬
        if (enemyState == EnemyState.Idle)
            anim.SetBool("isIdle", false);
        else if (enemyState == EnemyState.Chasing)
            anim.SetBool("isMoving", false);
        else if (enemyState == EnemyState.Attacking)
            anim.SetBool("isAttacking", false);

        //��ȡ����״̬
        enemyState = newState;


        //���µ�ǰ״̬
        if (enemyState == EnemyState.Idle)
            anim.SetBool("isIdle", true);
        else if (enemyState == EnemyState.Chasing)
            anim.SetBool("isMoving", true);
        else if (enemyState == EnemyState.Attacking)
            anim.SetBool("isAttacking", true);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color=Color.red;
        Gizmos.DrawWireSphere(detectionPoint.position, playerDetectRange);
    }
}
public enum EnemyState
{
    Idle,
    Chasing,
    Attacking,
    Knockback,
}