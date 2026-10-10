using UnityEngine;
using System.Collections;
public class PlayerMovement:MonoBehaviour
{

    public Rigidbody2D rb;
    public Animator anim;
    public int FacingDirection = 1;
    public Player_Combat player_Combat;

    private bool isKnockback;
    public bool isShooting;
    private void Update()
    {
        if (Input.GetButtonDown("Slash") && player_Combat ==true )
        {
            player_Combat.Attack();
        }
    }
    void FixedUpdate()
    {   if (isShooting == true)
        {
            rb.linearVelocity = Vector2.zero;
        }
        else if (isKnockback == false)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            if (horizontal > 0 && transform.localScale.x < 0 ||
                horizontal < 0 && transform.localScale.x > 0)
            {
                Flip();
            }
            anim.SetFloat("horizontal", Mathf.Abs(horizontal));
            anim.SetFloat("vertical", Mathf.Abs(vertical));
            rb.linearVelocity = new Vector2(horizontal, vertical) * StatsManager.Instance.speed;
        }
        
    }
    void Flip()
    {
        FacingDirection*=-1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
    public void Knockback(Transform enemy,float force,float stunTime)
    {
        isKnockback = true;
        Vector2 direction = (transform.position -enemy.position).normalized;
        rb.linearVelocity = direction*force;
        StartCoroutine(KnockbackCounter(stunTime) );
    }
    IEnumerator KnockbackCounter(float stunTime)
    {
        yield return new WaitForSeconds(stunTime);
        rb.linearVelocity = Vector2.zero;
        isKnockback=false;
    }
}
