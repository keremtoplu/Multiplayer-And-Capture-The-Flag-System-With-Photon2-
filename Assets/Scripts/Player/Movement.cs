using UnityEngine;
using Photon.Pun;
using TMPro;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private PlayerData playerData;

    private Team team;

    private int health;
    private float timer;
    private bool timerUsing = false;

    private TextMeshPro teamText;

    public PhotonView view;

    private Rigidbody rb;

    public int Health
    {
        get { return health; }
        set { health = value; }
    }
    public Team Team
    {
        get { return team; }
        set { team = value; }
    }
    public TextMeshPro TeamText
    {
        get { return teamText; }
        set { teamText = value; }
    }
    private void Start()
    {
        Debug.Log(PhotonNetwork.NickName);
        view = GetComponent<PhotonView>();

        teamText = transform.GetChild(0).GetComponent<TextMeshPro>();
        teamText.text = view.Owner.NickName;
        rb = GetComponent<Rigidbody>();
        if (!view.IsMine)
        {
            view.RPC("SetPlayerVarriables", RpcTarget.Others);
        }
    }

    private void Update()
    {

        if (view.IsMine)
        {

            // if (Input.GetKey("w"))
            // {
            //     transform.position += new Vector3(0, 0, speed * Time.deltaTime);
            // }
            // if (Input.GetKey("s"))
            // {
            //     transform.position -= new Vector3(0, 0, speed * Time.deltaTime);
            // }
            // if (Input.GetKey("a"))
            // {
            //     transform.Rotate(new Vector3(0, transform.rotation.y - .5f, 0), Space.Self);
            // }
            // if (Input.GetKey("d"))
            // {
            //     transform.Rotate(new Vector3(0, transform.rotation.y + .5f, 0), Space.Self);
            // }
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(horizontal * speed, 0, vertical * speed);
            rb.AddForce(movement);

        }
    }
    [PunRPC]
    public void SetPlayerVarriables()
    {
        Debug.Log(playerData.PlayerTeam);
        health = playerData.PlayerHealth;
        team = playerData.PlayerTeam;
    }


}

