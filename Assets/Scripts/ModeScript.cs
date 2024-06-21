using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class ModeScript : MonoBehaviour
{
    [SerializeField]
    private bool inGame;
    private static bool Theme=true;
    [SerializeField]
    private Sprite LightIcon;
    [SerializeField]
    private Sprite DarkIcon;
    [SerializeField]
    private Sprite Light;
    [SerializeField]
    private Sprite Dark;
    [SerializeField]
    private GameObject Sky;
    [SerializeField]
    private GameObject Border;
   [SerializeField]
    private GameObject[] windows=new GameObject[5];
    [SerializeField]
    private GameObject[] windowsTransparent = new GameObject[2];
    [SerializeField]
    private GameObject[] textObjects = new GameObject[5];
    [SerializeField]
    private Sprite[] lighDarkWindows = new Sprite[2];

    private Image spriteRenderer;
    private Manager manager;



    //0 Light 1 Dark
    // Start is called before the first frame update
    void Start()
    {
        if(inGame)
        spriteRenderer = GetComponent<Image>();
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
        setThemeObjects(Theme);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void changeTheme()
    {
        Theme = !Theme;
        manager.setTheme(Theme);
        setThemeObjects(Theme);
        

    }
    private void setThemeObjects(bool Theme)
    {
        if (inGame)
        {
            if (Theme)  //Light Mode
            {
                spriteRenderer.sprite = DarkIcon;
                Sky.GetComponent<SpriteRenderer>().sprite = Light;
                Border.GetComponent<SpriteRenderer>().color = new Color(146f / 255f, 218f / 255f, 1f, 1f);
                changeUIColours(true);
            }
            //92DAFF  
            //1A294C
            if (!Theme)  //Dark Mode
            {
                spriteRenderer.sprite = LightIcon;
                Sky.GetComponent<SpriteRenderer>().sprite = Dark;
                Border.GetComponent<SpriteRenderer>().color = new Color(26f / 255f, 41f / 255f, 76f / 255f, 1f);
                changeUIColours(false);
            }
        }
        else
        {
            if (Theme)  //Light Mode
            {
                spriteRenderer = GetComponent<Image>();

                spriteRenderer.sprite = DarkIcon;

                Sky.GetComponent<SpriteRenderer>().sprite = Light;
            }
            else  //Dark Mode
            {
                spriteRenderer = GetComponent<Image>();

                spriteRenderer.sprite = LightIcon;

                Sky.GetComponent<SpriteRenderer>().sprite = Dark;
            }
        }    

            
    }
    private void changeUIColours(bool light)
    {
        if(light)
        {
            foreach( GameObject window in windows)
                window.GetComponent<Image>().color= new Color(255f / 255f, 255f / 255f, 255f / 255f, 1f);
            foreach(GameObject text in textObjects)
                text.GetComponent<TextMeshProUGUI>().color= new Color(0f / 255f, 0f / 255f, 0f / 255f, 1f);
            foreach(GameObject window in windowsTransparent)
                window.GetComponent<SpriteRenderer>().sprite= lighDarkWindows[0];

        }
        else
        {
            foreach (GameObject window in windows)
                window.GetComponent<Image>().color = new Color(26f / 255f, 41f / 255f, 76f / 255f, 1f);
            foreach (GameObject text in textObjects)
                text.GetComponent<TextMeshProUGUI>().color = new Color(255f / 255f, 255f / 255f, 255f / 255f, 1f);
            foreach (GameObject window in windowsTransparent)
                window.GetComponent<SpriteRenderer>().sprite = lighDarkWindows[1];
        }
    }
    

}
