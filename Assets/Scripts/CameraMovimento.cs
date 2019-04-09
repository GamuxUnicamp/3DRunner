using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovimento : MonoBehaviour
{
    public Transform jogador;

    // Update is called once per frame
    void Update()
    {
        transform.position = jogador.position + new Vector3(0,3,-5);//Camera se move apenas metade do jogador no eixo X
    }
}
