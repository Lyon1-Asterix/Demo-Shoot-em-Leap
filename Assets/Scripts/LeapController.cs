using UnityEngine;
using System.Collections;
using Leap;

public class LeapController : MonoBehaviour
{
    Controller controller;

    void Start()
    {
        controller = new Controller();
    }
    
    void Update()
    {
        Frame frame = controller.Frame();
        Debug.Log(frame.Hands.Count);
    }
}
