using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MenuSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject balloon;
     

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
               

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.gameObject.transform.position = new Vector2((collision.gameObject.transform.position.x+Random.Range(-10f,10f))%10, collision.gameObject.transform.position.y-15);
    }



}
