using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    // Start is called before the first frame update
    BoxCollider2D gridArea;
    bool colliding = false;

    private void Awake()
    {
        gridArea = GameObject.Find("GridArea").GetComponent<BoxCollider2D>();

        Debug.Log(gridArea);

        RandomizePostion();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
           // Destroy(gameObject);
           RandomizePostion();
        }
        
        if (other.tag == "Food" || other.tag == "Obstacle"){
            RandomizePostion();
        }
    }

    private void RandomizePostion()
    {
        Bounds bounds = gridArea.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
    }

}
