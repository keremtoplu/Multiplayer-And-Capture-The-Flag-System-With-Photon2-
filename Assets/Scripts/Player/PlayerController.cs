using UnityEngine;
using Photon.Pun;

public class PlayerController : Singleton<PlayerController>
{
    [SerializeField]
    private Vector3 playerDesiredSpawnPos;

    [SerializeField]
    private GameObject playerPref;
    [SerializeField]
    private PlayerData playerData;
    private PhotonView photonView;
    private Movement playerVar;

    public Movement PlayerVar => playerVar;
    private void Start()
    {
        photonView = GetComponent<PhotonView>();
        playerData.PlayerTeam = Team.TeamA;
    }

    public void InıtPlayer()
    {
        var player = PhotonNetwork.Instantiate(playerPref.name, playerDesiredSpawnPos, Quaternion.identity);
        playerVar = player.GetComponent<Movement>();
    }
}

