using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun_Manager : MonoBehaviour
{

    public string GunName;//���� �̸�
    public int Gun_Dmg = 5;//���� �����
    public float range;//�����Ÿ�
    public float fireRate;//����ӵ�
    public float reloadTime;//�������ӵ�

    public int reloadBulletCount;//�Ѿ� ������.
    public int currentBulletCount;//���� �Ѿ˰���
    public int MaxcurrentBullet;
    public int maxBulletCount;//�ִ� ���� ���� �Ѿ� ����
    public int carryBulletCount;//���� ������ �Ѿ� ����

    //public ParticleSystem muzzleFlash;
    public Texture GunSprite;
    public AudioClip fire_Sound;

    public GameObject Bullet_;

    private void Start()
    {

    }
    private void Update()
    {
        
    }

}
