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
                transform.Rotate(new Vector3(0, transform.rotation.y + 1f, 0), Space.Self);
            }
            if (Input.GetKey("d"))
            {
                transform.rotation = Quaternion.Euler(0, transform.rotation.y + 2f, 0);
            }
            if (Input.GetKey("space"))
                MissileController.Instance.Fire();
        }

    }

}
