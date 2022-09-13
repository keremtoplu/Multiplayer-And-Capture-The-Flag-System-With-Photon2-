using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CaptureArea : MonoBehaviour
{

    [SerializeField]
    private float captureTime;

    private GameObject flag;
    private float timer = 1;
    private int teamA = 0;
    private int teamB = 0;
    private int areaPlayers = 0;
    private float currentCaptureTime = 10;
    private bool captured = false;
    private Vector3 startFlagPos;
    private float captureSpeed;

    private void Start()
    {
        currentCaptureTime = captureTime;
        flag = transform.GetChild(1).gameObject;
        startFlagPos = flag.transform.position;
        captureSpeed = 1;

    }

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<Movement>();
        if (player)
        {
            switch (player.Team)
            {
                case Team.TeamA:
                    teamA++;
                    Debug.Log("teamA");
                    break;
                case Team.TeamB:
                    Debug.Log("TeamB");
                    teamB++;
                    break;
            }
            areaPlayers++;
            Debug.Log(areaPlayers);
        }
        Debug.Log("enter");
    }
    private void OnTriggerStay(Collider other)
    {
        var player = other.GetComponent<Movement>();

        if (player)
        {
            if (areaPlayers == 1)
            {
                Debug.Log("asd1");
                if (player.Health <= 50)
                {
                    // flag.transform.position = startFlagPos;
                    captureSpeed = 1f;
                    FlagMovement();
                    Debug.Log("healt low");
                }
                else
                {
                    captureSpeed = 1f;
                    FlagMovement();
                }
            }
            else if (areaPlayers >= 2)
            {
                if (teamA == 0 || teamB == 0)
                {
                    captureSpeed = 2;
                    FlagMovement();
                    Debug.Log("2 same team");
                    if (flag.transform.position.y >= 24)
                        Debug.Log(player.Team.ToString() + " Win");

                }
                else
                {
                    Debug.Log("2 different team");
                    flag.transform.position = startFlagPos;
                    captureSpeed = 1f;

                }


            }

        }
    }
    private void OnTriggerExit(Collider other)
    {
        var player = other.GetComponent<Movement>();
        if (player)
        {
            switch (player.Team)
            {
                case Team.TeamA:
                    teamA--;
                    Debug.Log("TeamA--");
                    break;
                case Team.TeamB:
                    Debug.Log("TeamB--");
                    teamB--;
                    break;
            }
            areaPlayers--;
            if (areaPlayers == 0 && !captured)
            {
                flag.transform.position = startFlagPos;
            }
            Debug.Log(areaPlayers);
        }
        Debug.Log("exit");
    }
    private void FlagMovement()
    {
        timer -= Time.deltaTime * captureSpeed;
        Debug.Log(timer);
        if (timer <= 0 && flag.transform.position.y < 24)
        {
            Debug.Log("asddd");
            flag.transform.position = Vector3.Lerp(flag.transform.position, flag.transform.position + new Vector3(0,
            (currentCaptureTime / 15), 0), 5f);
            timer = 1f;
        }
        else if (flag.transform.position.y >= 24)
        {
            captured = true;
        }
        Debug.Log(currentCaptureTime / 15);
    }

}

