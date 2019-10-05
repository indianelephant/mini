using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class LobbyNetwork : MonoBehaviourPunCallbacks
{
   


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("サーバーに接続");

        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = "0";

        PhotonNetwork.ConnectUsingSettings();


    }


    

    void OnJoindLobby()
    {
        Debug.Log("ロビーに入った");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Masterになった");
    }


    public override void OnDisconnected(DisconnectCause cause)
    {
        
    }




}
