using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class Movement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private PhotonView view;

    private void Start()
    {
        view = GetComponent<PhotonView>();
    }

    private void Update()
    {
        if (view.IsMine)
        {
            if (Input.GetKey("w"))
            {
                transform.position += new Vector3(0, 0, speed * Time.deltaTime);
            }
            if (Input.GetKey("s"))
            {
                transform.position -= new Vector3(0, 0, speed * Time.deltaTime);
            }
            if (Input.GetKey("a"))
            {
                transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey("d"))
            {
                transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey("space"))
                MissileController.Instance.Fire();
        }

    }

}
