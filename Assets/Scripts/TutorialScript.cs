using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour
{

    public GameObject _TutorialHUD;
    public GameObject _GameHUD;

    // _TUTORIAL has all the states of the In Game Tutorial
    // the are call via swith in Update() with _tutorial var
    public enum _TUTORIAL
    {
        WELCOME, PLAYING, GAMEOVER
    }
    public _TUTORIAL _tutorial;

    // Here are the sprites and the container the tutorial needs
    // [0] is WELCOME, [1] and [2] is PLAYING, [3] is GAMEOVER
    public Sprite[] _tutoText;

    public Image _tutoBox;
    public Image _tutoInfo;

    // _loading is an animation in the button of the screen
    // it vanishes when GAMEOVER is active
    public SpriteRenderer _loading;

    // _tutoInt is used in PLAYING to display two objects
    // while _clickable is a timeout to prevent bugs
    private int _tutoInt = 1;
    private bool _clickable = true;
    //
    //
    void ChangeText(int valor)
    {
        _tutoInfo.sprite = _tutoText[valor];
    }

    // Update is called once per frame
    // here _tutorial is controlled via Switch()
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

        // this if() is used to prevent bugs
        // is a timeout when TUTORIAL.PLAYING is on

        if (_clickable == false)
        {
            Invoke("UpdTutoInt", 5f * Time.deltaTime);
        }
    }

    // START() is called on the beginning of the scene
    // here is displayed all the info for TUTORIAL.WELCOME
    void Start()
    {
        _TutorialHUD.SetActive(true);
        _GameHUD.SetActive(false);

        _tutorial = _TUTORIAL.WELCOME;
        _loading.gameObject.SetActive(true);
        ChangeText(0);
        _tutoInt = 0;
        Time.timeScale = 0;

        if (Input.GetMouseButton(0))
        {
            _tutorial = _TUTORIAL.PLAYING;
        }
    }

    // Here is the method called on _TUTORIAL.PLAYING
    //
    void AboutPlay()
    {
        // if the bool _clickable is true on click the info changes
        // after a click starte the timeout with a _clickable = flase

        if (_clickable)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _tutoInt += 1;
                _clickable = false;
            }
        }

        // if int < 2 the text change
        // if > 2 TUTORIAL.GAMEOVER starts

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

    // call with invoke to prevent bug
    // in the _TUTORIAL.PLAYING

    void UpdTutoInt()
    {
        _clickable = true;
    }

    // Here display the final message of the tutorial
    // and also desactivate the _loading

    void EndGame()
    {
        ChangeText(3);
        _loading.gameObject.SetActive(false);

        // in the end the tutorial panel is set off
        // so the player can start the game

        if (Input.GetMouseButtonDown(0))
        {
            Time.timeScale = 1;

            _TutorialHUD.SetActive(false);
            _GameHUD.SetActive(true);
            //gameObject.SetActive(false);
        }
    }
}
