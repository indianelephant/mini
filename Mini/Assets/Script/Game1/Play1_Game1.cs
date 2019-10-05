using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Play1_Game1 : MonoBehaviour
{


    /*
     * Playボタン押される
     * ↓
     * start.初期化
     * (マスター)    (クライアント)
     * 
     * 
     * 1.選択する : 選択する
     * ↓              ↓
     * 2.待機     ← 送信する
     * ↓              ↓
     * 3.判定       　待機
   *   送信する → 
   *   
   *   4.勝敗確認
             
         
         */

    int phase;

    public Text infoText;

    public GameObject enemy;

    public Sprite Man;
    public Sprite Win;
    public Sprite Lose;

    public GameObject guBtn;
    public GameObject chokiBtn;
    public GameObject paBtn;

    public GameObject retryBtn;

    int myselect;
    int otherselect;
    int Flag;

    void Start()
    {
        //初期化

        phase = 1;
        myselect = 0;
        otherselect = 0;
        Flag = 0;

        infoText.text = "じゃんけんします！\n下のボタンから選んでください！";



    }

    void Update()
    {
        if (phase == 1)
        {
            guBtn.SetActive(true);
            chokiBtn.SetActive(true);
            paBtn.SetActive(true);
            retryBtn.SetActive(false);
        }
        else if (phase == 2)
        {
           if (myselect != 1)guBtn.SetActive(false);       
           if (myselect != 2) chokiBtn.SetActive(false);
           if(myselect != 3) paBtn.SetActive(false);


            //----  一人用

            //infoText.text = "選択しました!!\n相手の選択を\n待っています...";
            
            

            phase = 3;

            otherselect = Random.Range(1, 4);

            Debug.Log(otherselect);


            //----  一人用おわり
        }
        else if (phase==3)
        {
            phase = 4;

            //Flag 1.勝ち 2.負け 3.あいこ 0.初めての時
            //1gu 2choki 3pa

            if (myselect == 1)
            {
                if (otherselect == 1) Flag = 3;
                if (otherselect == 2) Flag = 1;
                if (otherselect == 3) Flag = 2;
            }
            else if (myselect == 2)
            {
                if (otherselect == 1) Flag = 2;
                if (otherselect == 2) Flag = 3;
                if (otherselect == 3) Flag = 1;
            }
            else if(myselect == 3)
            {
                if (otherselect == 1) Flag = 1;
                if (otherselect == 2) Flag = 2;
                if (otherselect == 3) Flag = 3;
            }
            //  ここで相手に送る？

        }
        else if (phase == 4)
        {
            if (Flag == 1)
            {
                infoText.text = "あなたの勝ちです！";

                Image image_component = enemy.GetComponent<Image>();
                image_component.sprite = Lose;

                retryBtn.SetActive(true);//マスターだけ？

            }
            else if (Flag == 2)
            {
                infoText.text = "あなたの負けです！";
                Image image_component = enemy.GetComponent<Image>();
                image_component.sprite = Win;

                retryBtn.SetActive(true);//マスターだけ？

            }
            else if(Flag==3)
            {
                infoText.text = "あいこです！\n選択してください";
                phase = 1;

            }

        }


    }


    public void guButton()
    {
        if (phase == 1) {
            phase = 2;
            myselect = 1;
    }

}
    public void chokiButton()
    {
        if (phase == 1)
        {
            phase = 2;
            myselect = 2;
        }
    }
    public void paButton()
    {
        if (phase == 1)
        {
            phase = 2;
            myselect = 3;
        }
    }


    public void retryButton()
    {
        phase = 1;

        Image image_component = enemy.GetComponent<Image>();
        image_component.sprite = Man;

        infoText.text = "じゃんけんします！\n下のボタンから選んでください！";
    }




}
