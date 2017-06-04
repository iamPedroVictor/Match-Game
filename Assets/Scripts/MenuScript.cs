using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    // UnityEngine.UI is called here to be used in CANVAS containt
    // _MainImage displays the logo and the info boxes
    // _container has the bottom menu
    public Image _MainImage;
    public Image _container;

    // when one of the bottom button is click
    // changes the sprite of _container
    public Sprite _PlaySelected;
    public Sprite _InfoSelected;
    public Sprite _ExitSelected;

    // _TitleOn displays the logo in the _MainImage container
    // _aboutOn displays a box of the text case _InfoSelected or _ExitSelected
    public Sprite _TitleOn;
    public Sprite _aboutOn;

    // _Menu has all the states of Main Menu Scene
    // the are called via switch() in the Update() via _menu var
    public enum _Menu
    {
        PLAY, EXIT, ABOUT, STARTINGAME
    }
    public _Menu _menu;

    // Text called in ABOUT and EXIT cases
    // displaying and hiding info 
    public Text _aboutText;
    public Text _ExitText;

    // bool use to create double click in PLAY case
    // _ProxCena is use to define witch scene should come next
    // after the double click
    public bool _OneClick;
    public string _ProxCena;

    // effects and array to prevent bugs while loading next scene
    // both called in STARTINGAME case
    public Image _next;
    public Button[] _buttons;

    // call a cointaner and sprite that changes between cases
    // always called two times consecutive
    public void UpdateMenu(Image image, Sprite sprite)
    {
        image.sprite = sprite;
    }

    // Update is called once per frame
    // And its main function is controll the switch method
    void Update()
    {

        // switch that controls the game
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

                // Double Click
                // called when PLAY
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

    // all public voids are called via button inside of the canvas
    // START() is called on the beginning of the scene
    // here is displayed the sprites of PLAY case
    public void Start()
    {
        _next.gameObject.SetActive(false);
        _menu = _Menu.PLAY;
        TextControl(false, false);
        UpdateMenu(_container, _PlaySelected);
        UpdateMenu(_MainImage, _TitleOn);
    }

    // here is displayed the sprites of ABOUT case
    public void Info()
    {
        _OneClick = false;
        _menu = _Menu.ABOUT;
        TextControl(true, false);
        UpdateMenu(_container, _InfoSelected);
        UpdateMenu(_MainImage, _aboutOn);
    }

    // here is displayed the sprites of EXIT case
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

    // Closes the game when called
    public void ExitGame()
    {
        Application.Quit();
    }

    // called to start next scene
    public void StartGame()
    {
        SceneManager.LoadScene(_ProxCena);
    }


    // called to start an animation while loading next scene
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
