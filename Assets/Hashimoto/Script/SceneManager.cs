using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class Scenemanager : MonoBehaviour
{
    /// <summary>FadeImage</summary>
    public Image FadeImage { get => fadeImage;}

    /// <summary>FadeImage</summary>
    [SerializeField]
    [Header("FadeImage")]
    Image fadeImage;


    public void FadeIn()
    {
        FadeImage.transform.DOMoveX(960,1f);
    }
    public void FadeOut(string scene)
    {
        FadeImage.transform.DOMoveX(-960, 1f)
            .OnComplete(() => SceneManager.LoadScene(scene));
    }
}
