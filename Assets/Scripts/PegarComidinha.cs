using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegarComidinha : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        if( collision.gameObject.tag == "Player")
        {

        }
    }

}
