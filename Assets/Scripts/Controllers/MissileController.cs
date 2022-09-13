using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

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

    private float timer;

    private bool timerUsing = false;
    private bool firstShot;

    private GameObject missilePoint;
    private GameObject directionPoint;

    private Vector3 direction;
    public Vector3 Direction => direction;

    private void Start()
    {
        firstShot = false;
    }
    public void CreatePool()
    {
        pool = new Queue<GameObject>();
        missilePoint = GameObject.Find("MissilePoint");
        directionPoint = GameObject.Find("Direction");

        for (int i = 0; i < missileCount; i++)
        {
            var missile = PhotonNetwork.Instantiate(missilePrefab.name, missilePoint.transform.position, Quaternion.identity);
            missile.SetActive(false);
            pool.Enqueue(missile);
        }
    }

    public void Fire()
    {
        var missile = pool.Dequeue();
        missile.transform.position = missilePoint.transform.position;
        direction = directionPoint.transform.position - missilePoint.transform.position;
        missile.SetActive(true);
        pool.Enqueue(missile);


    }
}
