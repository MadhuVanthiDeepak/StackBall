using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameUI : MonoBehaviour
{
    [Header("InGame")]
    public Image levelSlider;
    public Image currentLevelImage;
    public Image nextLevelImg;


    private Material ballMat;
    private bool Buttons;
    public GameObject allButtons;
    public GameObject homeUI, inGameUI,finishUI,gameOverUI;
    private Ball ball;

    [Header("Finish")]
    public Text finishLevelText;

    [Header("GameOver")]
    public Text gameOverScoreText;
    public Text gameOverBestText;

    [Header("PreGame")]
    public Button soundButton;
    public Sprite soundOns, soundOffs;

    public Text  currentLevelText;
        public Text nextLevelText;
    void Awake()
    {
        ball = FindObjectOfType<Ball>();
        ballMat = FindObjectOfType<Ball>().transform.GetChild(0).GetComponent<MeshRenderer>().material;
        levelSlider.transform.parent.GetComponent<Image>().color = ballMat.color + Color.gray;
        levelSlider.color = ballMat.color;
        currentLevelImage.color = ballMat.color;
        nextLevelImg.color = ballMat.color;

        soundButton.onClick.AddListener(() => SoundManager.instance.SoundOnOff());
    }
    private void Update()
    {
        if (ball.ballState == Ball.BallState.Prepare)
        {
            if (SoundManager.instance.sound && soundButton.GetComponent<Image>().sprite != soundOns)
                soundButton.GetComponent<Image>().sprite = soundOns;
            else if (!SoundManager.instance.sound && soundButton.GetComponent<Image>().sprite != soundOffs)
                soundButton.GetComponent<Image>().sprite = soundOffs;
        }
        if (Input.GetMouseButtonDown(0) && !IgnoreUI() && ball.ballState == Ball.BallState.Prepare)
        {
            ball.ballState = Ball.BallState.Playing;
            homeUI.SetActive(false);
            inGameUI.SetActive(true);
            finishUI.SetActive(false);
            gameOverUI.SetActive(false);
        }
        if (ball.ballState == Ball.BallState.Finish)
        {
            homeUI.SetActive(false);
            inGameUI.SetActive(false);
            finishUI.SetActive(true);
            gameOverUI.SetActive(false);

            finishLevelText.text = "Level" + FindObjectOfType < LevelSpawner>().level;
        }
        if (ball.ballState == Ball.BallState.Died)
        {
            homeUI.SetActive(false);
            inGameUI.SetActive(false);
            finishUI.SetActive(false);
            gameOverUI.SetActive(true);

            gameOverScoreText.text = ScoreManager.instance.score.ToString();
            gameOverBestText.text = PlayerPrefs.GetInt("HighScore").ToString();

            if (Input.GetMouseButtonDown(0))
            {
                ScoreManager.instance.ResetScore();
                SceneManager.LoadScene(0);
            }
        }
    }
    private void Start()
    {
        currentLevelText.text = FindObjectOfType<LevelSpawner>().level.ToString();
        nextLevelText.text=FindObjectOfType<LevelSpawner>().level+1+"";
    }
    private bool IgnoreUI()
    {
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.position = Input.mousePosition;
        List<RaycastResult> raycastResultsList = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, raycastResultsList);
        for (int i = 0; i < raycastResultsList.Count; i++)
        {
            if (raycastResultsList[i].gameObject.GetComponent<Ignore>() != null)
            {
                raycastResultsList.RemoveAt(i);
                i--;
            }
        }
        return raycastResultsList.Count > 0;
    }

    public void LevelSliderFill(float fillAmount)
    {
        levelSlider.fillAmount = fillAmount;
    }


    public void Settings()
    {
        Buttons = !Buttons;
        allButtons.SetActive(Buttons);
    }
}






















































































































































































































































































































































































































































































































































































































































































































































































































































































