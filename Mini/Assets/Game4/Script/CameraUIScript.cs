using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraUIScript : MonoBehaviour
{
    public GameObject CameraUI;
    public GameObject MainCamera;

    // Start is called before the first frame update
    void Start()
    {
        //MainCamera.GetComponent<CameraScript>().fPos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void LeftButton()
    {
        MainCamera.GetComponent<CameraScript>().fPos = MainCamera.GetComponent<CameraScript>().fPos - 0.8f;
        if (MainCamera.GetComponent<CameraScript>().fPos <= -6.2f) MainCamera.GetComponent<CameraScript>().fPos = 0.0f;
    }

    public void RightButton()
    {
        MainCamera.GetComponent<CameraScript>().fPos = MainCamera.GetComponent<CameraScript>().fPos + 0.8f;
        if (MainCamera.GetComponent<CameraScript>().fPos >= 6.2f) MainCamera.GetComponent<CameraScript>().fPos = 0.0f;

    }

    public void ZoomButton()
    {
        if (MainCamera.GetComponent<CameraScript>().fZoom == 30f)
        {
            MainCamera.GetComponent<CameraScript>().fZoom = 15f;
        }
        else
        {
            MainCamera.GetComponent<CameraScript>().fZoom = 30f;
        }

    }


}
