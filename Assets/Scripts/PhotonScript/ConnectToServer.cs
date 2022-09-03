using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject lobbyPanel;
    [SerializeField]
    private GameObject enviroment;
    [SerializeField]
    private GameObject loadingPanel;

    void Start()
    {
        loadingPanel.SetActive(true);
        enviroment.SetActive(false);
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
