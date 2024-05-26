using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private GameObject tilePrefab;

    [SerializeField] private float xStartGridPosition = 5.5f;
    [SerializeField] private int mapWidth;
    [SerializeField] private int mapHeight;
    [SerializeField] private float tileSize;

    private void Start()
    {
        MakeMapGrid();
    }

    private void MakeMapGrid()
    {
        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                Vector2 hexCoor = GetHexCoor((int)(x - xStartGridPosition), y);

                Vector3 position = new Vector3(hexCoor.x, hexCoor.y, 0);

                GameObject tile = Instantiate(tilePrefab, position, Quaternion.identity, transform);
            }
        }
    }

    // This method is to generate the hexagonal grid
    private Vector2 GetHexCoor(int x, int y)
    {
        float xPos = x * tileSize * Mathf.Cos(Mathf.Deg2Rad * 30);
        float yPos = y * tileSize + ((x % 2 == 1 || x % 2 == -1) ? tileSize * 0.5f : 0);

        return new Vector2(xPos, yPos);
    }
}