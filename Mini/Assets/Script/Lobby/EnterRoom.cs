using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class EnterRoom : MonoBehaviourPunCallbacks
{
    public void JoinRoom()
    {

        string RoomName = GameObject.Find("RoomNameInputField").GetComponent<InputField>().text;
        //GameObject.Find("InputPlayerName").GetComponent<lobbyInputPlayerName>().InputText();

        if (RoomName.Equals("")) return;



        if (PhotonNetwork.JoinRoom(RoomName))
        {
            Debug.Log("部屋を入室に成功");

        }
        else
        {
            Debug.Log("部屋を入室に失敗");
        }

    }



}
