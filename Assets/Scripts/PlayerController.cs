using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;
    public float force = 5;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.velocity = Vector2.up * force;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "obstacles")
        {
            GameManager.instance.isGameOver = true;
            GameManager.instance.GameOverPanel.SetActive(true);

            // GameObject gm = Instantiate(SoundManager.instance.gameoverSound);
            // Destroy(gm, 1f);
            GameObject gm = Instantiate(SoundManager.instance.gameoverSound);

            AudioSource audio = gm.GetComponent<AudioSource>();
            Destroy(gm, audio.clip.length);


        }
    }
}
