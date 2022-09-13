using UnityEngine;
using Photon.Pun;
using TMPro;

public class UIManager : Singleton<UIManager>
{
    [SerializeField]
    private TMPro.TMP_InputField createInputName;

    [SerializeField]
    private TMPro.TMP_InputField joinInputName;
    [SerializeField]
    private TMPro.TMP_InputField nickName;

    [SerializeField]
    private GameObject lobbyPanel;

    [SerializeField]
    private TMPro.TMP_Dropdown choosedTeam;
    [SerializeField]
    private PlayerData playerData;

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createInputName.text);
    }
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinInputName.text);
    }

    public void AllPanelClose()
    {
        lobbyPanel.SetActive(false);
    }

    public void NickNameChanged()
    {
        PhotonNetwork.NickName = nickName.text;
    }
    public void ChoosedTeamChanged()
    {

        if (choosedTeam.value == 0)
            playerData.PlayerTeam = Team.TeamA;
        else if (choosedTeam.value == 1)
            playerData.PlayerTeam = Team.TeamB;

    }
}
