using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBirdSound : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField]
    List<AudioClip> audioClips = new List<AudioClip>();
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine("CountDownRand");
    }
    IEnumerator CountDownRand()
    {
        yield return new WaitForSeconds(Random.Range(30, 40));
        PlaySound();
    }
    void PlaySound()
    {
        audioSource.clip = audioClips[Random.Range(0, audioClips.Count - 1)];
        audioSource.Play();
    }
}
