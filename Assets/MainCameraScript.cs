using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraScript : MonoBehaviour
{
    public GameObject _ball;
    Vector3 lookOffSet;


    void Start()
    {
        lookOffSet = new Vector3(0.0f, 1.5f, 0.0f);
    }

   
    void Update()
    {
        transform.LookAt(_ball.transform.position + lookOffSet);
    }
}
