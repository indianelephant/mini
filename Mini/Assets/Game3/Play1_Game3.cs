using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GodTouches;

public class Play1_Game3 : MonoBehaviour
{

    public GameObject Ball;
    public GameObject Player;

    public GameObject Block;
    public GameObject kabe_bottom;

    public GameObject MissUI;
    public GameObject ClearUI;

    public Text score_Text;
    public static int score;
    public static bool missFlag;
    public static bool clerFlag;
    public static int des_block;

    int block_x;
    int block_y;

    GameObject[,] block;

    int halfScreenSizeW;


    Vector3 TouchstartPos;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        halfScreenSizeW = Screen.width / 2;
        initGame();


    }

    // Update is called once per frame
    void Update()
    {
        if (clerFlag == false && missFlag == false)
        {
            TouchMove();
        }


        score_Text.text = "SCORE : " + score;

        if (missFlag)
        {
            MissUI.GetComponent<Canvas>().enabled = true;
            Ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

        if (clerFlag)
        {
            ClearUI.GetComponent<Canvas>().enabled = true;

        }
        else
        {

            if (des_block == block_x * block_y)
            {
                des_block = 0;
                clerFlag = true;
            }

        }




    }

    //  Playerの操作
    void TouchMove()
    {



        var phase = GodTouch.GetPhase();
                   

        if (phase >= GodPhase.Moved)
        {
            TouchstartPos = GodTouch.GetPosition();
            if ((int)TouchstartPos.x <= halfScreenSizeW)
            {//左

                if (Player.transform.position.z <= 3.8)
                {
                    Player.transform.position += Player.transform.forward * 0.2f;
                    Debug.Log("hidari");
                }   
            }
            else
            {//右
                if (Player.transform.position.z >= -3.8)
                {
                    Player.transform.position -= Player.transform.forward * 0.2f;
                    Debug.Log("migi");
                }

                }

            //           Debug.Log(TouchstartPos);
        }
    }

    //  初速
    void ShotStart()
    {
        Ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        Ball.transform.eulerAngles = new Vector3(0f, 35f ,0f);
        Ball.GetComponent<Rigidbody>().AddForce(Ball.transform.forward * 600 , ForceMode.Impulse);


    }
        
    //  ブロックがボールにぶつかって消されたときスコア+
    public static void addScore()
    {
        score = score + 10;
    }

        //  ブロックがボールにぶつかって消されたとき消したブロック数計算
    public static void addDesBlock()
    {
        des_block = des_block + 1; 
    }


    //  ミス判定
    public static void missGame()
    {
        Debug.Log("みす！");
        missFlag = true;

    }

    //  ミス時リトライボタン
    public void retryButton()
    {
        score = 0;
        initGame();
    }

    //  クリア時リトライボタン
    public void nextButton()
    {
        initGame();
    }


    //  ゲーム初期化 / 開始時とリトライ時
    public void initGame()
    {


        missFlag = false;
        clerFlag = false;

        des_block = 0;

        block_x = 3;
        block_y = 2;

        block = new GameObject[block_x, block_y];

        MissUI.GetComponent<Canvas>().enabled = false;
        ClearUI.GetComponent<Canvas>().enabled = false;


        Ball.transform.position = new Vector3(-5.55f, 0.4f, 0f);
        Player.transform.position = new Vector3(-7f, 0.5f, 0f);

        ShotStart();



        score_Text.text = "SCORE : " + score;

        for (int x = 0; x < block_x; x++)
        {
            for (int y = 0; y < block_y; y++)
            {
                Destroy(block[x, y]);
                block[x,y] = Instantiate(Block);
                block[x,y].transform.position = new Vector3((3f + (3f * y)), 0.4f, (-3.2f + (3.2f * x)));
                //block.GetComponent<Blockscript>.Ball = this.Ball;
            }
        }
    }




}
