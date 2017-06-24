using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour {

	public Color[] _coresInGame;
	void Start () {
		int _valor = Random.Range(0, _coresInGame.Length);
		SetCor(_valor);
	}
	
	// Update is called once per frame
	void SetCor (int _corAplicada) 
	{
		GetComponent<Renderer>().material.SetColor("_Color",_coresInGame[_corAplicada]);
	}
}
