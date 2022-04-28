using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * PickupAudioPlayer uses the observer design pattern to play certain audio source sounds when certain events take place,
 * e.g the flower pickup sound effect, or the sound effect that plays when a puzzle piece is placed.
 * Using the observer pattern removes the need for having a large number of AudioSources for each flower or puzzle piece object.
 */
public class PickupAudioPlayer : MonoBehaviour
{
    // audioSource is private as it doesn't need to be accessed outside of this class or in the inspector
    private AudioSource audioSource;

    // Start is called before the first frame update
    private void Awake()
    {
        // sets audioSource to the AudioSource that this script is attached to
        audioSource = GetComponent<AudioSource>();
    }

    // plays the sound that the AudioSource has been set to play
    private void PlaySoundEffect()
    {
        audioSource.Play();
        Debug.Log("PlaySoundEffect is being called");
    }

    // when the subject sends the observers a notification that an action has been invoked, enables the observer
    private void OnEnable()
    {
        // when a flower has been picked up or a piece has been placed, calls PlaySoundEffect
        FlowerPickup.OnFlowerPickup += PlaySoundEffect; 
        PieceMovement.OnPiecePlaced += PlaySoundEffect;
    }

    // removes the observers when they are no longer needed
    private void OnDisable()
    {
        FlowerPickup.OnFlowerPickup -= PlaySoundEffect;
        PieceMovement.OnPiecePlaced -= PlaySoundEffect;
    }

}
