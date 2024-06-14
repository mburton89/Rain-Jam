using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] float minRandomPitch;
    [SerializeField] float maxRandomPitch;

    [SerializeField] AudioSource waterDropSound;
    [SerializeField] AudioSource powerup13Sound;
    [SerializeField] AudioSource explosion15Sound;

    public AudioSource music;
    float musicVolume;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayWaterDropSound()
    {
        waterDropSound.pitch = Random.Range(minRandomPitch, maxRandomPitch);
        waterDropSound.Play();
    }

    public void PlayPowerup13Sound()
    {
        powerup13Sound.pitch = Random.Range(minRandomPitch, maxRandomPitch);
        powerup13Sound.Play();
    }
    public void PlayExplosion15Sound()
    {
        explosion15Sound.pitch = Random.Range(minRandomPitch, maxRandomPitch);
        explosion15Sound.Play();
    }
}
