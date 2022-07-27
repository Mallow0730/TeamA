using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : SingletonMonoBehaviour<SoundManager>
{
    public AudioSource Audio => _audioSource;

    [SerializeField]
    AudioSource _audioSource;

    public void SE(AudioClip clip) => _audioSource.PlayOneShot(clip);
    public void SEStop() => _audioSource.Stop();
    public void BGM() => _audioSource.Play();
}
