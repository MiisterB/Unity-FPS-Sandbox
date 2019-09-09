using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MunitionUI : MonoBehaviour
{
    public Text actualMunitions;

    // Update is called once per frame
    void Update()
    {
        actualMunitions.text = PlayerStats.currentAmmo + "/" + PlayerStats.maxAmmo;
    }
}
