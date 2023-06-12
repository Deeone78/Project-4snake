using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    // Start is called before the first frame update
    private float speedY = 0;
    private float speedX = 0;
    public static float fixedTimeStep= 0.02f;
    public Vector2 _direction = Vector2.right;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)){
            _direction = Vector2.up;
            speedY = -100f;
        } else if (Input.GetKeyDown(KeyCode.S)){
            _direction = Vector2.down;
            speedY = 100f;
        }
        
        else if (Input.GetKeyDown(KeyCode.A)){
            _direction = Vector2.left;
            speedX = -100f;
        }
        else if (Input.GetKeyDown(KeyCode.D)){
            _direction = Vector2.right;
              speedX = 100f;
        }  
        else {

            speedX = 0;
            speedY = 0;
        }
    }
    private void FixedUpdate() 
        {
            this.transform.position = new Vector3    (
                Mathf.Round(this.transform.position.x)+_direction.x+speedX,
                Mathf.Round(this.transform.position.y)+_direction.y+speedY,
                0.0f
            );
        }
}
