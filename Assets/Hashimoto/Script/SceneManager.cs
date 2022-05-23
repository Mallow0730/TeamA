using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class Scenemanager : MonoBehaviour
{
    public Image _fadeImage;

    
    public void FadeIn()
    {
        _fadeImage.transform.DOMoveX(960,1f);
    }
    public void FadeOut(string scene)
    {
        _fadeImage.transform.DOMoveX(-960, 1f)
            .OnComplete(() => SceneManager.LoadScene(scene));
    }
}
