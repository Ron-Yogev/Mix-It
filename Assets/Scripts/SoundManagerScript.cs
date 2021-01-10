using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManagerScript : MonoBehaviour
{
    [SerializeField] int level = 1;
    public static AudioClip paint, combine, erase, click, win, lose, crowd_panik, countdown, bk0, bk1, bk2, bk3, bk4, bk5, final_bk;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        paint = Resources.Load<AudioClip>("paint");
        combine = Resources.Load<AudioClip>("combine");
        erase = Resources.Load<AudioClip>("erase");
        click = Resources.Load<AudioClip>("click");
        win = Resources.Load<AudioClip>("win");
        lose = Resources.Load<AudioClip>("lose");
        crowd_panik = Resources.Load<AudioClip>("crowd_panik");
        countdown = Resources.Load<AudioClip>("countdown");
        bk0 = Resources.Load<AudioClip>("background0");
        bk1 = Resources.Load<AudioClip>("background1");
        bk2 = Resources.Load<AudioClip>("background2");
        bk3 = Resources.Load<AudioClip>("background3");
        bk4 = Resources.Load<AudioClip>("background4");
        bk5 = Resources.Load<AudioClip>("background5");
        final_bk = Resources.Load<AudioClip>("final_level_background");
       
        audioSrc = GetComponent<AudioSource>();

        PlayBackground();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayBackground()
    {
        switch (level)
        {
            case 0:
                PlaySound("background0");
                break;
            case 1:
                PlaySound("background1");
                break;
            case 2:
                PlaySound("background2");
                break;
            case 3:
                PlaySound("background3");
                break;
            case 4:
                PlaySound("background4");
                break;
            case 5:
                PlaySound("background5");
                break;
            case 6:
                PlaySound("final_level_background");
                break;
        }
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "paint":
                audioSrc.PlayOneShot(paint);
                break;
            case "combine":
                audioSrc.PlayOneShot(combine);
                break;
            case "erase":
                audioSrc.PlayOneShot(erase);
                break;
            case "click":
                audioSrc.PlayOneShot(click);
                break;
            case "win":
                audioSrc.PlayOneShot(win, 0.4f) ;
                break;
            case "lose":
                audioSrc.PlayOneShot(lose, 0.4f);
                break;
            case "crowd_panik":
                audioSrc.PlayOneShot(crowd_panik);
                break;
            case "countdown":
                audioSrc.PlayOneShot(countdown);
                break;
            case "background0":
                audioSrc.PlayOneShot(bk0, 0.2f);
                break;
            case "background1":
                     audioSrc.PlayOneShot(bk1, 0.2f);
                     break;
            case "background2":
                audioSrc.PlayOneShot(bk2, 0.2f);
                break;
            case "background3":
                audioSrc.PlayOneShot(bk3, 0.2f);
                break;
            case "background4":
                audioSrc.PlayOneShot(bk4, 0.2f);
                break;
            case "background5":
                audioSrc.PlayOneShot(bk5, 0.2f);
                break;
            case "final_level_background":
                audioSrc.PlayOneShot(final_bk, 0.2f);
                break;
        }
    }
}
