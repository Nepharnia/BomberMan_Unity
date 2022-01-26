using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WallManager : MonoBehaviour
{
    public Tilemap tilemap;

    public Tile wall;
    public Tile destrucWall;
    public GameObject explosionPrefab;
    public PlayerController Player;
    
    private Vector3Int originCell;

    private bool isContinueOkRight = true;
    private bool isContinueOkTop = true;
    private bool isContinueOkLeft = true;
    private bool isContinueOkBot = true;


    private int maxLength = 12;


    public void Explode(Vector2 pos)
    {
        originCell = tilemap.WorldToCell(pos);
        //Debug.Log(originCell);
        ExplodeCell(originCell);
        isContinueOkRight = true;
        isContinueOkTop = true;
        isContinueOkLeft = true;
        isContinueOkBot = true;
        for (int i = 1; i < maxLength; i++)
        {
            if(isContinueOkRight == true)
            {
                ExplodeCellRight(originCell + new Vector3Int (1 * i, 0, 0));
            }

            if(isContinueOkTop == true)
            {
                ExplodeCellTop(originCell + new Vector3Int (-1 * i, 0, 0));
            }

            if(isContinueOkBot == true)
            {
                ExplodeCellBottom(originCell + new Vector3Int (0, 1 * i, 0));
            }

            if(isContinueOkLeft == true)
            {
                ExplodeCellLeft(originCell + new Vector3Int (0, -1 * i, 0));
            }
        }
    }

    public void ExplodeCell(Vector3Int cell)
    {
        Tile tile = tilemap.GetTile<Tile>(cell);
        //Debug.Log(tile);
        if (tile == destrucWall)
        {
            tilemap.SetTile(cell, null);
            //Debug.Log(cell);
        }
        GameObject exp = (GameObject)Instantiate(explosionPrefab, cell, Quaternion.identity);
        Destroy(exp, 0.35f);
    }

    public void ExplodeCellRight(Vector3Int cell)
    {
        Tile tile = tilemap.GetTile<Tile>(cell);
        //Debug.Log(tile);
        if (tile == destrucWall)
        {
            tilemap.SetTile(cell, null);
            //Debug.Log(cell);
            GameObject exp = (GameObject)Instantiate(explosionPrefab, cell, Quaternion.identity);
            Destroy(exp, 0.35f);
            isContinueOkRight = false;
        }
        else if (tile == null)
        {
            GameObject exp = (GameObject)Instantiate(explosionPrefab, cell, Quaternion.identity);
            Destroy(exp, 0.35f);
        }
        else if (tile == Player)
        {
            Player.isPlayerDead = true;
        }
        else
        {
            isContinueOkRight = false;
        }
    }
    
    public void ExplodeCellTop(Vector3Int cell)
    {
        Tile tile = tilemap.GetTile<Tile>(cell);
        //Debug.Log(tile);
        if (tile == destrucWall)
        {
            tilemap.SetTile(cell, null);
            //Debug.Log(cell);
            GameObject exp = (GameObject)Instantiate(explosionPrefab, cell, Quaternion.identity);
            Destroy(exp, 0.35f);
            isContinueOkTop =  false;
        }
        else if (tile == null)
        {
            GameObject exp = (GameObject)Instantiate(explosionPrefab, cell, Quaternion.identity);
            Destroy(exp, 0.35f);
        }
        else
        {
            isContinueOkTop =  false;
        }
    }

    public void ExplodeCellBottom(Vector3Int cell)
    {
        Tile tile = tilemap.GetTile<Tile>(cell);
        //Debug.Log(tile);
        if (tile == destrucWall)
        {
            tilemap.SetTile(cell, null);
            //Debug.Log(cell);
            GameObject exp = (GameObject)Instantiate(explosionPrefab, cell, Quaternion.identity);
            Destroy(exp, 0.35f);
            isContinueOkBot = false;
        }
        else if (tile == null)
        {
            GameObject exp = (GameObject)Instantiate(explosionPrefab, cell, Quaternion.identity);
            Destroy(exp, 0.35f);
        }
        else
        {
            isContinueOkBot = false;
        }

    }

    public void ExplodeCellLeft(Vector3Int cell)
    {
        Tile tile = tilemap.GetTile<Tile>(cell);
        //Debug.Log(tile);
        if (tile == destrucWall)
        {
            tilemap.SetTile(cell, null);
            //Debug.Log(cell);
            GameObject exp = (GameObject)Instantiate(explosionPrefab, cell, Quaternion.identity);
            Destroy(exp, 0.35f);
            isContinueOkLeft = false;
        }
        else if (tile == null)
        {
            GameObject exp = (GameObject)Instantiate(explosionPrefab, cell, Quaternion.identity);
            Destroy(exp, 0.35f);
        }
        else
        {
            isContinueOkLeft = false;
        }
    }
}
