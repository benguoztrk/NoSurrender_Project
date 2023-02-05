using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] private Image time;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI scoreText;
    public int scoreValue = 0;
    private float currentTime;
    [SerializeField] private float _duration;
    [SerializeField] private bool gameRunning;
    [SerializeField] private GameObject play;
    [SerializeField] private GameObject pause;

    private bool paused = false;


    public static UIController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

       // scoreText = GetComponent<TextMeshPro>();
    }
    void Start()
    {
        currentTime = _duration;
        timeText.text = currentTime.ToString();
        StartCoroutine(CountdownTime());
    }

    private void Update()
    {
        if (currentTime == 0)
        {
            PauseGame();
            RestartGame();
        }


        calculateScore();

    }

    public void calculateScore()
    {
        scoreText.text = "Score: " + scoreValue;
    }

    private IEnumerator CountdownTime()
    {
        while (currentTime >= 0)
        {
            time.fillAmount = Mathf.InverseLerp(0, _duration, currentTime);
            timeText.text = currentTime.ToString();
            yield return new WaitForSeconds(1f);
            currentTime--;
        }
        yield return null;
    }

   



    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        ResumeGame();

    }

    public void PauseGame()
    {
        Time.timeScale = 0;
       
        
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        

    }

    public void PausebuttonHandler()
    {

        if (paused)
        {
            Time.timeScale = 1;
            paused = false;
           

            pause.SetActive(true);
            play.SetActive(false);



        }
        else
        {
            Time.timeScale = 0;
            paused = true;
            pause.SetActive(false);
            play.SetActive(true);

        }



    }
}
