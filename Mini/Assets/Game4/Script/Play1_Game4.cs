using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play1_Game4 : MonoBehaviour
{
    public GameObject ShotUI;
    public GameObject DirectionUI;


    public int PHASE;

    public GameObject PlayerBall;

    public bool bCamera;

    // Start is called before the first frame update
    void Start()
    {
        changePhaseUI(CONST.DIRECTION_PHASE);
        bCamera = false;
        ChangeCameraUI();

    }

    // Update is called once per frame
    void Update()
    {
    
    //  静止してら、次のフェイズへ
            if (PlayerBall.GetComponent<Rigidbody>().IsSleeping() && PHASE == CONST.BALLACTIVE_PHASE)
            {
                changePhaseUI(CONST.DIRECTION_PHASE);
            }
        
    }

    public void changePhaseUI(int next)
    {
        PHASE = next;

        DirectionUI.GetComponent<Canvas>().enabled = false;
        ShotUI.GetComponent<Canvas>().enabled = false;


        switch (next)
        {
            case CONST.DIRECTION_PHASE:
                DirectionUI.GetComponent<Canvas>().enabled = true;
                DirectionUI.GetComponent<DirectionUIScript>().Direction = 0;
                DirectionUI.GetComponent<DirectionUIScript>().setPlayerTarget(0f);
                break;

            case CONST.SHOT_PHASE:
                ShotUI.GetComponent<Canvas>().enabled = true;
                break;
        }
    }


    public void DirectionOkButton()
    {
        changePhaseUI(CONST.SHOT_PHASE);

    } 

    public void ShotPushButton()
    {
        changePhaseUI(CONST.BALLACTIVE_PHASE);
        //changePhaseUI(CONST.HITTING_PHASE);
    }        

    public void ChangeCameraUI()
    {

        if (bCamera)
        {

            bCamera = false;
        }
        else
        {
            bCamera = true;
        }

    }

    public void CameraButton()
    {
        ChangeCameraUI();
    }




}
