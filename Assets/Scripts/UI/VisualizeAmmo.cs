using TMPro;
using UnityEngine;

public class VisualizeAmmo : MonoBehaviour
{
    TextMeshProUGUI ammoText;
    [SerializeField] WeaponsSystem weaponSystem;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ammoText = GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        Shotgun();
    }

    void Shotgun()
    {

        ammoText.text = weaponSystem.ammo + " / " + weaponSystem.maxAmmo;

    }
}