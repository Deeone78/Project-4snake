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
    int snakeSize=2;
    bool noDown = true;
    bool noUp = true;
    bool noRight = true;
    bool noLeft = false;
    public Transform snakeHead;
    //public int snakeSizeBeta;
    //Stopped at NODOWN
    bool startLock = false;
    private void Start()
    {
        Time.timeScale = 0;
        _segments = new List<Transform>();
        _segments.Add(transform);
        playAgain.SetActive(true);

    }

    public void StartGame()
    {
        playAgain.SetActive(false);
        startLock = true;
        //snakeSize = snakeSizeBeta;
        Time.timeScale = 1.0f;
        for (int i = 1; i <_segments.Count; i++)
        {
            Destroy(_segments[i].gameObject);
        }
        _segments.Clear();
        
        _segments.Add(transform);



        transform.position = Vector3.zero;
        for (int i = 1; i<snakeSize; i++)
        {
            _segments.Add(Instantiate(snakePart));
        } 
    }

    // Update is called once per frame
    void Update()
    {
        if (startLock == true)
        {
            if (noRight == false)
            {

                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    _direction = Vector2.up;
                    snakeHead.transform.rotation = Quaternion.Euler(0, 0, 0);
                    noDown = false;
                    noUp = true;
                    noRight = true;
                    noLeft = true;
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    _direction = Vector2.down;
                    snakeHead.transform.rotation = Quaternion.Euler(0, 0, 180);
                    noDown = true;
                    noUp = false;
                    noRight = true;
                    noLeft = true;
                }


            }
            else if (noLeft == false)
            {

                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    _direction = Vector2.up;
                    snakeHead.transform.rotation = Quaternion.Euler(0, 0, 0);
                    noDown = false;
                    noUp = true;
                    noRight = true;
                    noLeft = true;
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    _direction = Vector2.down;
                    snakeHead.transform.rotation = Quaternion.Euler(0, 0, 180);
                    noDown = true;
                    noUp = false;
                    noRight = true;
                    noLeft = true;
                }
                else
                {
                    snakeHead.transform.rotation = Quaternion.Euler(0, 0, -90);
                }


            }
            else if (noDown == false)
            {



                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    _direction = Vector2.left;
                    snakeHead.transform.rotation = Quaternion.Euler(0, 0, 90);
                    noDown = true;
                    noUp = true;
                    noRight = false;
                    noLeft = true;
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    _direction = Vector2.right;
                    snakeHead.transform.rotation = Quaternion.Euler(0, 0, -90);
                    noDown = true;
                    noUp = true;
                    noRight = true;
                    noLeft = false;
                }
            }


            else if (noUp == false)
            {


                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    _direction = Vector2.left;
                    snakeHead.transform.rotation = Quaternion.Euler(0, 0, 90);
                    noDown = true;
                    noUp = true;
                    noRight = false;
                    noLeft = true;
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    _direction = Vector2.right;
                    snakeHead.transform.rotation = Quaternion.Euler(0, 0, -90);
                    noDown = true;
                    noUp = true;
                    noRight = true;
                    noLeft = false;
                }
            }

            /*
         if (noRight == true) 
         {

             if (Input.GetKeyDown(KeyCode.W))
             {
                 _direction = Vector2.up;
               //  snakeHead transform.rotation = (0,0,-90);
                 noDown = false;
                 noUp = true;
                 noRight = true;
                 noLeft = true;
             }
         }
         else if (noDown == true) 
         {
             if (Input.GetKeyDown(KeyCode.S)) {
                 _direction = Vector2.down;

                 noDown = true;
                 noUp = false;
                 noRight = true;
                 noLeft = true;
             }
         }
         else if (Input.GetKeyDown(KeyCode.A)) {
             _direction = Vector2.left;

             noDown = true;
             noUp = true;
             noRight = true;
             noLeft = false;
         }
         else if (Input.GetKeyDown(KeyCode.D)) {
             _direction = Vector2.right;

             noDown = true;
             noUp = true;
             noRight = false;
             noLeft = true;
         }
           */
        }
        else
        {

        }
      //  string hajgds = snakeSize.ToString();
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
        startLock = false;

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
