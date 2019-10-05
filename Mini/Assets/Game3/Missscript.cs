using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missscript : MonoBehaviour
{
    public GameObject kabe_bottom;

    private void OnCollisionEnter(Collision collision)
    {
        if (Play1_Game3.clerFlag == false)
        {
            Play1_Game3.missGame();
        }
    }

}
