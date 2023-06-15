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
    public GameObject playAgain;
    int snakeSize=3;
    bool noDown = true;
    bool noUp = true;
    bool noright = true;
    bool noLeft = true;
    //public int snakeSizeBeta;
    //Stopped at NODOWN
    private void Start()
    {
        Time.timeScale = 0;
        _segments = new List<Transform>();
        _segments.Add(this.transform);
        playAgain.SetActive(true);

    }
    public void StartGame()
    {
        playAgain.SetActive(false);
        //snakeSize = snakeSizeBeta;
        Time.timeScale = 1.0f;
        for (int i = 1; i <_segments.Count; i++)
        {
            Destroy(_segments[i].gameObject);
        }
        _segments.Clear();
     
        _segments.Add(this.transform);

        this.transform.position = Vector3.zero;
          for (int i = 1; i<this.snakeSize; i++)
          {

           _segments.Add(Instantiate(this.snakePart));
          }
       
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
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _direction = Vector2.up;
            speedY = -100f;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _direction = Vector2.down;
            speedY = 100f;
        }

        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _direction = Vector2.left;
            speedX = -100f;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
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

        for (int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].position = _segments[i - 1].position;
        }
        this.transform.position = new Vector3(
           Mathf.Round(this.transform.position.x) + _direction.x,
           Mathf.Round(this.transform.position.y) + _direction.y,
           0.0f
            );
        

    }
    private void Grow()
    {
        Transform segment = Instantiate(this.snakePart);
        segment.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment);
    }

    private void Endgame()
    {
        Time.timeScale = 0.0f;
        playAgain.SetActive(true);

    }


    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Food")
        {
            Grow();
        }
        else if (other.tag == "Obstacle")
        {
            Endgame();

        }

    }
}
