using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BalloonScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Rigidbody2D balloon;
    private Animator anim;
    [SerializeField]
    private float speed;
    private TextMeshProUGUI textMesh;
    private string word=" ";
    private soundEffectScript SoundSource;
    private ScoreManager scoreManager;
    private BalloonSpawnerScript spawner;
    public bool popped=false;
    private static float low = 0.07f;
    private static float high = 0.1f;

    void Start()
    {
        
        anim = GetComponent<Animator>();
        balloon = GetComponent<Rigidbody2D>();
        textMesh = GetComponentInChildren<TextMeshProUGUI>();
        SoundSource = GameObject.FindGameObjectWithTag("SoundEffect").GetComponent<soundEffectScript>();
        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
        spawner= GameObject.FindGameObjectWithTag("Spawner").GetComponent<BalloonSpawnerScript>();
        speed = Random.Range(low, high);


    }
    

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0f)
            balloon.AddForce(new Vector2(0, speed));
        

        // Move the text along with the balloon
        
        if (textMesh != null)
        {
            textMesh.text = word;
            textMesh.transform.position = transform.position;
        }
    }
    public void speedChange() 
    {
        if(!(high>3))
        {
        low += 0.02f;
        high += 0.02f;
        Debug.Log("High" + high);
        Debug.Log("Low" + low);
        }
        
    }
    //Called by Animation Event when the balloon Popping Animation Ends
    void destroyBalloon()
    {
        Destroy(gameObject);
    }
    void playPopSound()
    {
        SoundSource.playPopSound();
    }
    void stopRising()
    {
        
        balloon.velocity= Vector2.zero;
    }
    public void addForce()
    {
        balloon.AddForce(new Vector2(0, 3));
    }
    public bool changeText(string textToAdd)
    {
        textMesh = GetComponentInChildren<TextMeshProUGUI>();
        if (textMesh != null)
        {
            word = textToAdd;
            return true;
        }
        else
        {
            Debug.LogWarning("TextMeshProUGUI component not found!");
            return false;
        }
    }
    public string textOnBalloon()
    {
        return textMesh.text;
    }
    public void popBalloon()
    {
        anim.SetBool("popped", true);
    }
    public void lifePopped()
    {
        scoreManager.gameOver();
    }
    
}
