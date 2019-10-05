using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    public GameObject goal;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("goal");
    }
}
