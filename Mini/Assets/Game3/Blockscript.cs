using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blockscript : MonoBehaviour
{

    public GameObject block;
    bool flag;

    private void Start()
    {
        flag = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!flag) {
            flag = true;
            Destroy(block);
            Play1_Game3.addScore();
            Play1_Game3.addDesBlock();
        }

    }

}
