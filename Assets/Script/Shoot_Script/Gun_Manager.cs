using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Manager : MonoBehaviour
{

    public string GunName;//���� �̸�
    public int dmg = 5;//���� �����
    public float range;//�����Ÿ�
    public float fireRate;//����ӵ�
    public float reloadTime;//�������ӵ�

    public int reloadBulletCount;//�Ѿ� ������.
    public int currentBulletCount;//���� �Ѿ˰���
    public int MaxcurrentBullet;
    public int maxBulletCount;//�ִ� ���� ���� �Ѿ� ����
    public int carryBulletCount;//���� ������ �Ѿ� ����


    //public ParticleSystem muzzleFlash;

    public AudioClip fire_Sound;


}
