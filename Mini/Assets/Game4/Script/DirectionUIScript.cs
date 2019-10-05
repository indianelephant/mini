using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DirectionUIScript : MonoBehaviour
{

    public Text DirectionText;

    public GameObject PlayerBall;
    public GameObject PlayerTarget;


    public float Direction;


    // Start is called before the first frame update
    void Start()
    {
        Direction = 0;




        setPlayerTarget(Direction);

    }

    //  左ボタン
    public void LeftButton()
    {
        Debug.Log("left");
        Direction = Direction - 0.08f;
        if (Direction <= -6.2f) Direction = 0.0f;
        setPlayerTarget(Direction);
    }
    //  右ボタン
    public void RightButton()
    {
        Debug.Log("right");
        Direction = Direction + 0.08f;
        if (Direction >= 6.2f) Direction = 0.0f;
        setPlayerTarget(Direction);
    }

    //  ターゲット座標セット
    public void setPlayerTarget(float direction)
    {
        
        PlayerTarget.transform.position = new Vector3(PlayerBall.transform.position.x + 5 * Mathf.Sin(direction), 2f, PlayerBall.transform.position.z + 5 * Mathf.Cos(direction));

        Debug.Log("x" + Mathf.Sin(direction));
        Debug.Log("y" + Mathf.Cos(direction));

        //DirectionText.text = "Direction=" + Direction;

    }


}
