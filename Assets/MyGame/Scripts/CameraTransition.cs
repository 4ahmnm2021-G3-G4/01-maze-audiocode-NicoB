using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class CameraTransition : MonoBehaviour
{
    Animation anim;
    AnimationClip animClip;
    float lenght;
    [SerializeField]
    GameObject playerGO;

    void Awake()
    {
        anim = GetComponent<Animation>();
        animClip = anim.GetClip("Cam");
        lenght = animClip.length;
        StartCoroutine("WaitForAnim");
    }

    IEnumerator WaitForAnim()
    {
        yield return new WaitForSeconds(lenght);
        playerGO.GetComponent<Player>().enabled = true;
        this.gameObject.SetActive(false);
    }
}
