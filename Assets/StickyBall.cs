using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StickyBall : MonoBehaviour
{
    public float facingAngle = 0.0f;
    float x = 0;
    float z = 0;
    Vector2 unitV2;

    public GameObject CameraRefenrence;
    float DistanceToCamera = 5f;

    float SizeOF = 1;

    public GameObject category1;
    bool category1Unlock = false;

    public GameObject category2;
    bool category2Unlock = false;
    public GameObject category3;
    bool category3Unlock = false;


    public GameObject _SizeUI;


    public AudioClip _pickUpSound;
    private void Update()
    {
        x = Input.GetAxis("Horizontal")* Time.deltaTime * -100;
        z = Input.GetAxis("Vertical") * Time.deltaTime * 500;

        facingAngle += x;
        unitV2 = new Vector2(Mathf.Cos(facingAngle * Mathf.Deg2Rad), Mathf.Sin(facingAngle * Mathf.Deg2Rad));
    }

    private void FixedUpdate()
    {
        // Apply F
        transform.GetComponent<Rigidbody>().AddForce(new Vector3(unitV2.x,0,unitV2.y)*z * 3);
        CameraRefenrence.transform.position = new Vector3(-unitV2.x*DistanceToCamera,DistanceToCamera,-unitV2.y * DistanceToCamera)+ this.transform.position;

        UnlockPickUpCategory();
    }

    void UnlockPickUpCategory()
    {
        if (!category1Unlock)
        {
            if(SizeOF >= 1)
            {
               category1Unlock = true;

                for(int i = 0; i< category1.transform.childCount; i++)
                {
                    category1.transform.GetChild(i).GetComponent<Collider>().isTrigger = true;
                }
            }


        }


        if (!category2Unlock)
        {
            if (SizeOF >= 1.5)
            {
                category2Unlock = true;

                for (int i = 0; i < category2.transform.childCount; i++)
                {
                    category2.transform.GetChild(i).GetComponent<Collider>().isTrigger = true;
                }
            }


        }

        if (!category3Unlock)
        {
            if (SizeOF >= 2)
            {
                category3Unlock = true;

                for (int i = 0; i < category3.transform.childCount; i++)
                {
                    category3.transform.GetChild(i).GetComponent<Collider>().isTrigger = true;
                }
            }


        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Sticky"))
        {

            if (0 < SizeOF)
            {
                transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);

            SizeOF += 0.01f;

            DistanceToCamera += 0.08f;
            other.enabled = false;
            other.transform.SetParent(this.transform);

                _SizeUI.GetComponent<Text>().text = "Mass:" + Mathf.Round(SizeOF).ToString();
                this.GetComponent<AudioSource>().PlayOneShot(_pickUpSound);
            }
          
        }
    }

}
