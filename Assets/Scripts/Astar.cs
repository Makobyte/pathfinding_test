using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public enum TileType {START, GOAL, PLACEMENT, GRASS, PATH}


public class Astar : MonoBehaviour
{
    private TileType tileType;
    [SerializeField]
    private Tilemap tilemap;
    [SerializeField]
    public Camera camera;
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private Tile[] tiles;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(camera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, layerMask);

            if (hit.collider != null)
            {
                Vector3 mouseWorldPos = camera.ScreenToWorldPoint(Input.mousePosition);
                Vector3Int clickPos = tilemap.WorldToCell(mouseWorldPos);
                ChangeTile(clickPos);
            }
        }
    }

    private void ChangeTile(Vector3Int clickPos)
    {
        tilemap.SetTile(clickPos, tiles[(int)tileType]);
    }

    public void ChangeTileType(TileButton Button)
    {
        tileType = Button.MyTileType;
    }
}
