using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject lobbyPanel;

    [SerializeField]
    private GameObject loadingPanel;

    void Start()
    {
        loadingPanel.SetActive(true);
        lobbyPanel.SetActive(false);
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        loadingPanel.SetActive(false);
        lobbyPanel.SetActive(true);
    }



}
