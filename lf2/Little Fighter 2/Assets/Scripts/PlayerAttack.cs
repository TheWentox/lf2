using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float damage = 0.2f;

    private float timeBetweenAttacks = 1.0f;
    public float startTimeBetweenAttacks = 0.3f;

    public Transform attackPosition;
    public LayerMask whatIsEnemy;
    public float attackRange = 0.3f;

    public String attackName;
    public Animator animator;

    public KeyCode attackKey;

    public AudioClip hitSound;
    public AudioClip hitNothing;
    public AudioSource hitSource;

    void Update()
    {
        if (timeBetweenAttacks <= 0)
        {
            if (Input.GetKey(attackKey))
            {
                animator.Play(attackName);
            }

            timeBetweenAttacks = startTimeBetweenAttacks;
        }
        else
        {
            timeBetweenAttacks -= Time.deltaTime;
        }
    }

    void Attack()
    {
        Collider2D enemyToDamage = Physics2D.OverlapCircle(attackPosition.position, attackRange, whatIsEnemy);
        if (enemyToDamage == null)
        {
            hitSource.PlayOneShot(hitNothing);
            return;
        }
        hitSource.PlayOneShot(hitSound);
        enemyToDamage.GetComponent<EnemyDestroyer>().TakeDamage(damage);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPosition.position, attackRange);
    }
}
