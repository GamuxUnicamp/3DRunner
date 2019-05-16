using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{
    private bool ground;
    private Rigidbody rb;
    private bool moving;
    private float moveX = 10;
    private float moveY = 10;
    private bool left, right;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!moving)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) && !left)
            {
                rb.AddForce(-moveX, 0, 0, ForceMode.Impulse);
                if (right)
                    right = false;
                else
                    left = true;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) && !right)
            {
                rb.AddForce(moveX, 0, 0, ForceMode.Impulse);
                if (left)
                    left = false;
                else
                    right = true;
            }
            if (Input.GetKeyDown(KeyCode.UpArrow) && ground)
            {
                rb.AddForce(0, moveY, 0, ForceMode.Impulse);
                ground = false;
            }
            if (Input.GetKey(KeyCode.DownArrow) && ground)
                transform.localScale = new Vector3(1, .5f, 1);
            else
                transform.localScale = new Vector3(1, 1, 1);
        }
        if (rb.velocity.x != 0 || rb.velocity.y != 0)
            moving = true;
        else
            moving = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "chao")
            ground = true;
    }
}
