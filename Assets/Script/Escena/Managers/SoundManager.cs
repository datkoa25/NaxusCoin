using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip Boss1y3, Boss2, Player, NormalEnemies, Robot;
    public static AudioClip Heart, Usb, PlayerDamage, Punch, PauseIn, PauseOut;
    public static AudioClip MenuSelect, BossAppearence, Shoot, Sword, Melee,PowerUp ;
    static AudioSource audioScr;

    private void Start()
    {
        Boss1y3 = Resources.Load<AudioClip>("Boss1y3");
        Boss2 = Resources.Load<AudioClip>("Boss2");
        Player = Resources.Load<AudioClip>("Player");
        NormalEnemies = Resources.Load<AudioClip>("NormalEnemies");
        Robot = Resources.Load<AudioClip>("Robot");
        Heart = Resources.Load<AudioClip>("Heart");
        Usb = Resources.Load<AudioClip>("Usb");
        PlayerDamage = Resources.Load<AudioClip>("Damage");
        Punch = Resources.Load<AudioClip>("Punch");
        PauseIn = Resources.Load<AudioClip>("PauseIn");
        PauseOut = Resources.Load<AudioClip>("PauseOut");
        MenuSelect = Resources.Load<AudioClip>("MenuSelect");
        BossAppearence = Resources.Load<AudioClip>("BossAppearence");
        Shoot = Resources.Load<AudioClip>("Shoot");
        Sword = Resources.Load<AudioClip>("Sword");
        Melee = Resources.Load<AudioClip>("Melee");
        PowerUp = Resources.Load<AudioClip>("PowerUp");
       

        audioScr = GetComponent<AudioSource>();
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Boss1y3":
                audioScr.PlayOneShot(Boss1y3);
                break;

            case "Boss2":
                audioScr.PlayOneShot(Boss2);
                break;

            case "Player":
                audioScr.PlayOneShot(Player);
                break;

            case "NormalEnemies":
                audioScr.PlayOneShot(NormalEnemies);
                break;

            case "Robot":
                audioScr.PlayOneShot(Robot);
                break;

            case "Heart":
                audioScr.PlayOneShot(Heart);
                break;

            case "Usb":
                audioScr.PlayOneShot(Usb);
                break;

            case "Damage":
                audioScr.PlayOneShot(PlayerDamage);
                break;

            case "Punch":
                audioScr.PlayOneShot(Punch);
                break;

            case "MenuSelect":
                audioScr.PlayOneShot(MenuSelect);
                break;

            case "PauseIn":
                audioScr.PlayOneShot(PauseIn);
                break;

            case "PauseOut":
                audioScr.PlayOneShot(PauseOut);
                break;

            case "BossAppearence":
                audioScr.PlayOneShot(BossAppearence);
                break;

            case "Shoot":
                audioScr.PlayOneShot(Shoot);
                break;

            case "Melee":
                audioScr.PlayOneShot(Melee);
                break;

            case "Sword":
                audioScr.PlayOneShot(Sword);
                break;

            case "PowerUp":
                audioScr.PlayOneShot(PowerUp);
                break;



        }
    }

    public void StopSound(string clip)
    {
        switch (clip)
        {
            case "Shoot":
                audioScr.Stop();
                break;
        }
    }

}
