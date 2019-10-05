using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Play1_Game2 : MonoBehaviour
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
             

     Playボタン押される
      ↓
      start.初期化
     
       0.チュートリアルテキスト
       ↓
       1.相手表示
     ↓
     * 2.自分選択する  
     * ↓              ↓
     * 3.判定       
       ↓
       4.
   *   
   *   4.勝敗確認
        
         
         */

    int phase;

    public Text infoText;
    public Text playerHPText;
    public Text enemyHPText;

    public Text judgeText;


    public GameObject enemy;

    public Sprite Man;
    public Sprite Win;
    public Sprite Lose;
    public Sprite gu;
    public Sprite choki;
    public Sprite pa;


    public GameObject guBtn;
    public GameObject chokiBtn;
    public GameObject paBtn;

    public GameObject retryBtn;


    int playerselectcount;

    int otherselect;
    int[] enemyselectArray;
    int enemyselectcount;

    int Flag;

    int countmaximum;
    int waitCount;

    float tmpTime;

    //  ステータス関連
    int playerHP;
    int enemyHP;


    void Start()
    {
        //初期化
        init();

    }

    void init()
    {
        tmpTime = Time.time;
        phase = 0;
        playerselectcount = 0;
        otherselect = 0;

        enemyselectArray = new int[10];
        for (int i = 0; i < 10; i++)
        {
            enemyselectArray[i] = Random.Range(1, 4); ;
        }


        Flag = 0;

        countmaximum = 3;
        waitCount = 3;
        playerHP = 3;
        enemyHP = 3;

        judgeText.text = "";
        infoText.text = "カウント\n" + waitCount;
        playerHPText.text = "HP :" + playerHP;
        enemyHPText.text = "HP :" + enemyHP;

        Image image_component = enemy.GetComponent<Image>();
        image_component.sprite = Man;

        guBtn.SetActive(false);
        chokiBtn.SetActive(false);
        paBtn.SetActive(false);
        retryBtn.SetActive(false);

 

    } 

    void Update()
    {
        if(playerHP <= 0 || enemyHP <= 0)
        {
            phase = -99;
        }



        if (phase == 0)
        {

        //    Debug.Log("経過時間(秒)" + Time.time);

            if(tmpTime + 1.0 <= Time.time)
            {
                infoText.text = "カウント\n" + waitCount;
                tmpTime = Time.time;
                waitCount = waitCount - 1;

            }


            if (waitCount == 0)
            {

                tmpTime = Time.time;
                phase = 1;
                enemyselectcount = 0;

            }

        }else if (phase == 1)
        {                

            if (tmpTime + 1.0 <= Time.time)
            {
                tmpTime = Time.time;


                if (enemyselectcount < countmaximum) {
                    selectedEnemyImage(enemyselectcount);
                    enemyselectcount = enemyselectcount + 1;
                }
                else
                {
                    Image image_component = enemy.GetComponent<Image>();
                    image_component.sprite = Man;

                    infoText.text = "選択してください！\n1つ目";

                    playerselectcount = 0;

                    phase = 2;
                }

            }


                


        }
        else if (phase == 2)
        {
            guBtn.SetActive(true);
            chokiBtn.SetActive(true);
            paBtn.SetActive(true);

        }
        else if (phase == 3)
        {
            /*
            if (myselect != 1) guBtn.SetActive(false);
            if (myselect != 2) chokiBtn.SetActive(false);
            if (myselect != 3) paBtn.SetActive(false);
            */

            //----  一人用

            //infoText.text = "選択しました!!\n相手の選択を\n待っています...";



            phase = 3;

            otherselect = Random.Range(1, 4);

            Debug.Log(otherselect);


            //----  一人用おわり
        }
        else if (phase == 4)
        {
            phase = 4;



        }
        else if (phase == -99)
        {
            playerHPText.text = "";
            enemyHPText.text = "";
            retryBtn.SetActive(true);
            guBtn.SetActive(false);
            chokiBtn.SetActive(false);
            paBtn.SetActive(false);

            if (enemyHP<=0)
            {
                infoText.text = "あなたの勝ちです！";

                Image image_component = enemy.GetComponent<Image>();
                image_component.sprite = Lose;
            }
            else if (playerHP <= 0)
            {
                infoText.text = "あなたの負けです！";
                Image image_component = enemy.GetComponent<Image>();
                image_component.sprite = Win;
            }


        }


    }


    public void guButton()
    {
        if (phase == 2)
        {
            selectedPlayerButton(1);
        }

    }
    public void chokiButton()
    {
        if (phase == 2)
        {
            selectedPlayerButton(2);
        }
    }
    public void paButton()
    {
        if (phase == 2)
        {
            selectedPlayerButton(3);
        }
    }


    public void retryButton()
    {
        init();
    }

    public void selectedEnemyImage(int index)
    {
        //enemyselect[index]
        infoText.text = "相手の選択を覚えて！\n" + (index + 1) + "つ目";

        Image image_component = enemy.GetComponent<Image>();
        if (enemyselectArray[index] == 1)
        {
            image_component.sprite = gu;
        }
        else if (enemyselectArray[index] == 2)
        {
            image_component.sprite = choki;
        }
        else if (enemyselectArray[index] == 3)
        {
            image_component.sprite = pa;
        }



    }

    public void selectedPlayerButton(int myselect)
    {
        //Flag 1.勝ち 2.負け 3.あいこ
        //1gu 2choki 3pa


        Debug.Log("AAA:"+ myselect);

        if (myselect == 1)
        {
            if (enemyselectArray[playerselectcount] == 1) Flag = 3;
            if (enemyselectArray[playerselectcount] == 2) Flag = 1;
            if (enemyselectArray[playerselectcount] == 3) Flag = 2;
        }
        else if (myselect == 2)
        {
            if (enemyselectArray[playerselectcount] == 1) Flag = 2;
            if (enemyselectArray[playerselectcount] == 2) Flag = 3;
            if (enemyselectArray[playerselectcount] == 3) Flag = 1;
        }
        else if (myselect == 3)
        {
            if (enemyselectArray[playerselectcount] == 1) Flag = 1;
            if (enemyselectArray[playerselectcount] == 2) Flag = 2;
            if (enemyselectArray[playerselectcount] == 3) Flag = 3;
        }

        playerselectcount = playerselectcount + 1;

        //  ダメージ計算
        if (Flag == 1)
        {
            judgeText.text = "あなたの勝ちです！\n相手にダメージ！";
            infoText.text = "選択してください！\n" + (playerselectcount + 1 )  + "つ目";
            enemyHP = enemyHP - 1;
        }
        else if (Flag == 2)
        {
            judgeText.text = "あなたの負けです！\n自分にダメージ！";
            infoText.text = "選択してください！\n" + (playerselectcount + 1 ) + "つ目";
            playerHP = playerHP - 1;
        }
        else if (Flag == 3)
        {
            judgeText.text = "あいこです！\n";
            infoText.text = "選択してください！\n" + (playerselectcount + 1 ) + "つ目";

        }

        updateHPText();



        if (playerselectcount >= countmaximum)
        {
            phase = 0;
            waitCount = 3;
        }


    }

    void updateHPText()
    {

        playerHPText.text = "HP :" + playerHP;
        enemyHPText.text = "HP :" + enemyHP;
    }


}
