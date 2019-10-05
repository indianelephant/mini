using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kabescript : MonoBehaviour
{
    public GameObject Ball;

    private void OnCollisionEnter(Collision collision)
    {
        
        Ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        Ball.transform.eulerAngles = new Vector3(0f, -135f, 0f);
        Ball.GetComponent<Rigidbody>().AddForce(Ball.transform.forward * 400, ForceMode.Impulse);
    
    }


}
