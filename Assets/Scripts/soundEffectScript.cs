using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundEffectScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private AudioSource Source;
    [SerializeField]
    private AudioClip pop;
    [SerializeField]
    private AudioClip gameOver;
    [SerializeField]
    private AudioClip click;

    private void Start()
    {
        Source = GetComponent<AudioSource>();
    }
    public void playPopSound()
    {
       
        Source.clip = pop;
        Source.Play();
    }
    public void playGameOverSound()
    {
        
        Source.clip = gameOver;
        Source.Play();
    }
    public void playClickSound()
    {

        Source.clip = click;
        Source.Play();
    }
}
