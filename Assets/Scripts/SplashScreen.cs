using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{

    public Image m_Image;

    void Start()
    {
        m_Image.CrossFadeColor(new Color(0f, 0f, 0f, 0.02f), 0f, true, true);
        StartCoroutine(fadeInfadeOut());
    }

    private IEnumerator fadeInfadeOut()
    {
        Debug.Log("fadeInfadeOut()");
        m_Image.CrossFadeColor(Color.white, 1.5f, true, true);
        Debug.Log("antes wait 1");
        yield return new WaitForSeconds(2.5f);
        m_Image.CrossFadeColor(Color.clear, 1.0f, true, true);
        Debug.Log("antes wait 2");
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("MainMenu");
    }

}
