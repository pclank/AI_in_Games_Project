using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatuePuzzle : MonoBehaviour
{
    public GameObject S1;
    public GameObject S2;
    public GameObject S3;

    public Material matSolved;

    public bool solved = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!solved && S1.GetComponent<PuzzleStatueHandler>().inPlace && S2.GetComponent<PuzzleStatueHandler>().inPlace && S3.GetComponent<PuzzleStatueHandler>().inPlace){
            solved = true;
            int numOfChildren = transform.childCount;
            for(int i = 0; i < numOfChildren; i++)
            {
                GameObject child = transform.GetChild(i).gameObject;
                child.GetComponent<Renderer>().material = matSolved;
            }
            //S1.GetComponent<Renderer>().material = matSolved;
            //S2.GetComponent<Renderer>().material = matSolved;
            //S3.GetComponent<Renderer>().material = matSolved;
        }
    }
}
