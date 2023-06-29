using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    // Start is called before the first frame update
    BoxCollider2D gridArea;

    private void Start()
    {
        gridArea = GameObject.Find("GridArea").GetComponent<BoxCollider2D>();
        RandomizePostion();
    }

    private void RandomizePostion()
    {
        Bounds bounds = this.gridArea.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);

        /*if (Mathf.Round(x)&&Mathf.Round(y))
        {
            float x = Random.Range(bounds.min.x, bounds.max.x);
            float y = Random.Range(bounds.min.y, bounds.max.y);
            this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);

        }*/

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Player")
        {
            RandomizePostion();
        }
        

    }
}
