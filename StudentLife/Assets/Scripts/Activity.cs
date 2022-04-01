using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activity : MonoBehaviour
{
    public int fullness;
    public int energy;
    public int motivation;
    public int restfulness;
    public int peacefulness;
    public int hour;
    public int minute;
    public string taskMessage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Activity getActivity()
    {
        return this;
    }
}
