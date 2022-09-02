using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour
{

    [SerializeField]
    private GameObject missilePrefab;

    [SerializeField]
    private int missileCount;

    [SerializeField]
    private Transform missilePoint;

    private Queue<GameObject> pool;


    private void Start()
    {
        pool = new Queue<GameObject>();
        for (int i = 0; i < missileCount; i++)
        {
            var missile = Instantiate(missilePrefab, missilePoint.position, Quaternion.identity);
            missile.SetActive(false);
            pool.Enqueue(missile);
        }

    }

    private void Update()
    {
        if (Input.GetKey("space"))
            Fire();
    }

    public void Fire()
    {
        var missile = pool.Dequeue();
        missile.transform.position = missilePoint.position;
        missile.SetActive(true);
        pool.Enqueue(missile);
    }
}