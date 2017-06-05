using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class CommandButton : MonoBehaviour
{

    Vector3 touchPosWorld;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchPosWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector2 touchPosWorld2D = new Vector2(touchPosWorld.x, touchPosWorld.y);
            ButtonCommand(touchPosWorld2D);
        }
    }

    public void ButtonCommand(Vector2 PosWorld2D) {
        RaycastHit2D hitInformation = Physics2D.Raycast(PosWorld2D, Camera.main.transform.forward);
        if (hitInformation.collider != null)
        {
            //We should have hit something with a 2D Physics collider!
            Transform touchedObject = hitInformation.transform;
            Debug.Log("Touched " + touchedObject.name + " Position: " + touchedObject.localPosition);
        }
    }

}
