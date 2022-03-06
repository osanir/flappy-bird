using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    [Header("Sound FX")]
    [SerializeField] AudioClip SFXWing;
    [SerializeField] AudioClip SFXDie;
    [SerializeField] AudioClip SFXHit;
    [SerializeField] AudioClip SFXPoint;

    public void PlayClip(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
    }

    public void PlaySFXWing()
    {
        PlayClip(SFXWing);
    }
    public void PlaySFXDie()
    {
        PlayClip(SFXDie);
    }
    public void PlaySFXHit()
    {
        PlayClip(SFXHit);
    }
    public void PlaySFXPoint()
    {
        PlayClip(SFXPoint);
    }
}
