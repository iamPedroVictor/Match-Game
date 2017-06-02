using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour
{

    // 
    //
    public enum _TUTORIAL
    {
        WELCOME, PLAYING, GAMEOVER
    }
    public _TUTORIAL _tutorial;
    //
    //
    public Sprite[] _tutoText;
    // 0 welcome 
    // 1 countdown
    // 2 combine
    // 3 score

    public Image _tutoBox;
    public Image _tutoInfo;
    public SpriteRenderer _loading;

    //
    //
    private int _tutoInt = 1;
    private bool _clickable = true;
    //
    //
    void ChangeText(int valor)
    {
        _tutoInfo.sprite = _tutoText[valor];
    }

    // Update is called once per frame
    //
    void Update()
    {
        switch (_tutorial)
        {
            case _TUTORIAL.WELCOME:
                Start();
                break;
            case _TUTORIAL.PLAYING:
                AboutPlay();
                break;
            case _TUTORIAL.GAMEOVER:
                EndGame();
                break;
        }


        //
        //

        if (_clickable == false)
        {
            Invoke("UpdTutoInt", 5f * Time.deltaTime);
        }
    }

    //
    //
    void Start()
    {
        _tutorial = _TUTORIAL.WELCOME;
        _loading.gameObject.SetActive(true);
        ChangeText(0);
        _tutoInt = 0;

        if (Input.GetMouseButton(0))
        {
            _tutorial = _TUTORIAL.PLAYING;
        }
    }

    //
    //
    void AboutPlay()
    {
        //
        //

        if (_clickable)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _tutoInt += 1;
                _clickable = false;
            }
        }

        //
        //

        if (_tutoInt == 1)
        {
            ChangeText(1);
        }

        if (_tutoInt == 2)
        {
            ChangeText(2);
        }

        if (_tutoInt > 2)
        {
            _tutorial = _TUTORIAL.GAMEOVER;
        }
    }

    //
    //

    void UpdTutoInt()
    {
        _clickable = true;
    }

    //
    //

    void EndGame()
    {
        ChangeText(3);
        _loading.gameObject.SetActive(false);

        //
        //

        if (Input.GetMouseButtonDown(0))
        {
            gameObject.SetActive(false);
        }
    }
}
