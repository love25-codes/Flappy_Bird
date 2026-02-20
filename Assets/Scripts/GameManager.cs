using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float timer = 0f;

    public static GameManager instance;

    public bool isGameOver = false;
    public GameObject GameOverPanel;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        isGameOver = false;
        GameOverPanel.SetActive(false);
    }

    private void Update()
    {


        if(timer <= 0f)
        {
            if (isGameOver == false)
            { 
                GameObject gm = Instantiate(obstaclePrefab, new Vector3(2f, Random.Range(-2f, 3f), 0f), Quaternion.identity);
                Destroy(gm, 5f);
                timer = 2f;
            }
        }
        else
        {
            timer -= Time.deltaTime;
           
        }
    }
    public void RetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
