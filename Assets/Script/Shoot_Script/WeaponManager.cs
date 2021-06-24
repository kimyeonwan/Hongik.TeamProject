using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public static bool isChangeWeapon = false;

    [SerializeField]
    private float changeWeaponDelayTime;
    [SerializeField]
    private float changeWeaponEndDealyTime;

    //무기 종류들 관리.
    [SerializeField]
    private Gun_Manager[] guns;

    public static Transform currentWeapon;

    private Dictionary<string, Gun_Manager> GunDictionary = new Dictionary<string, Gun_Manager>();

    void Start()
    {
        for (int i = 0; i < guns.Length; i++)
        {
            GunDictionary.Add(guns[i].GunName, guns[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!isChangeWeapon)
        {
            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                StartCoroutine(ChangeWeaponCoroutine("AR"));
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                StartCoroutine(ChangeWeaponCoroutine("SubMachinGun"));
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                StartCoroutine(ChangeWeaponCoroutine("ShootGun"));
            }
        }

    }

    public IEnumerator ChangeWeaponCoroutine(string _name)
    {
        isChangeWeapon = true;
        yield return new WaitForSeconds(changeWeaponDelayTime);

        Gun_Shooting.instance.CancelReload();
        Gun_Shooting.instance.GunChange(GunDictionary[_name]);

        yield return new WaitForSeconds(changeWeaponEndDealyTime);

        isChangeWeapon = false;
    }
}
