using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
public class _MenuScript : MonoBehaviour
{

    Canvas canvas;
    public GameObject myobj;

    void Start()
    { 
        canvas = myobj.GetComponent<Canvas>();
        canvas.enabled = false;
    }

    public void MenuBackButton()
    {

        if (SceneManager.GetActiveScene().name.Contains("Play1_Game"))
        {
            SceneManager.LoadScene("Play1_Title");
        }
        else if (SceneManager.GetActiveScene().name.Equals("Play1_Title"))
        {
            SceneManager.LoadScene("_Title");
        }else if (SceneManager.GetActiveScene().name.Equals("Play2_Title"))
        {
            PhotonNetwork.LeaveRoom();
        }

        

    }

}
