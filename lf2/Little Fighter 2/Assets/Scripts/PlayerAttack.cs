using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private int health = 100;
    private int mana = 100;
    public int damage = 10;

    private float timeBetweenAttacks = 1.0f;
    public float startTimeBetweenAttacks = 0.3f;

    public Transform attackPosition;
    public LayerMask whatIsEnemy;
    public float attackRange = 0.3f;

    public String attackName;
    public Animator animator;

    public KeyCode attackKey;
    public GameObject opponent;

    void Update()
    {
        if (timeBetweenAttacks <= 0)
        {
            if (Input.GetKey(attackKey))
            {
                animator.SetTrigger(attackName);
                Collider2D enemyToDamage = Physics2D.OverlapCircle(attackPosition.position, attackRange, whatIsEnemy);
                //enemyToDamage.GetComponent</**/>().TakeDamage(damage);
            }

            timeBetweenAttacks = startTimeBetweenAttacks;
        }
        else
        {
            timeBetweenAttacks -= Time.deltaTime;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPosition.position, attackRange);
    }
}
