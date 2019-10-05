using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class _HeaderScript : MonoBehaviour
{

    public Text HeaderText;
    public GameObject menuobj;   
   
    void Start()
    {

        if (SceneManager.GetActiveScene().name.Equals("Play1_Title"))
        {
            HeaderText.text = "1PlayMode\nTitle";
        }
        else if(SceneManager.GetActiveScene().name.Equals("Play1_Game1"))
        {
            HeaderText.text = "01\nJyanken";
        }

    }



    public void HeaderButton()
    {
        Canvas canvas;
        canvas = menuobj.GetComponent<Canvas>();
        if (canvas.enabled)
        {
          
            canvas.enabled = false;
        }
        else
        {
            canvas.enabled = true;
        }


    }


}
