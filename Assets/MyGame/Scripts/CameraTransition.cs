﻿using System.Collections;
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
    [SerializeField]
    GameObject playerHeigthGO;

    void Awake()
    {
        anim = GetComponent<Animation>();
        animClip = anim.GetClip("Cam");
        lenght = animClip.length;
        StartCoroutine("WaitForAnim");
    }
    void Update()
    {
        //Vector3 publicPos = playerHeigthGO.transform.TransformPoint(playerHeigthGO.transform.position);
        float posPlayerX = playerHeigthGO.transform.position.x;
        float posPlayerY = playerHeigthGO.transform.position.y;
        float posPlayerZ = playerHeigthGO.transform.position.z;
        //Resetting
        animClip.SetCurve("", typeof(Transform), "´m_LocalPosition", null);
        animClip.SetCurve("", typeof(Transform), "´m_LocalRotation", null);
        // X Pos 
        Keyframe[] keysx;
        keysx = new Keyframe[4];
        keysx[0] = new Keyframe(0f, 3f);
        keysx[1] = new Keyframe(0.39f, 3f);
        keysx[2] = new Keyframe(1.3f, -0.50241f);
        keysx[3] = new Keyframe(2.1f, posPlayerX);
        var curvex = new AnimationCurve(keysx);
        animClip.SetCurve("", typeof(Transform), "localPosition.x", curvex);
        // Y Pos 
        Keyframe[] keysy;
        keysy = new Keyframe[4];
        keysy[0] = new Keyframe(0f, 20.13f);
        keysy[1] = new Keyframe(0.39f, 20.13f);
        keysy[2] = new Keyframe(1.3f, 9.7572f);
        keysy[3] = new Keyframe(2.1f, posPlayerY);
        var curvey = new AnimationCurve(keysy);
        animClip.SetCurve("", typeof(Transform), "localPosition.y", curvey);
        // Z Pos
        Keyframe[] keysz;
        keysz = new Keyframe[4];
        keysz[0] = new Keyframe(0f, 3.28f);
        keysz[1] = new Keyframe(0.39f, 3.28f);
        keysz[2] = new Keyframe(1.3f, -7.4363f);
        keysz[3] = new Keyframe(2.1f, posPlayerZ);
        var curvez = new AnimationCurve(keysz);
        animClip.SetCurve("", typeof(Transform), "localPosition.z", curvez);
        // X Rot
        Keyframe[] keysxr;
        keysxr = new Keyframe[2];
        keysxr[0] = new Keyframe(0f, 90f);
        keysxr[1] = new Keyframe(2.1f, 0f);
        var curvexr = new AnimationCurve(keysxr);
        animClip.SetCurve("", typeof(Transform), "localRotation.x", curvexr);
        // Y Rot
        Keyframe[] keysyr;
        keysyr = new Keyframe[2];
        keysyr[0] = new Keyframe(0f, 0f);
        keysyr[1] = new Keyframe(2.1f, 0f);
        var curveyr = new AnimationCurve(keysyr);
        animClip.SetCurve("", typeof(Transform), "localRotation.y", curveyr);
        // Z Rot
        Keyframe[] keyszr;
        keyszr = new Keyframe[2];
        keyszr[0] = new Keyframe(0f, 0f);
        keyszr[1] = new Keyframe(2.1f, 0f);
        var curvezr = new AnimationCurve(keyszr);
        animClip.SetCurve("", typeof(Transform), "localRotation.z", curvezr);
    }

    IEnumerator WaitForAnim()
    {
        yield return new WaitForSeconds(lenght);
        playerGO.GetComponent<Player>().enabled = true;
        gameObject.SetActive(false);
    }
}