using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    private Text scoreText;
    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        AddScore(0);  
    }
    private void Awake()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        MakingSingleTon();
    }
    // Update is called once per frame
    void Update()
    {
        if (scoreText == null)
        {
            scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
            scoreText.text = score.ToString();
        }
    }
    void MakingSingleTon()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void AddScore(int amount)
    {
        score += amount;
        if (score > PlayerPrefs.GetInt("HighScore", 0))
            PlayerPrefs.SetInt("HighScore", score);

        scoreText.text = score.ToString();

    }
    public void ResetScore()
    {
        score = 0;
    }
}
