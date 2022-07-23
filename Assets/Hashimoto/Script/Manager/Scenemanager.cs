using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class Scenemanager : SingletonMonoBehaviour<Scenemanager>
{
    /// <summary>FadeImage</summary>
    public Image FadeImage => fadeImage;

    /// <summary>FadeImage</summary>
    [SerializeField]
    [Header("FadeImage")]
    Image fadeImage;

    public void FadeIn(float v,float seconds) => FadeImage.transform.DOMoveX(v,seconds);
    
    public void FadeOut(string scene , float v, float seconds) => FadeImage.transform.DOMoveX(v, seconds).OnComplete(() => SceneManager.LoadScene(scene));
}
