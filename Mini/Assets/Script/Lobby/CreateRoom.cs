using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class CreateRoom : MonoBehaviourPunCallbacks
{
    public void MakeRoom()
    {
        string RoomName = GameObject.Find("RoomNameInputField").GetComponent<InputField>().text;
        //GameObject.Find("InputPlayerName").GetComponent<lobbyInputPlayerName>().InputText();

        if (RoomName.Equals("")) return;



        if (PhotonNetwork.CreateRoom(RoomName, new RoomOptions { MaxPlayers = 2 }))
        {
            Debug.Log("部屋を作成に成功");
            PhotonNetwork.LoadLevel("Play2_Title");

        }
        else
        {
            Debug.Log("部屋を作成に失敗");
        }
               


    }








}
