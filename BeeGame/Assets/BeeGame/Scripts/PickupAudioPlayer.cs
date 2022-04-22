using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// uses the observer design pattern to play certain audio source sounds when certain events take place
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
        Debug.Log("PlaySoundEffect is being called");
    }


    private void OnEnable()
    {
        FlowerPickup.OnFlowerPickup += PlaySoundEffect;
        PieceMovement.OnPiecePlaced += PlaySoundEffect;
    }

    private void OnDisable()
    {
        FlowerPickup.OnFlowerPickup -= PlaySoundEffect;
        PieceMovement.OnPiecePlaced -= PlaySoundEffect;
    }

}
