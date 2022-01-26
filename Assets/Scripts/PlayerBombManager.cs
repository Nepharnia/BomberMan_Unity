using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBombManager : MonoBehaviour
{
    public GameObject bombPrefab;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            if (PlayerController.currentBombs < PlayerController.maxBombs)
                SpawnBomb();
        }
    }

    void SpawnBomb()
    {
        GameObject sBomb = (GameObject)Instantiate(bombPrefab, new Vector3(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y), 0.0f), transform.rotation);
        PlayerController.currentBombs++;
    }
}
