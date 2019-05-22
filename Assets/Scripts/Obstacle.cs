using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    //CONSTANTES
    public const int VELOCITY = 50;

    void Start()
    {
        Rigidbody rig = GetComponent<Rigidbody>();
        //if (Spawner.instance.speed < MAX_VELOCITY)
        //    rig.velocity = Vector3.back * Spawner.instance.speed;
        //else
        //    rig.velocity = Vector3.back * MAX_VELOCITY;
        rig.velocity = Vector3.back * VELOCITY;
        StartCoroutine(AutoDestroy());
    }

    private IEnumerator AutoDestroy(){
        yield return new WaitForSeconds(10f);
        Spawner.instance.DestroyObstacle(this.gameObject);
    }
}
