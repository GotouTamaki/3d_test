using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    [SerializeField] private int _gridSize;
    [SerializeField] private float _xOffset;
    [SerializeField] private float _zOffset;
    [SerializeField] private List<Vector2> _obstacleCoordinates;

    private GameObject[] _cubes;
    private void Start()
    {
        int[,] grid = new int[_gridSize, _gridSize];
        _cubes = new GameObject[_gridSize];

        for (int i = 0; i < _gridSize; i++)
        {
            for (int j = 0; j < _gridSize; j++)
            {
                _cubes[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
                _cubes[i].transform.position = new Vector3(i + _xOffset, 0, j + _zOffset);

                if (j == _obstacleCoordinates[i].y)
                {
                    Material mat = _cubes[i].GetComponent<MeshRenderer>().material;
                    mat.color = Color.red;
                }
            }
        }
    }
}