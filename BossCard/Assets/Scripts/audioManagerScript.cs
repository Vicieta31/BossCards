using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManagerScript : MonoBehaviour
{
    [Header("------------- Audio Source -------------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXsource;

    [Header("------------- Audio Source -------------")]
    public AudioClip backgorund;
    public AudioClip[] swordGrunt;
    public AudioClip sword;
    public AudioClip hurtPlayer;
    public AudioClip heartAppear;
    public AudioClip heal;
    public AudioClip fire;
    public AudioClip collect;
    public AudioClip enemyHurt;
    public AudioClip enemyDie;

    private void Start()
    {
        musicSource.clip = backgorund;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXsource.PlayOneShot(clip);
    }

}
