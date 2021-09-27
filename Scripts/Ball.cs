using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] float speed = 400f;
    private Camera mainCam;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        mainCam = Camera.main;
    }

    private void FixedUpdate()
    {
        ChekIfFall();
        MoveMent();
        MobileMoveMent();//метод длдя телефона
    }

    

    void MoveMent()
    {
        float hor = Input.GetAxis("Horizontal") * (Time.deltaTime * 2f);
        float vert = Input.GetAxis("Vertical") * (Time.deltaTime * 2f);

        Vector3 vertCam = mainCam.transform.forward;
        Vector3 horizCam = mainCam.transform.right;

        vertCam.y = 0f;
        horizCam.y = 0f;

        vertCam.Normalize();
        horizCam.Normalize();

        Vector3 playerMove = (vertCam * vert + horizCam * hor) * speed;

        rb.AddForce(playerMove);
    }

    private void MobileMoveMent()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray currentRay = mainCam.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(currentRay,out hit))
            {
                Vector3 newPos = hit.point;
                Vector3 currentPos = transform.position;
                Vector3 direction = newPos-currentPos;
                direction.Normalize();
                direction.y = 0f;
                rb.AddForce(direction * speed * (Time.deltaTime * 2));
            }
        }
    }

    void ChekIfFall()
    {
        if (transform.position.y < -2f)
        {
           SceneManager.LoadScene("Gameplay");
        }
    }

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Finish")
        {
            Invoke(nameof(RestartLevel), 2f);
        }
    }

    void RestartLevel()
    {
        Debug.Log("выйграл");
        SceneManager.LoadScene("Gameplay");
    }
}
