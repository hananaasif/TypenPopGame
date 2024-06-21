using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private BalloonScript[] lifeBalloons= new BalloonScript[5];
    private int score = 0;
    private int lives = 5;
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private TextMeshProUGUI scoreDisplay;
    [SerializeField]
    private TextMeshProUGUI BalloonsPoppedDisplay;
    private BalloonSpawnerScript balloonSpawner;
    [SerializeField]
    private GameObject gameOverScreen;
    [SerializeField]
    private TMP_InputField inputField;
    private soundEffectScript soundEffect;
    private AudioSource audioSource;
    private Manager manager;
    

    public static string Mode;
    [SerializeField]
    private GameObject Lives;
    [SerializeField]
    private GameObject Timer;

    // Start is called before the first frame update
    void Start()
    {
        gameOverScreen.SetActive(false);
        scoreText = GetComponentInChildren<TextMeshProUGUI>();
        scoreText.text = "0";
        balloonSpawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<BalloonSpawnerScript>();
        soundEffect = GameObject.FindGameObjectWithTag("SoundEffect").GetComponent<soundEffectScript>();
        audioSource=GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
        if (manager)
        {
            Mode = manager.returnMode();
            if (Mode == "Timer")
            {
                Lives.SetActive(false);
                Timer.SetActive(true);

            }
            else
            {
                Lives.SetActive(true);
                Timer.SetActive(false);

            }
        }
        


    }
    public void Modee(string mode)
    {
        Mode = mode;
        if (Mode == "Timer")
            Lives.SetActive(false);
        else
            Timer.SetActive(false);
    }

    // Update is called once per frame
    public void setScore()
    {
        BalloonsPoppedDisplay.text = "Balloons Popped: " + score.ToString();
        scoreDisplay.text = "Score: " + (score*5).ToString();
    }
    public void setLives()
    {
        lives = 5; score=0;
    }
    void Update()
    {
        
    }
    public int getLives()
    {
        return lives;
    }
    public void addscore()
    {
        score++;
        scoreText.text = score.ToString();
    }
    public void addMissed()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Balloon") && lives>0)
        {
            BalloonScript balloon=collision.gameObject.GetComponent<BalloonScript>();
           
            if(!balloon.popped)
            {
                balloonSpawner.removeBalloon(balloon);
                reduceLifes();
            }
            
        }
        
    }

    private void reduceLifes()
    {
        if(Mode!="Timer")
        {
            lives--;
            lifeBalloons[lives].popBalloon();
        }
        

    }
    public void gameOver()
    {
        if(lives<=0 || Mode=="Timer")
        {
            setScore();
            gameOverScreen.SetActive(true);
            audioSource.Pause();
            soundEffect.playGameOverSound();
            Time.timeScale = 0f;
            InputState(false);
        }
        

    }
    public void InputState(bool val)
    {
        inputField.enabled = val;
    }


}
