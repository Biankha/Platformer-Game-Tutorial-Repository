using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rd2d;
    public float speed;
    public Text scoreText;
    public Text winText;
    public Text livesText;
    public Text levelText;
    private int scoreValue = 0;
    private int lives;
    public GameObject other;
    public AudioSource musicSource;
    public AudioClip musicClipOne;
    public AudioClip musicClipTwo;
    Animator anim;
    private bool facingRight = true;

    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        scoreText.text = "Score: " + scoreValue.ToString();
        winText.text = "";
        levelText.text = "";
        livesText.text = "Lives: 3";
        lives = 3;
        musicSource.clip = musicClipTwo;
        musicSource.Play();
        SetWinText();
        SetScoreText();
        anim = GetComponent<Animator>();

    }

    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float verMovement = Input.GetAxis("Vertical");
        rd2d.AddForce(new Vector2(hozMovement * speed, verMovement * speed));

        if (facingRight == false && hozMovement > 0) //for facing both ways
        {
            Flip();
        }
        else if (facingRight == true && hozMovement < 0)
        {
            Flip();
        }

        if (Input.GetKey("escape"))
            Application.Quit();
    }

    private void OnCollisionEnter2D(Collision2D collision) //for making coins disappear
    {
        if (collision.collider.tag == "Coin")
        {
            scoreValue += 1;
            scoreText.text = "Score: " + scoreValue.ToString();
            Destroy(collision.collider.gameObject);
            SetWinText();
            SetScoreText(); 
        }
    }

    private void OnCollisionStay2D(Collision2D collision) //for jumping
    {
        if (collision.collider.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(0, 3), ForceMode2D.Impulse);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) //to make enemies disappear
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            lives = lives - 1;
            SetLivesText();
            SetScoreText();
        }
    }

    void SetScoreText()
    {
        if (scoreValue == 4)
        {
            livesText.text = "Lives: 3";
            lives = 3;
            transform.position = new Vector2(42.27f, -0.15f);
            levelText.text = "Level 2";
        }

        else if (scoreValue > 5)
        {
            levelText.text = "";
        }
    }

    void SetWinText()
    {
        winText.text = "";
        if (scoreValue == 8)
        {
            winText.text = "You win! \n Game created by Biankha Hughes!";
            musicSource.clip = musicClipOne;
            musicSource.Play();
        }
    }

    void SetLivesText()
    {
        livesText.text = "Lives: " + lives.ToString();
        if (lives <= 0)
        {
            winText.text = "You Lose! \n Game created by Biankha Hughes.";
        }
    }

    void Flip() //flips character
    {
        facingRight = !facingRight;
        Vector2 Scaler = transform.localScale;
        Scaler.x = Scaler.x * -1;
        transform.localScale = Scaler;
    }
}


