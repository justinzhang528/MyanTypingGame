using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    static AudioManager audioManager;

    [Header("BackgroundMusic")]
    public AudioClip beachAudio;
    public AudioClip backgroudAudio;

    [Header("GameEndAudio")]
    public AudioClip clearAudio;
    public AudioClip gameOverAudio;

    [Header("EffectAudio")]
    public AudioClip attackAudio;
    public AudioClip wrongAudio;
    public AudioClip damageAudio;
    public AudioClip explosionAudio;

    AudioSource beachSource;
    AudioSource backgroudSource;
    AudioSource clearSource;
    AudioSource gameOverSource;
    AudioSource attackSource;
    AudioSource wrongSource;
    AudioSource damageSource;
    AudioSource explosionSource;

    void Awake()
    {
        if (audioManager == null)
        {
            audioManager = this;
        }
        beachSource = gameObject.AddComponent<AudioSource>();
        backgroudSource = gameObject.AddComponent<AudioSource>();
        clearSource = gameObject.AddComponent<AudioSource>();
        gameOverSource = gameObject.AddComponent<AudioSource>();
        attackSource = gameObject.AddComponent<AudioSource>();
        wrongSource = gameObject.AddComponent<AudioSource>();
        damageSource = gameObject.AddComponent<AudioSource>();
        explosionSource = gameObject.AddComponent<AudioSource>();

        beachSource.clip = beachAudio;
        backgroudSource.clip = backgroudAudio;
        clearSource.clip = clearAudio;
        gameOverSource.clip = gameOverAudio;
        attackSource.clip = attackAudio;
        wrongSource.clip = wrongAudio;
        damageSource.clip = damageAudio;
        explosionSource.clip = explosionAudio;
    }

    // Start is called before the first frame update
    void Start()
    {
        backgroudSource.loop = true;
        beachSource.loop = true;
        beachSource.volume = 0.5f;
        backgroudSource.Play();
        beachSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlayAttackAudio()
    {
        audioManager.attackSource.Play();
    }

    public static void PlayWrongAudio()
    {
        audioManager.wrongSource.Play();
    }

    public static void PlayDamageAudio()
    {
        audioManager.damageSource.Play();
    }

    public static void PlayExplosionAudio()
    {
        audioManager.explosionSource.Play();
    }

    public static void PlayClearAudio()
    {
        audioManager.clearSource.Play();
    }

    public static void PlayGameOverAudio()
    {
        audioManager.gameOverSource.Play();
    }

    public static void StopBackgroundAudio()
    {
        audioManager.backgroudSource.Stop();
    }
}
