using QuantumTek.QuantumUI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    [SerializeField] 
    private GameObject pauseMenuWindow;
    [SerializeField]
    private GameObject windowContent;


    private static string Mode;
    private ScoreManager manager;
    private static bool Volume;

    private static bool Theme=true;
    private void Start()
    {
        
        pauseMenuWindow.SetActive(false);
        manager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.T))
        {
            Debug.Log("Modeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee:" + Mode);
        }
    }
    public void StartGame()
    {
        StartGame(Mode);
    }
    public  void StartGame(string gameMode)
    {
        Mode=gameMode;
        
        Time.timeScale = 1.0f;

        //getGameObjects();
#if UNITY_EDITOR
        Debug.Log("Start game");
#endif
        //saveState();
        Debug.Log("Modeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee:" + Mode);

        SceneManager.LoadScene("GamePlay");
        Debug.Log("Modeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee:" + Mode);

       // manager.Modee(Mode);

        //getGameObjects();
        // loadState();

    }
    public string returnMode()
    {
        return Mode;
    }
    public bool returnTheme()
    {
        return Theme;
    }
    public void setTheme(bool val)
    {
        Theme = val;
    }
   
    public void ChangeDifficulty(int diff)
    {

    }
    public  void Pause()
    {
        manager.InputState(false);
        Time.timeScale = 0f;
        pauseMenuWindow.SetActive(true);
        windowContent.SetActive(true);
        //ActivateChildrenRecursively(pauseMenu.transform);   


    }
    public void Resume()
    {
        manager.InputState(true);

        pauseMenuWindow.SetActive(false);
        windowContent.SetActive(false);
        Time.timeScale = 1f;
    }
    public  void Quit()
    {

        //getGameObjects();
        //saveState();
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        //getGameObjects();
       // loadState();


    }
    public void Settings()
    {
        
        windowContent.SetActive(false);
    }
    public void closeSettings()
    {
        
        windowContent.SetActive(true);
    }
    public void closeApplication()
    {
        Application.Quit();
    }

    
//    private void getGameObjects()
//    {
//#if UNITY_EDITOR
//        Debug.Log("Hwllo");
//#endif
//        GameObject mainMenu = GameObject.FindGameObjectWithTag("MainMenu");
//        soundToggle=FindChildWithTag(mainMenu.transform,"Sound").GetComponent<Toggle>();
//        soundToggle = GameObject.FindGameObjectWithTag("Sound").GetComponent<Toggle>();
//        musicSlider = FindChildWithTag(mainMenu.transform, "Volume").GetComponent<Slider>();
//        optionScript= FindChildWithTag(mainMenu.transform, "Difficulty").GetComponent<QUI_OptionList>();
//#if UNITY_EDITOR
//        Debug.Log("Hwllo");
//#endif

//    }
//    GameObject FindChildWithTag(Transform parent, string tag)
//    {
//        foreach (Transform child in parent)
//        {
//            if (child.CompareTag(tag))
//            {
//                return child.gameObject;
//            }
//            GameObject found = FindChildWithTag(child, tag);
//            if (found != null)
//            {
//                return found;
//            }
//        }
//        return null;
//#if UNITY_EDITOR
//        Debug.Log("Hwlloooooooooooooo");
//#endif
//    }
//    private void saveState()
//    {
//#if UNITY_EDITOR
//        Debug.Log("Save Called");
//#endif
//        sound = soundToggle.isOn;
//        music = musicSlider.value;
//#if UNITY_EDITOR
//        Debug.Log("Save Done");
//#endif
//    }
//    private void loadState()
//    {
//#if UNITY_EDITOR
//        Debug.Log("Load Called");
//#endif
//        soundToggle.isOn= sound ;
//        musicSlider.value= music;
//#if UNITY_EDITOR
//        Debug.Log("Load Done");
//#endif
//    }
}

