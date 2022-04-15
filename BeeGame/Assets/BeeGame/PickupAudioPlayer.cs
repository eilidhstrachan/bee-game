using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAudioPlayer : MonoBehaviour
{

    private AudioSource audioSource;

    // Start is called before the first frame update
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void PlaySoundEffect()
    {
        audioSource.Play();
    }


    private void OnEnable()
    {
        FlowerPickup.OnFlowerPickup += PlaySoundEffect;
    }

    private void OnDisable()
    {
        FlowerPickup.OnFlowerPickup -= PlaySoundEffect;
    }

}
