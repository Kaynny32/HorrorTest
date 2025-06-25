using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Scripts")]
    [SerializeField]
    AnimationManager animationManager;
    [SerializeField]
    FirstPersonController firstPersonController;



    [SerializeField]
    GameObject _player;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void StartMoveCoffeHouse()
    {
        firstPersonController.SetBool_isActive(false);
        animationManager.StartCorutineShow();

        Loom.QueueOnMainThread(() => { 
            _player.transform.localPosition = new Vector3(347f, 18f, 470); 
        }, 0.75f);
        Loom.QueueOnMainThread(() =>
        {
            firstPersonController.SetBool_isActive(true);
        },3f);
    }
}
