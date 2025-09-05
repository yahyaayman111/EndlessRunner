using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Rendering.LookDev;
using UnityEngine;

public class CollisionDetect : MonoBehaviour
{
    GameObject Player;
    Animator Anim;
    AudioSource CollisionFX;
    GameObject FadeOut;
    //[SerializeField] CinemachineVirtualCamera cinemachineCam;
    //CinemachineBasicMultiChannelPerlin noise;
    //private float shakeTimer;

    private void Awake()
    {
        //noise = cinemachineCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        
        // Get references by GameObject name
        Player = GameObject.Find("Player");

        // If Animator is on the Player
        Anim = Player.GetComponentInChildren<Animator>();

        // If you have an object named "CollisionSound" that holds the AudioSource
        CollisionFX = GameObject.Find("Collision").GetComponent<AudioSource>();

        // If you have a UI Fade object named "FadeOut"
        //FadeOut = GameObject.Find("FadeOut");
    }
    private void OnTriggerEnter(Collider other)
    {
        CollisionFX.Play();
        Player.GetComponent<PlayerController>().enabled = false;
        Anim.Play("Stumble Backwards");
        //FadeOut.SetActive(true);
        //ShakeCamera(2f, 2f);
    }

    //public void ShakeCamera(float intensity, float time)
    //{
    //    //noise.enabled = true;
    //    noise.m_AmplitudeGain = intensity;
    //    shakeTimer = time;
    //}

    //void Update()
    //{
    //    if (shakeTimer > 0)
    //    {
    //        shakeTimer -= Time.deltaTime;
    //        if (shakeTimer <= 0)
    //        {
    //            noise.m_AmplitudeGain = 0f; // stop shaking
    //        }
    //    }
    //}
}
