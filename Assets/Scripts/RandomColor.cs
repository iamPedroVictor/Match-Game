using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour
{

    public Color[] _coresInGame;

	// Define the variables that will randomly choose the color of the material
	// called while creating the main objects of the game

    void Start()
    {
        int _valor = Random.Range(0, _coresInGame.Length);
        SetCor(_valor);
    }

    // finding the material
	// defining the color
    void SetCor(int _corAplicada)
    {
        GetComponent<Renderer>().material.SetColor("_Color", _coresInGame[_corAplicada]);
    }
}
