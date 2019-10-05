using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class _SelectScript : MonoBehaviour
{

    public int number;

    public Text SelectText;


    

    // Start is called before the first frame update
    void Start()
    {
        number = 1;

    }

    // Update is called once per frame
    void Update()
    {
        SelectText.text = "" + number;
        
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("Play1_Game"+number);
    }


    public void LeftButton()
    {
        if (number >= 2) number = number - 1;
    }

    public void RightButton()
    {
        number = number + 1;

    }



}
