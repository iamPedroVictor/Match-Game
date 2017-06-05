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
        touchObjects.Add(touchObject);
        print(touchObjects.Count);
        if(touchObjects.Count == 2)
        {
            SwapObjects(touchObjects[0], touchObjects[1]);
            touchObjects.Clear();
        }
        
    }

    private void SwapObjects(Transform transform1, Transform transform2)
    {
        Vector3 position1 = transform1.localPosition;
        Vector3 position2 = transform2.localPosition;
        transform1.Translate(position2);
        transform2.Translate(position1);
    }
}
