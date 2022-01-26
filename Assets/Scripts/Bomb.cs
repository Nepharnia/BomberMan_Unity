using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    public float timer = 3;

    void Update()
    {
        if (timer <= 0){
            PlayerController.currentBombs -= 1;
            FindObjectOfType<WallManager>().Explode(transform.position);
            Destroy(gameObject);

        } else
        {
            timer -= 1 * Time.deltaTime;
        }
        
    }

}
