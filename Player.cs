using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteX;

    private Vector3 direction;
    public float gravity = -9.8f;
    public float strength = 5f;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f) ;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            direction = Vector3.up * strength;
        }
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }

    private void AnimateSprite()
    {
        spriteX++;

        if (spriteX >= sprites.Length)
        {
            spriteX = 0;
        }
        spriteRenderer.sprite = sprites[spriteX];
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            FindObjectOfType<GameManager>().GameOver();
        }
        else if (other.gameObject.tag == "Scoring")
        {
            FindObjectOfType<GameManager>().IncreaseScore();
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Loss")
        {
            FindObjectOfType<GameManager>().Loss();
            Destroy(other.gameObject);
        }
    }
}
