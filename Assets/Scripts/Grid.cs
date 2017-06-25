using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{

    // set grid size
    public int xSize, ySize;

    // save all positions set by the grid
    private List<Vector2> gridPositions = new List<Vector2>();

    public CircularElement circleRef;
    private Dictionary<CircularElement, Vector2> gridElements = new Dictionary<CircularElement, Vector2>();
    private static Grid _instance;
    public static Grid Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Grid>();
            }
            return _instance;
        }
    }

    // Distance from one element to another in the grid
    public float minDistance;

    // Method for cleaning the list of positions
    public void CleanGrid()
    {
        gridPositions.Clear();
    }

    // Method to generate positions within the grid and store within the gridPositions list
    // \param xSize delimita o tamanho maximo no eixo horizontal da grid
    // \param ySize delimita o tamanho maximo no eixo vertical da grid

    public void GenerateGrid(int xSize, int ySize)
    {

        for (int y = 0; y < ySize; y++)
        {
            for (int x = 0; x < xSize; x++)
            {
                float xP = x + (minDistance * x);
                float yP = y + (minDistance * y);
                gridPositions.Add(new Vector2(xP, yP));
            }
        }
    }

    // IEnumerator method in which it generates the elements of the grid using the list with the positions.

    public IEnumerator GenerateElements()
    {
        // gridElements = new List<CircularElement>();
        for (int i = 0; i < gridPositions.Count; i++)
        {

            CircularElement element = Instantiate(circleRef, gridPositions[i], Quaternion.Euler(0, 180, 0)) as CircularElement;
            gridElements.Add(element, gridPositions[i]);
            element.name = "Element " + gridPositions[i];
            element.transform.SetParent(this.transform);
            //element.SetMaterial();
            foreach (Vector2 v in gridElements.Values)
            {
                print("Valores" + v);
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    // Use this for initialization
    void Start()
    {
        Generate();

    }

    public void Generate()
    {
        CleanGrid();
        GenerateGrid(xSize, ySize);
        StartCoroutine("GenerateElements");
    }

}
