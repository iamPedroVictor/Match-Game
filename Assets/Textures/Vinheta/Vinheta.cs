using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vinheta : MonoBehaviour
{
	/**
	pelo inspector dite o tempo necessario para carregar a proxima cena
	e também dite o nome da proxima cena
	 */
	 
    [SerializeField] private string _cena;
    [SerializeField] private float _tempo;
    // Use this for initialization
    void Start()
    {
        Invoke("ChangeSceneAfter", _tempo * Time.deltaTime);
    }

    // Update is called once per frame
    void ChangeSceneAfter()
    {
        SceneManager.LoadScene(_cena);

    }
}
