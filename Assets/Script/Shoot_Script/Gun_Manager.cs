using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Manager : MonoBehaviour
{

    public string GunName;//총의 이름
    public int Gun_Dmg = 5;//총의 대미지
    public float range;//사정거리
    public float fireRate;//연사속도
    public float reloadTime;//재장전속도

    public int reloadBulletCount;//총알 재장전.
    public int currentBulletCount;//현재 총알개수
    public int MaxcurrentBullet;
    public int maxBulletCount;//최대 소유 가능 총알 개수
    public int carryBulletCount;//현재 소유한 총알 개수

    public GameObject Bullet_;

    //public ParticleSystem muzzleFlash;

    public AudioClip fire_Sound;

    private void Start()
    {

    }
    private void Update()
    {
        
    }

}
