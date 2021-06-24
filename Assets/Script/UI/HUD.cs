using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public SpriteRenderer Gun_Sprite;
    [SerializeField]
    private Gun_Shooting Gun_Controller;
    private Gun_Manager currnet_gun;
    
    //총알 개수 반영
    [SerializeField]
    private Text[] text_Bullet;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CheckBullet();
    }
    private void CheckBullet()
    {
        currnet_gun = Gun_Shooting.instance.GetGun();
        text_Bullet[0].text = currnet_gun.currentBulletCount.ToString();
        text_Bullet[1].text = currnet_gun.carryBulletCount.ToString();
        text_Bullet[2].text = Gun_Shooting.instance.Grenade_num.ToString();

    }
}
