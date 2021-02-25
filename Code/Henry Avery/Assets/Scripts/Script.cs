using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Script : MonoBehaviour
{
    Rigidbody2D rigidBody;
    public float moveSpeed = 10f;
    bool isFacingRight = true;
    Animator anim;
        bool isGrounded = false;
        public Transform groundCheck;
        float groundRadius = 0.2f;
        public LayerMask whatIsGround;

    void Start()
    {
        TakeCoins.coinsCount = 0;
        anim = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Run();

        if (PlayerPrefs.HasKey("SaveDeaths"))
        {
            HowManyDeaths.deathsCount = PlayerPrefs.GetInt("SaveDeaths");
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("Ground", isGrounded);
        anim.SetFloat("vSpeed", rigidBody.velocity.y);

        if (!isGrounded)
            return;
    }

    public void Run()
    {
        float move = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(move));
        rigidBody.velocity = new Vector2(move * moveSpeed, rigidBody.velocity.y);

        if (move > 0 && !isFacingRight)
            Flip();
        else if (move < 0 && isFacingRight)
            Flip();
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void Update()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Ground", false);
            rigidBody.AddForce(new Vector2(0, 1050));
        }

        if (TakeCoins.coinsCount >= 110)
        {
            SceneManager.LoadScene(2);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Coin"))
        {
            SoundManager.snd.PlayCoinSounds();
            TakeCoins.coinsCount += 1;
            PlayerPrefs.SetInt("SaveCoins", TakeCoins.coinsCount);
            Destroy(collision.gameObject);
        }

        if(collision.tag.Equals("BigCoin"))
        {
            SoundManager.snd.PlayCoinSounds();
            TakeCoins.coinsCount += 10;
            PlayerPrefs.SetInt("SaveCoins", TakeCoins.coinsCount);
            Destroy(collision.gameObject);
        }

        if(collision.tag == "Death")
        {
            HowManyDeaths.deathsCount += 1;
            PlayerPrefs.SetInt("SaveDeaths", HowManyDeaths.deathsCount);
            SceneManager.LoadScene(1);
        }
    }
}