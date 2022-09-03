using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System;

public class MissileController : Singleton<MissileController>
{

    [SerializeField]
    private GameObject missilePrefab;

    [SerializeField]
    private int missileCount;

    [SerializeField]
    private Movement player;

    [SerializeField]
    private Queue<GameObject> pool;

    public void CreatePool()
    {
        pool = new Queue<GameObject>();
        for (int i = 0; i < missileCount; i++)
        {
            var missile = PhotonNetwork.Instantiate(missilePrefab.name, transform.position, Quaternion.identity);
            missile.SetActive(false);
            pool.Enqueue(missile);
        }
    }

    public void Fire()
    {
        var missile = pool.Dequeue();
        var missilePoint = GameObject.Find("MissilePoint");
        missile.transform.position = missilePoint.transform.position;
        missile.SetActive(true);
        pool.Enqueue(missile);
    }
}