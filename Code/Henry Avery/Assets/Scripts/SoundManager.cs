using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager snd;
    private AudioSource audioSrc;
    private AudioClip[] coinSounds;
    private int randomSounds;

    void Start()
    {
        snd = this;
        audioSrc = GetComponent<AudioSource>();
        coinSounds = Resources.LoadAll<AudioClip>("CoinSounds");
    }

    public void PlayCoinSounds()
    {
        randomSounds = Random.Range(0, 1);
        audioSrc.PlayOneShot(coinSounds[randomSounds]);
    }
}
