using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    bool colliding = false;
    void Start(){
        if (colliding){
            Destroy(this.gameObject);
        }
        else{
            Destroy(this);
        }
    }
    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Food" || other.tag == "Obstacle"){
            colliding = true;
        }
    }
}
