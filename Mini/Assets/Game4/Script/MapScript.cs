using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScript : MonoBehaviour
{

    public GameObject Yuka_Black;
    public GameObject Yuka_White;
    public GameObject Goal;


    public GameObject Kabe_01;
    public GameObject Kabe_02;
    public GameObject Kabe_03;
    public GameObject Kabe_04;

    GameObject[,] Yuka;
    GameObject[] Obj;
    GameObject[] enemy;


    // Start is called before the first frame update
    void Start()
    {
        map1Create();
    }


    void map1Create()
    {
        //  床

        Yuka = new GameObject[20, 20];

        for(int x = 0; x<16;x++)
        {
            for(int y = 0; y < 16; y++)
            {
                if ((x + y) % 2 == 0)
                {
                    Yuka[x, y] = Instantiate(Yuka_Black);
                }
                else
                {
                    Yuka[x, y] = Instantiate(Yuka_White);
                }
                Yuka[x, y].transform.position = new Vector3(-8f + 1f * x, -1f, -8f + 1f * y);
            }

        }

        //  オブジェ
        //  壁

        int objCount = 0;

        Obj = new GameObject[100];

        for (int x = 0; x < 8; x++)
        {
            Obj[x] = Instantiate(Kabe_01);
            Obj[x].transform.position = new Vector3(-4f + 1f * x, 0f, -6f);
            objCount = objCount + 1;
        }

        for (int x = 0; x < 8; x++)
        {
            Obj[objCount+x] = Instantiate(Kabe_01);
            Obj[objCount + x].transform.position = new Vector3(-4f + 1f * x, 0f, 5f);
            objCount = objCount + 1;
        }


        for (int x = 0; x < 8; x++)
        {
            Obj[objCount + x] = Instantiate(Kabe_02);
            Obj[objCount + x].transform.position = new Vector3(-4f, 0f, -5f + 1f * x);
            objCount = objCount + 1;
        }

        for (int x = 0; x < 8; x++)
        {
            Obj[objCount + x] = Instantiate(Kabe_02);
            Obj[objCount + x].transform.position = new Vector3(4f, 0f, -5f + 1f * x);
            objCount = objCount + 1;
        }





    }

    /*
            for (int x = 0; x<block_x; x++)
        {
            for (int y = 0; y<block_y; y++)
            {
                Destroy(block[x, y]);
    block[x, y] = Instantiate(Block);
    block[x, y].transform.position = new Vector3((3f + (3f * y)), 0.4f, (-3.2f + (3.2f * x)));
                //block.GetComponent<Blockscript>.Ball = this.Ball;
            }
        }
        */

}
