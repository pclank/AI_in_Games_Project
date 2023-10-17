using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleStatueHandler : MonoBehaviour
{
    public GameObject Spot;

    public bool inPlace = false;

    private bool ray_hit = false;

    public void setRaycast(bool flag)
    {
        ray_hit = flag;
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject == Spot)
        {
            inPlace = true;
        }
    }

    void OnTriggerExit(Collider other){
        if(other.gameObject == Spot)
        {
            inPlace = false;
        }
    }
}
