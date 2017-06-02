using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    //
    //
    public Image _MainImage;
    public Image _container;

    //
    //
    public Sprite _PlaySelected;
    public Sprite _InfoSelected;
    public Sprite _ExitSelected;

    //
    //
    public Sprite _TitleOn;
    public Sprite _aboutOn;

    //
    //
    public enum _Menu
    {
        PLAY, EXIT, ABOUT, STARTINGAME
    }
    public _Menu _menu;

    //
    //
    public Text _aboutText;
    public Text _ExitText;
    //
    //
    public bool _OneClick;
    public string _ProxCena;
    //
    //

    public Image _next;
    public Button[] _buttons;
    //
    //

    public void UpdateMenu(Image image, Sprite sprite)
    {
        image.sprite = sprite;
    }

    // Update is called once per frame
    // And its main function is controll the switch method
    void Update()
    {
        switch (_menu)
        {
            case _Menu.ABOUT:
                Info();
                break;
            case _Menu.EXIT:
                Exit();
                break;
            case _Menu.PLAY:
                Start();

                //
                //

                if (Input.GetMouseButtonDown(0))
                {
                    if (_OneClick == false)
                    {
                        _OneClick = true;
                    }
                    else
                    {
                        _menu = _Menu.STARTINGAME;
                    }
                }
                break;
            case _Menu.STARTINGAME:
                Starting();
                break;
        }
    }

    //
    //
    public void Start()
    {
        _next.gameObject.SetActive(false);
        _menu = _Menu.PLAY;
        TextControl(false, false);
        UpdateMenu(_container, _PlaySelected);
        UpdateMenu(_MainImage, _TitleOn);
    }

    //
    //
    public void Info()
    {
        _OneClick = false;
        _menu = _Menu.ABOUT;
        TextControl(true, false);
        UpdateMenu(_container, _InfoSelected);
        UpdateMenu(_MainImage, _aboutOn);
    }

    //
    //
    public void Exit()
    {
        _OneClick = false;
        _menu = _Menu.EXIT;
        TextControl(false, true);
        UpdateMenu(_container, _ExitSelected);
        UpdateMenu(_MainImage, _aboutOn);
    }

    public void TextControl(bool sobre, bool saida)
    {
        _aboutText.gameObject.SetActive(sobre);
        _ExitText.gameObject.SetActive(saida);
    }

    //
    //
    public void ExitGame()
    {
        Application.Quit();
    }

    //
    //
    public void StartGame()
    {
        SceneManager.LoadScene(_ProxCena);
    }

    //
    //
    public void Starting()
    {
        _next.gameObject.SetActive(true);
        Invoke("StartGame", 40f * Time.deltaTime);

        foreach (Button c in _buttons)
        {
            c.gameObject.SetActive(false);
        }
        _next.transform.localScale = new Vector3(_next.transform.localScale.x + 0.1f, _next.transform.localScale.y + 0.1f, _next.transform.localScale.z + 0.1f);

    }
}
