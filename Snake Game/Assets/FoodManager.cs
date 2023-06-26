using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FoodManager : MonoBehaviour
{
    public TMP_Text inputField;
    //private int numApples;
    public GameObject food;
    List<GameObject> foodList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        SpawnApples();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnApples()
    {
        // int toSpawn = int.ToSting(inputField.text);
        int toSpawn = Convert.ToInt32(inputField);
        //  string hajgds = snakeSize.ToString();

        for (int i = 0; i < foodList.Count; i++) {
            Destroy(foodList[i]);
        }

        for (int i = 0; i < toSpawn; i++) {
            foodList.Add(Instantiate(food));
        }
    }
}
