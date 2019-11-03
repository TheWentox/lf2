using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firing : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;

    public KeyCode fireKey1;
    public KeyCode fireKey2;

    public float coolownTime = 1.0f;
    public float coolDown = 0;

    public float cost = 0.4f;

    public int ballPoolSize = 20;
    private GameObject[] ballPool;
    private EnemyDestroyer character;

    public Animator animator;
    public string FireAnimationName;

    public AudioClip shootSound;
    public AudioSource shootSoundSource;

    void Start()
    {
        character = GetComponent<EnemyDestroyer>();
        ballPool = new GameObject[ballPoolSize];
        for (int i = 0; i < ballPoolSize; i++)
        {
            GameObject newBall = Instantiate(bulletPrefab);
            newBall.SetActive(false);
            ballPool[i] = newBall;
        }
    }

    void Update()
    {
        if (Input.GetKey(fireKey1))
        {
            if (Input.GetKey(fireKey2))
            {
                if (coolDown <= 0 && character.mana >= cost)
                {
                    animator.Play(FireAnimationName);
                    coolDown = coolownTime;
                }
            }
        }

        if (coolDown > 0)
        {
            coolDown -= Time.deltaTime;
        }
    }

    void Fire()
    {
        GameObject newBall = GetInactiveBall();
        if (newBall == null)
        {
            return;
        }
        newBall.GetComponent<Transform>().position = firePoint.position;
        newBall.GetComponent<Transform>().rotation = firePoint.rotation;

        newBall.SetActive(true);

        character.mana -= cost;
        character.SetManaBar(character.mana);
    }

    private GameObject GetInactiveBall()
    {
        for (int i = 0; i < ballPoolSize; i++)
        {
            if (ballPool[i].activeSelf == false)
            {
                return ballPool[i];
            }
        }

        return null;
    }

    public void PlayShootSound()
    {
        shootSoundSource.PlayOneShot(shootSound);
    }
}
