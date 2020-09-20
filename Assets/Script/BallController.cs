using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class BallController : MonoBehaviour {
    public int force;
    Rigidbody2D rigid;
    int scoreP1;
    int scoreP2;
    public Text scoreDisplay;
    public Text scoreDisplay2;
    public Text scoreOver2;
    public Text scoreOver4;
    public GameObject gameOver;
    public GameObject gameOver2;
    AudioSource audio;
    public AudioClip hitSound;
    public GameObject gameOverSound;
    
    void Start () {
        rigid = GetComponent<Rigidbody2D> ();
        Vector2 arah = new Vector2 (2, 0).normalized;
        rigid.AddForce (arah * force);
        scoreP1 = 0;
        scoreP2 = 0;
        audio = GetComponent<AudioSource>();    
    }
 
    void Update () 
    {
        Time.timeScale = 1;
    	scoreDisplay.text = scoreP1.ToString();
    	scoreDisplay2.text = scoreP2.ToString();
    	scoreOver2.text = scoreP2.ToString();
    	scoreOver4.text = scoreP1.ToString();
    }
 
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.name == "Collision Right") 
        {
        	scoreP1 += 1;
            ResetBall ();
            if (scoreP1 == 10) 
            {
                Instantiate(gameOverSound, transform.position, Quaternion.identity);
                gameOver.SetActive(true);
                Destroy(gameObject);
                Time.timeScale = 0;
            }
            Vector2 arah = new Vector2 (2, 0).normalized;
            rigid.AddForce (arah * force);
        }
        if (other.gameObject.name == "Collision Left") 
        {	
        	scoreP2 += 1;
            ResetBall ();
            if (scoreP2 == 10) 
            {
                Instantiate(gameOverSound, transform.position, Quaternion.identity);
                gameOver2.SetActive(true);
                Destroy(gameObject);
                Time.timeScale = 0;
            }
            Vector2 arah = new Vector2 (-2, 0).normalized;
            rigid.AddForce (arah * force);
        }
        if (other.gameObject.name == "Paddle" || other.gameObject.name == "Paddle 2") 
        {
            float sudut = (transform.position.y - other.transform.position.y) * 5f;
            Vector2 arah = new Vector2(rigid.velocity.x, sudut).normalized;
            rigid.velocity = new Vector2(0, 0);    
            rigid.AddForce(arah * force * 2);
            audio.PlayOneShot(hitSound);
        }
        if (other.gameObject.name == "Wall Bottom" || other.gameObject.name == "Wall Up") 
        {
            audio.PlayOneShot(hitSound);
        }
    }
    
    void ResetBall () {
        transform.localPosition = new Vector2 (0, 0);
        rigid.velocity = new Vector2 (0, 0);
    }    
}