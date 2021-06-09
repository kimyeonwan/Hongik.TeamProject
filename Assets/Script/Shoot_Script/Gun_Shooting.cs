using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms;

public class Gun_Shooting : MonoBehaviour
{
    public static Gun_Shooting instance;

    public float Speed = 5f;//총알의 속도
    private float currentFireRate;//연사 속도 받아올 매개변수

    public Transform GunTip;

    private GameObject Bullet_Object;
    public Queue<GameObject> Bullet_queue = new Queue<GameObject>();

    [SerializeField]
    private Gun_Manager currentGun;
    [SerializeField]
    private GameObject Player_Pos;

    public Slider ReloadSlider;
    float Reload_CooldownCurrent = 0.0f;

    //총의 각도 관련 변수
    private Vector2 lookDirection;
    public float lookAngle;

    private bool is_Reload = false;
    //private AudioSource audioSource;

    private void Start()
    {
        //audioSource = GetComponent<AudioSource>();
        instance = this;

        for (int i = 0; i < 20; i++)
        {
            Bullet_Object = Instantiate(currentGun.GetComponent<Gun_Manager>().Bullet_, GunTip.position, GunTip.rotation);
            Bullet_queue.Enqueue(Bullet_Object);
            Bullet_Object.SetActive(false);
        }
        
    }
    private void Update()
    {
        GunFireRateCalc();
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

        if (Input.GetMouseButtonDown(0)&&currentFireRate <= 0)
        {
            FireBullet();
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(ReloadCoroutine());
        }
        if(is_Reload==true)
        { 
            Reload_CooldownCurrent += Time.deltaTime;
            Reload_CooldownCurrent = Mathf.Clamp(Reload_CooldownCurrent, 0.0f, currentGun.reloadTime);
            ReloadSlider.value = Reload_CooldownCurrent/currentGun.reloadTime;
        }
        if (ReloadSlider.value >= 1.0f)
        {
            ReloadSlider.gameObject.SetActive(false);
            ReloadSlider.value = 0f;
            Reload_CooldownCurrent = 0f;
        }
        else
        {
            ReloadSlider.gameObject.SetActive(true);
        }
    }
    public void FireBullet()
    {
        if(!is_Reload)
        {
            if (currentGun.currentBulletCount > 0)
            {
                GameObject t_Object = GetQueue();
                t_Object.transform.position = gameObject.transform.position;
                Shoot();
            }
            else
            {
                StartCoroutine(ReloadCoroutine());
            }
        }

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
    private void GunFireRateCalc()
    {
        if (currentFireRate > 0)
        {
            currentFireRate -= Time.deltaTime;//60분의 1
        }
    }
    private void Shoot()
    {
        currentGun.currentBulletCount--;
        currentFireRate = currentGun.fireRate;//연사 속도 재계산
        //PlaySE(currentGun.fire_Sound);
        //currentGun.muzzleFlash.Play();

    }


    IEnumerator ReloadCoroutine()
    {

        is_Reload = true;
        if (currentGun.carryBulletCount > 0)
        {
            yield return new WaitForSeconds(currentGun.reloadTime);

            if (currentGun.carryBulletCount >= currentGun.reloadBulletCount)
            {
                int Reload_Num = currentGun.reloadBulletCount - currentGun.currentBulletCount;
                currentGun.currentBulletCount = currentGun.reloadBulletCount;
                currentGun.carryBulletCount -= Reload_Num;
            }
            else
            {
                if(currentGun.reloadBulletCount>=currentGun.currentBulletCount+currentGun.carryBulletCount)
                {
                    currentGun.currentBulletCount += currentGun.carryBulletCount;
                    currentGun.carryBulletCount = 0;
                }
                else
                {
                    int Reload_Num = currentGun.reloadBulletCount - currentGun.currentBulletCount;
                    currentGun.currentBulletCount += Reload_Num;
                    currentGun.carryBulletCount -= Reload_Num;
                }
            }
        }
        is_Reload = false;
    }

    public void CancelReload()
    {
        if(is_Reload)
        {
            StopAllCoroutines();
            is_Reload = false;
        }
    }
    public void GunChange(Gun_Manager Gun)
    {
        if(WeaponManager.currentWeapon!=null)
        {
            WeaponManager.currentWeapon.gameObject.SetActive(false);
        }
        currentGun = Gun;
        WeaponManager.currentWeapon = currentGun.GetComponent<Transform>();
        currentGun.gameObject.SetActive(true);
    }
    public Gun_Manager GetGun()
    {
        return currentGun;
    }
    /*private void PlaySE(AudioClip _clip)
   {
       audioSource.clip = _clip;
       audioSource.Play();
   }*/
}
