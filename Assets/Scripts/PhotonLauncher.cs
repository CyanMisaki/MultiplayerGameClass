using UnityEngine;
using Photon.Pun;

public class PhotonLauncher : MonoBehaviourPunCallbacks
{
    void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    void Start()
    {
        Connect();
    }

    public void Connect()
    {

        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.GameVersion = Application.version;
        }
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Complete OnConnectedToMaster");
    }
    /*public override void OnJoinedLobby()
    {
        Debug.Log($"Complete OnConnectedToLobby {PhotonNetwork.InLobby}");
        base.OnJoinLobby();
    }
    public override void OnJoinedRoom()
    {
        Debug.Log($"Complete OnConnectedToLobby {PhotonNetwork.InRoom}");
        base.OnJoinRoom();
    }*/
}
