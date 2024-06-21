using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI timerText;
    private float currentTime = 60f;
    private ScoreManager manager;
    private bool timeOut = false;
    // Start is called before the first frame update
    void Start()
    {
        manager=GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
        if (manager)
            Debug.Log("Yesssssssssssssssssssssssssssssssss");
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -=Time.deltaTime;
        currentTime=Mathf.Max(currentTime,0f);

        UpdateTimer();
        if(currentTime <= 0f  && !(timeOut))
        {
            Debug.Log("Yeahhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh");
            manager.gameOver();
            timeOut = true;
            
        }
    }
    private void UpdateTimer()
    {
        int secs=Mathf.FloorToInt(currentTime%60);
        timerText.text = "Time: " + secs.ToString();
    }
}
