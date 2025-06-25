using DG.Tweening;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationManager : MonoBehaviour
{
    [SerializeField]
    Image _blackFont;
    [SerializeField]
    CanvasGroup _imgAim;
    [SerializeField]
    Ease _ease;


    public void StartCorutineShow()
    {
        StartCoroutine(StartrAnimShowAndHideBlackImage());
    }

    IEnumerator StartrAnimShowAndHideBlackImage()
    {
        _imgAim.DOKill();
        _imgAim.DOFade(0,0.5f);
        _blackFont.gameObject.SetActive(true);
        _blackFont.DOKill();        
        _blackFont.DOFade(1, 0.75f).SetEase(_ease);
        yield return new WaitForSeconds(3f);
        _imgAim.DOKill();
        _imgAim.DOFade(1, 0.5f);
        _blackFont.DOKill();
        _blackFont.DOFade(0, 0.75f).SetEase(_ease);
        _blackFont.gameObject.SetActive(false);
    }
}
