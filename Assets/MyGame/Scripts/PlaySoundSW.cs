using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundSW : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSourceCam;
    public void PlaySound()
    {
        audioSourceCam.Play();
        StartCoroutine("PlaySoundForThreeSeconds");
    }
    IEnumerator PlaySoundForThreeSeconds()
    {
        yield return new WaitForSeconds(3);
        audioSourceCam.Stop();
    }
}
