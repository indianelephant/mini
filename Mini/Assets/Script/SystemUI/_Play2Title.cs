using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

using UnityEngine.SceneManagement;


public class _Play2Title : MonoBehaviourPunCallbacks
{
    public GameObject lbtn;
    public GameObject rbtn;
    public GameObject pbtn;

    public void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            lbtn.SetActive(true);
            rbtn.SetActive(true);
            pbtn.SetActive(true);

        }
        else
        {
            lbtn.SetActive(false);
            rbtn.SetActive(false);
            pbtn.SetActive(false);
        }

    }

    public override void OnLeftRoom()
    {
        SceneManager.LoadScene(0);
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnPlayerEnteredRoom(Player other)
    {

        if (PhotonNetwork.IsMasterClient)
        {

            Debug.Log("接続した");
           // LoadArena();
        }
    }


    public override void OnPlayerLeftRoom(Player other)
    {



        if (PhotonNetwork.IsMasterClient)
        {
            Debug.Log("切断した");


            // LoadArena();
        }
    }


}
