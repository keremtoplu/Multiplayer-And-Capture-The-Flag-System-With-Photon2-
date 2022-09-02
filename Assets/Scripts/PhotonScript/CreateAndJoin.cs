using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using TMPro;
public class CreateAndJoin : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private TMPro.TMP_InputField createInputName;
    [SerializeField]
    private TMPro.TMP_InputField joinInputName;
    [SerializeField]
    private GameObject lobbyPanel;
    [SerializeField]
    private GameObject playerPref;
    [SerializeField]
    private GameObject enviroment;

    [SerializeField]
    private Vector2 desiredSpawnPos;
    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createInputName.text);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinInputName.text);
    }

    public override void OnJoinedRoom()
    {
        enviroment.SetActive(true);
        lobbyPanel.SetActive(false);
        PhotonNetwork.Instantiate(playerPref.name, desiredSpawnPos, Quaternion.identity);
    }
}
