using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorTransition : ScriptableObject {

    public Color ColorB;
    public Material mat;
    public float swapValue;
    private float time;
    public float duration;


    public IEnumerator SwapColor(Material _mat, Color B){
        time = 0;
        while(time < duration){
            time += Time.deltaTime;
            _mat.SetColor("ColorB", ColorB);
            _mat.SetFloat("_Cutoff", time);

            yield return 0;

        }
    }

}
