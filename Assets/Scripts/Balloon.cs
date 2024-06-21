using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Balloon : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D balloon;

    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Sprite[] image=new Sprite[5];
    
    // Start is called before the first frame update
    void Start()
    {
        balloon=GetComponent<Rigidbody2D>();
        spriteRenderer=GetComponent<SpriteRenderer>();
        spriteRenderer.sprite= image[Random.Range(0,5)];
    }

    // Update is called once per frame
    void Update()
    {
        balloon.velocity = new Vector2(0, Random.Range(1f,3f));
        
    }

}
