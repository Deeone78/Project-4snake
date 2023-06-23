using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodManager : MonoBehaviour
{
    public Text inputField;
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
        int toSpawn = 10;

        try {
            toSpawn = Convert.ToInt32(inputField.text);
        } catch (System.Exception e) {
            Create(10);
            return;
        }

        Create(toSpawn);
    }

    void Create(int count) {
        for (int i = 0; i < foodList.Count; i++) {
            Destroy(foodList[i]);
        }

        for (int i = 0; i < count; i++) {
            foodList.Add(Instantiate(food));
        }
    }
}
