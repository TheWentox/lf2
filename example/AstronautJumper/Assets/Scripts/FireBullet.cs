using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    public GameObject bulletProto;
    public Transform firePoint;
    public float speed = 10.0f;

    public float coolownTime = 1.0f;
    public float coolDown = 0;

    private Transform tr;

    public int bulletPoolSize = 20;
    private GameObject[] bulletPool;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();

        bulletPool = new GameObject[bulletPoolSize];
        for(int i=0; i<bulletPoolSize; i++)
        {
            GameObject newBullet = Instantiate(bulletProto);
            newBullet.SetActive(false);
            bulletPool[i] = newBullet;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if(coolDown <=0)
            {
                Fire();
                coolDown = coolownTime;
            }
        }

        if (coolDown > 0)
        {
            coolDown -= Time.deltaTime;
        }
    }

    void Fire()
    {
        GameObject newBullet = getInactiveBullet();
        if(newBullet == null)
        {
            Debug.Log("WARNING!!! Not enough Bullets!");
            return;
        }
        newBullet.GetComponent<Transform>().position = firePoint.position;

        newBullet.SetActive(true);

        Vector3 bulletSpeed;
        Quaternion bulletRotation;

        if(CharacterMovemenetController.facingRight)
        {
            bulletSpeed = new Vector3(speed, 0, 0);
            bulletRotation = Quaternion.Euler(new Vector3(0, 0, 90));
        } else
        {
            bulletSpeed = new Vector3(-1*speed, 0, 0);
            bulletRotation = Quaternion.Euler(new Vector3(0, 0, 270));
        }

        newBullet.GetComponent<Rigidbody2D>().velocity = bulletSpeed;
        newBullet.GetComponent<Transform>().rotation = bulletRotation;
    }

    GameObject getInactiveBullet()
    {
        for(int i=0;i<bulletPoolSize;i++)
        {
            if(bulletPool[i].activeSelf == false)
            {
                return bulletPool[i];
            }
        }

        return null;
    }
}
