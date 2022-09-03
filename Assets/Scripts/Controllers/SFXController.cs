using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SFXController : Singleton<SFXController>
{
    [SerializeField]
    private AudioSource testSound;

    private void Awake()
    {
        testSound.Stop();
    }

    [PunRPC]
    public void InıtMusic()
    {
        AudioSource audioRPC = testSound;
        audioRPC.Play();
        //testSound.Play();
    }

}
