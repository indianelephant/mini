using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public GameObject PlayerBall;
    public Camera MainCamera;

    public float fPos;
    public float fZoom;

    // Start is called before the first frame update
    void Start()
    {
        fZoom = 30f;
    }


    // Update is called once per frame
    void Update()
    {
        //  真上
        //MainCamera.transform.position = new Vector3(PlayerBall.transform.position.x, PlayerBall.transform.position.y+15f, PlayerBall.transform.position.z);

        //  斜め
        MainCamera.transform.position = new Vector3(PlayerBall.transform.position.x+20f * Mathf.Sin(fPos), PlayerBall.transform.position.y+ fZoom, PlayerBall.transform.position.z + 20f * Mathf.Cos(fPos));


        //  プレイヤーボールを見る
        MainCamera.transform.LookAt(PlayerBall.transform.position);
        

    }
}
