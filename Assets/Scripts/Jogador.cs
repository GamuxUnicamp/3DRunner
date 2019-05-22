using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{
    private bool ground;
    private Rigidbody rb;
    private bool moving;
    private float moveX = 20;
    private float moveY = 40;
    private bool left, right;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate(){
        if (!moving) {
            if (Input.GetKeyDown(KeyCode.LeftArrow) && !left){
                if (right){
                    right = false;
                }else{
                    left = true;
                }
                StartCoroutine(movePlayer(-moveX, 0, 0, 0.25f));
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) && !right){
                if (left){
                    left = false;
                }else{
                    right = true;
                }
                StartCoroutine(movePlayer(moveX, 0, 0, 0.25f));
            }
            if (Input.GetKeyDown(KeyCode.UpArrow) && ground){
                rb.AddForce(0, moveY, 0, ForceMode.Impulse);
                ground = false;
            }
            if (Input.GetKey(KeyCode.DownArrow) && ground)//Mudar forma de abaixar no futuro
                transform.localScale = new Vector3(1, .5f, 1);
            else
                transform.localScale = new Vector3(1, 1, 1);
        }
        if (rb.velocity.x != 0){
            moving = true;
        }else{
            moving = false;
        }
    }

    private IEnumerator movePlayer(float x, float y, float z, float wait){
        rb.AddForce(x, y, z, ForceMode.VelocityChange);
        yield return new WaitForSeconds(wait);
        rb.velocity = Vector3.zero;
    }

    private void OnCollisionEnter(Collision collision){
        if (collision.gameObject.tag == "chao"){
            ground = true;
        }
    }
}
