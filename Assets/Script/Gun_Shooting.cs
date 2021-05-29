using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Gun_Shooting : MonoBehaviour
{
    [SerializeField]
    private Transform GunTip;
    [SerializeField]
    private GameObject Bullet;

    private Vector2 lookDirection;
    private float lookAngle;

    private void Update()
    {
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, lookAngle);

        if (Input.GetMouseButtonDown(0))
        {
            FireBullet();
        }
    }
    private void FireBullet()
    {
        GameObject FireBullet = Instantiate(Bullet, GunTip.position, GunTip.rotation);

        FireBullet.GetComponent<Rigidbody2D>().velocity = GunTip.right * 10f;
    }
}
