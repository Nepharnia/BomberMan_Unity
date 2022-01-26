using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float speed = 5.0f;
    public float moveY;
    public float moveX;
    public static int maxBombs = 5;
    public static int currentBombs = 0;
    public GameObject RestartButton;

    private Rigidbody2D rb;
    private Vector2 position;
    private Animator animator;
    private Vector2 move;
    public bool isPlayerDead = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        RestartButton.SetActive(false);

    }

    void Update()
    {
        move.y = Input.GetAxisRaw("Vertical");
        move.x = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("AxeVertical", move.y);
        animator.SetFloat("AxeHorizontal", move.x);
        animator.SetFloat("Speed", move.sqrMagnitude);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + move.normalized * speed * Time.fixedDeltaTime);
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Explosion"))
        {
            Debug.Log("Echec");
            isPlayerDead = true;
            GetComponent<SpriteRenderer>().enabled = false;
            RestartButton.SetActive(true);
            //RestartMenu();
        }
    }

    public void RestartMenu()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        transform.position = new Vector2(0.0f, 0.0f);
        SceneManager.LoadScene("GameScene");
    }



}
