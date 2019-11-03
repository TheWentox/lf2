using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class EnemyGraphics : MonoBehaviour
{

    public AIPath aiPath;
    public Animator animator;

    public Transform attackPosition;

    public Vector3 originalLocaleScale;

    void Start()
    {
        originalLocaleScale = transform.localScale;
    }

    void Update()
    {
        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 1f);
        }
        else if(aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(-0.5f,0.5f,1f);
        }

        Collider2D enemyToDamage = Physics2D.OverlapCircle(attackPosition.position, 0.1f, LayerMask.GetMask("Player1"));
        if (enemyToDamage != null)
        {
            animator.Play("FirenAttack");
        }

        animator.SetFloat("Speed", Mathf.Abs(aiPath.desiredVelocity.x));
        animator.SetBool("Grounded", true);
    }
}
