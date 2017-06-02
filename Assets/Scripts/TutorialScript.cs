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
    public Image _tutoBox;
	public Image _tutoInfo;
	public SpriteRenderer _loading;

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
		switch(_tutorial)
		{
			case _TUTORIAL.WELCOME:
			Start(); 
			break;
			case _TUTORIAL.PLAYING: 
			break;
			case _TUTORIAL.GAMEOVER: 
			break;
		}
    }

	//
	//
    void Start()
    {
		_tutorial = _TUTORIAL.WELCOME;
		_loading.gameObject.SetActive(true);
		ChangeText(0);
    }


}
