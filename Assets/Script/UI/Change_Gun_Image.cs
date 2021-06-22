using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Change_Gun_Image : MonoBehaviour
{
    private RawImage Gun_Image;
    void Start()
    {
        Gun_Image = gameObject.GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        if(WeaponManager.isChangeWeapon==true)
        {
            Gun_Image.texture = Gun_Shooting.instance.GetGun().GetComponent<Gun_Manager>().GunSprite;
        }
    }
}
