using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Gun_Shooting : MonoBehaviour
{
    public static Gun_Shooting instance;


    public Transform GunTip;

    public GameObject Bullet;
    public GameObject Bullet_Object;
    public Queue<GameObject> Bullet_queue = new Queue<GameObject>();
    public float Speed = 5f;
    public int dmg = 5;

    private Vector2 lookDirection;
    public float lookAngle;

    private void Start()
    {
        instance = this;

        for (int i = 0; i < 30; i++)
        {
            Bullet_Object = Instantiate(Bullet, GunTip.position, GunTip.rotation);
            Bullet_queue.Enqueue(Bullet_Object);
            Bullet_Object.SetActive(false);
        }
        
    }
    private void Update()
    {
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        if(lookAngle>90)
        {
            lookAngle = 90;
        }
        else if(lookAngle<-90)
        {
            lookAngle = -90;
        }
        transform.rotation = Quaternion.Euler(0f, 0f, lookAngle);

        if (Input.GetMouseButtonDown(0))
        {
            FireBullet();
        }
    }
    private void FireBullet()
    {
        GameObject t_Object = GetQueue();
        t_Object.transform.position = gameObject.transform.position;
    }
    public void InsertQueue(GameObject p_object)
    {
        Bullet_queue.Enqueue(p_object);
        p_object.SetActive(false);
    }
    public GameObject GetQueue()
    {
        GameObject t_Object = Bullet_queue.Dequeue();
        t_Object.SetActive(true);
        return t_Object;
    }

}
