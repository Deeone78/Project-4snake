using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    // Start is called before the first frame update
    private float speedY = 0;
    private float speedX = 0;
    public static float fixedTimeStep = 0.02f;
    public Vector2 _direction = Vector2.right;
    private List<Transform> _segments;
    public Transform snakePart;

    private void Start()
    {
        _segments = new List<Transform>();
        _segments.Add(this.transform);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) {
            _direction = Vector2.up;
            speedY = -100f;
        } else if (Input.GetKeyDown(KeyCode.S)) {
            _direction = Vector2.down;
            speedY = 100f;
        }

        else if (Input.GetKeyDown(KeyCode.A)) {
            _direction = Vector2.left;
            speedX = -100f;
        }
        else if (Input.GetKeyDown(KeyCode.D)) {
            _direction = Vector2.right;
            speedX = 100f;
        }
        else {

            speedX = 0;
            speedY = 0;
        }
    }
    private void FixedUpdate() { 
        
        for(int i = _segments.Count - 1;i>0;i--)
        {
        
        {
            this.transform.position = new Vector3    (
                Mathf.Round(this.transform.position.x)+_direction.x,
                Mathf.Round(this.transform.position.y)+_direction.y,
                0.0f
            );
    }
    private void Grow()
    {
        Transform segment = Instantiate(this.snakePart);
        segment.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Food")
        {
            Grow();
        }


    }
}
