using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private Text pText;
    public float points;

    void Start()
    {
        pText = FindObjectOfType<Text>().GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        pText.text = points.ToString("F0");
    }

    void FixedUpdate()
    {
        points += Time.deltaTime * 10;
    }
}
