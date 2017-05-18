using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {

    public int xSize, ySize;
    private List<Vector2> gridPositions = new List<Vector2>();
    public CircularElement circleRef;
    public List<CircularElement> gridElements;

    public void CleanGrid()
    {
        gridPositions.Clear();
    }

    public void GenerateGrid(int xSize, int ySize)
    {
        
        for(int y = 0; y < ySize; y++)
        {
            for(int x = 0; x < xSize; x++)
            {
                gridPositions.Add(new Vector2(x, y));
            }
        }
    }

    public IEnumerator GenerateElements()
    {
        gridElements = new List<CircularElement>();
        for(int i = 0; i < gridPositions.Count; i++)
        {
            
            CircularElement element = Instantiate(circleRef, gridPositions[i], Quaternion.Euler(0,180,0)) as CircularElement;
            gridElements.Add(element);
            element.transform.SetParent(this.transform);
            yield return new WaitForSeconds(0.5f);
        }
    }

	// Use this for initialization
	void Start () {
        CleanGrid();
        GenerateGrid(xSize,ySize);
        StartCoroutine("GenerateElements");
	}

}
