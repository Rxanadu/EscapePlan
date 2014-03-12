using UnityEngine;
using System.Collections;

public class WeaponSwitch : MonoBehaviour {

    public Texture2D crosshair;
    public float crosshairWidth, crosshairHeight;
    public GameObject mainWeapon, weapon1, weapon2;

    public int weaponEquipped = 1;

    void OnGUI() {
        if (crosshair != null)
            GUI.DrawTexture(new Rect(Screen.width/2, Screen.height/2, crosshairWidth, crosshairHeight), crosshair);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Q)) {
            SwitchWeapon();
        }

        if (Input.GetMouseButtonDown(0)) {
            FireWeapon();
        }
    }

    void SwitchWeapon() {
        switch (weaponEquipped) { 
            case 0:
                weaponEquipped = 1;
                print("Weapon Equipped: " + weaponEquipped);
                break;
            case 1:
                weaponEquipped = 0;
                print("Weapon Equipped: " + weaponEquipped);
                break;
        }
    }

    void FireWeapon() {
        switch (weaponEquipped) { 
            case 0:
                networkView.RPC("Shoot", RPCMode.All);
                break;
            case 1:
                networkView.RPC("ShootShotgun", RPCMode.All);
                break;
        }
    }

    [RPC]
    void Shoot() {
        RaycastHit hit;
        Transform cam = Camera.main.transform;

        if (Physics.Raycast(cam.position, cam.forward, out hit, 500)) {

            if (hit.transform.tag == "Player") {
                hit.transform.networkView.RPC("ApplyDamage", RPCMode.All, 5);
            }
        }
    }

    void ShootShotgun()
    {
        RaycastHit hit;
        Transform cam = Camera.main.transform;

        if (Physics.Raycast(cam.position, cam.forward, out hit, 500))
        {

            if (hit.transform.tag == "Player")
            {
                hit.transform.networkView.RPC("ApplyDamage", RPCMode.All, 20);
            }
        }
    }
}
