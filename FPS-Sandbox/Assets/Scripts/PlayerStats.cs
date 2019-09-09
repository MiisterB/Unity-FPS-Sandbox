using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public WeaponSwitching weaponSwitcher;
    public static Gun gunEquipped;
    public static int currentAmmo;
    public static int maxAmmo;


    // Update is called once per frame
    void Update()
    {
        gunEquipped = weaponSwitcher.GetSelectedWeapon();
        currentAmmo = gunEquipped.currentAmmo;
        maxAmmo = gunEquipped.maxAmmo;
    }
}
