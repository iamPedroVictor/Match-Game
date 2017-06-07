using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public List<Transform> touchObjects;

    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }

    // Use this for initialization
    private void Awake()
    {
        touchObjects = new List<Transform>();
        touchObjects.Clear();
    }

    public void LoadObject(Transform touchObject)
    {
        if (touchObjects.Contains(touchObject)) return;

        touchObjects.Add(touchObject);
        if(touchObjects.Count == 2)
        {
            SwapObjects(touchObjects[0], touchObjects[1]);
            touchObjects.Clear();
        }
        
    }

    public float timeTakenDuringLerp = 1f;

    private IEnumerator AnimationTransform(Transform agent, Vector3 des, Vector3 midDistance){
        float time = 0;
        print("O destino eh>>>" + des);
        while(agent.position != des && time < timeTakenDuringLerp){
            time += Time.deltaTime;
            agent.RotateAround(midDistance, Vector3.forward, 180 / (timeTakenDuringLerp/Time.deltaTime));
            if (time >= 1)
            {
                time = 1;
                break;
            }
            yield return 0;
        }
        print("Esta em >>>" + agent.position);
        while (Vector3.Distance(agent.position, des) > Mathf.Epsilon)
        {
            print("Esta longe da posicao final");
            agent.position = des;
            yield return 0;
        }
        print("Esta em >>>" + agent.position);

    }

    private void SwapObjects(Transform transform1, Transform transform2)
    {

        Vector3 midDistance = Vector3.Lerp(transform1.position, transform2.position, .5f);

        StartCoroutine(AnimationTransform(transform1, transform2.position, midDistance));

        StartCoroutine(AnimationTransform(transform2, transform1.position, midDistance));
    }
}
