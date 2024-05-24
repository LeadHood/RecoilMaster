using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsScript : MonoBehaviour
{
    [SerializeField] GameObject PlayButton;
    [SerializeField] GameObject ShotgunButton;
    [SerializeField] GameObject PistolButton;
    [SerializeField] GameObject Panel;

    [SerializeField] GameObject PistolObject;
    [SerializeField] GameObject ShotgunObject;

    [SerializeField] FireScript fireScript;

    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 0;
        fireScript.CurrentWeapon = Weapon.Shotgun;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        Time.timeScale = 1;

        Panel.SetActive(false);
    }

    public void Pistol()
    {
        fireScript.CurrentWeapon = Weapon.Pistol;
        PistolObject.SetActive(true);
        ShotgunObject.SetActive(false);
    }

    public void Shotgun()
    {
        fireScript.CurrentWeapon = Weapon.Shotgun;
        PistolObject.SetActive(false);
        ShotgunObject.SetActive(true);
    }
}
