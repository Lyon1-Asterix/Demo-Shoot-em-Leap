using UnityEngine;
using System.Collections;
using Leap;

public class LeapController : MonoBehaviour
{
    public float rotationSpeed = 90f;
    LeapProvider provider;

    void Start()
    {
        provider = GetComponent<LeapProvider>();
    }
    
    void Update()
    {
        if(provider.IsConnected())
        {
            //Debug.Log("HOURRA");
            Frame f = provider.CurrentFrame;
            if (f.Hands.Count > 0)
                transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
            else
                transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        }

    }

    void FixedUpdate()
    {

    }

    void OnDestroy()
    {
        
    }
}
