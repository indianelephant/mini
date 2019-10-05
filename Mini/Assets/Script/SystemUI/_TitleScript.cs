using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class _TitleScript : MonoBehaviour
{
 
    public void Play1Click()
    {
        SceneManager.LoadScene("Play1_Title");

    }

    public void Play2Click()
    {
        SceneManager.LoadScene("Play2_Lobby");

    }


}
