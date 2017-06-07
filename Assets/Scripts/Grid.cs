using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {

    public int xSize, ySize;  /*!< Limita o tamanho da grid */


    private List<Vector2> gridPositions = new List<Vector2>();  /*!< Armazena as posições geradas para a grid */

    public CircularElement circleRef;
    //[HideInInspector]
    //public List<CircularElement> gridElements;

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

    public float minDistance; /*!< Distancia de um elemento a outro na grid */
    /*!
      Metodo para a limpeza da lista de posições
    */
    public void CleanGrid()
    {
        gridPositions.Clear();
    }


    /*!
      Metodo para gerar posições dentro da grid e armazena dentro da lista 'gridPositions'
        \param xSize delimita o tamanho maximo no eixo horizontal da grid
        \param ySize delimita o tamanho maximo no eixo vertical da grid
    */
    public void GenerateGrid(int xSize, int ySize)
    {
        
        for(int y = 0; y < ySize; y++)
        {
            for(int x = 0; x < xSize; x++)
            {
                float xP = x + (minDistance * x);
                float yP = y + (minDistance * y);
                gridPositions.Add(new Vector2(xP, yP));
            }
        }
    }

    /*!
      Metodo IEnumerator no qual gera os elementos da grid usando as lista com as posições.
    */
    public IEnumerator GenerateElements()
    {
       // gridElements = new List<CircularElement>();
        for(int i = 0; i < gridPositions.Count; i++)
        {
            
            CircularElement element = Instantiate(circleRef, gridPositions[i], Quaternion.Euler(0,180,0)) as CircularElement;
            gridElements.Add(element, gridPositions[i]);
            element.name = "Element " + gridPositions[i];
            element.transform.SetParent(this.transform);
            //element.SetMaterial();
            foreach(Vector2 v in gridElements.Values){
                print("Valores" + v);
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

	// Use this for initialization
	void Start () {
        Generate();

    }

    public void Generate()
    {
        CleanGrid();
        GenerateGrid(xSize, ySize);
        StartCoroutine("GenerateElements");
    }

}
