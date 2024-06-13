using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] float minRandomPitch;
    [SerializeField] float maxRandomPitch;

    [SerializeField] AudioSource waterDropSound;
   
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

}
