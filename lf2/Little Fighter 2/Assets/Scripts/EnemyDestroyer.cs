using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyer : MonoBehaviour
{
    public float health = 1.0f;
    public float mana = 1.0f;
    public Transform healthBar;
    public Transform manaBar;
    public Animator animator;
    public string deathAnimation;

    void Start()
    {
        SetHealthBar(1.0f);
        SetManaBar(1.0f);
    }

    void Update()
    {
        if (mana < 1.0f)
        {
            mana += 0.005f;
            SetManaBar(manaBar.localScale.x + 0.005f);
        }
    }

    public void TakeDamage(float damage)
    {
        if (health - damage < 0)
        {
            health = 0;
        }
        else
        {
            health -= damage;
        }

        SetHealthBar(health);

        if (health <= 0)
        {
            animator.Play(deathAnimation);
            mana = 1.0f;
            health = 1.0f;
            SetManaBar(1.0f);
            SetHealthBar(1.0f);
        }
    }

    public void SetHealthBar(float size)
    {
        healthBar.localScale = new Vector3(size, 1f);
    }

    public void SetManaBar(float size)
    {
        manaBar.localScale = new Vector3(size, 1f);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ball")
        {
            col.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
}
