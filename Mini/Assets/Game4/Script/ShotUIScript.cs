using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotUIScript : MonoBehaviour
{


    public GameObject PlayerBall;
    public GameObject PlayerTarget;

    public GameObject PowerSlider;

    bool powerSlider_to;

    int power;


    // Start is called before the first frame update
    void Start()
    {
        power = 0;
        powerSlider_to = true;
    }


    void Update()
    {
        if (powerSlider_to)
        {
            PowerSlider.GetComponent<Slider>().value += 1.25f;

            if (PowerSlider.GetComponent<Slider>().value >= 100) powerSlider_to = false;

        }
        else
        {
            PowerSlider.GetComponent<Slider>().value -= 1.25f;
            if (PowerSlider.GetComponent<Slider>().value <= 1) powerSlider_to = true;
        }

    }


    //  プレイヤーがショットするボタン
    public void shotButton()
    {

        power = (int)PowerSlider.GetComponent<Slider>().value;

        if (power <= 0)
        {
            power = 1;
        }else if (power >= 95)
        {
            power = 100;
        }


         

        Debug.Log("power : " + power);

        Vector3 velocity = CalculateVelocity(PlayerBall.transform.position, PlayerTarget.transform.position, 60f, power);

        PlayerBall.GetComponent<Rigidbody>().AddForce(velocity * PlayerBall.GetComponent<Rigidbody>().mass, ForceMode.Impulse);



        /*
        PlayerBall.GetComponent<Rigidbody>().velocity = Vector3.zero;
        PlayerBall.transform.eulerAngles = new Vector3(45f, 35f, 0f);
        PlayerBall.GetComponent<Rigidbody>().AddForce(PlayerBall.transform.forward * 100 * power, ForceMode.Impulse);
        */

    }


    //  プレイヤーショットの速さの計算
    private Vector3 CalculateVelocity(Vector3 pointA, Vector3 pointB, float angle,int pow)
    {
        // 射出角をラジアンに変換
        float rad = angle * Mathf.PI / 180;

        // 水平方向の距離x
        float x = Vector2.Distance(new Vector2(pointA.x, pointA.z), new Vector2(pointB.x, pointB.z));

        // 垂直方向の距離y
        float y = pointA.y - pointB.y;

        // 斜方投射の公式を初速度について解く
        float speed = Mathf.Sqrt(-Physics.gravity.y * Mathf.Pow(x, 2) / (2 * Mathf.Pow(Mathf.Cos(rad), 2) * (x * Mathf.Tan(rad) + y)));

        if (float.IsNaN(speed))
        {
            // 条件を満たす初速を算出できなければVector3.zeroを返す
            return Vector3.zero;
        }
        else
        {
            return (new Vector3(pointB.x - pointA.x, x * Mathf.Tan(rad), pointB.z - pointA.z).normalized * speed);
        }
    }



}
