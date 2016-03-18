using UnityEngine;
using System.Collections;
using Leap;

[RequireComponent(typeof(LeapProvider))]
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
        

    }

    void FixedUpdate()
    {
        //var latestFrame = provider.CurrentFrame;
        //provider.PerFrameFixedUpdateOffset = latestFrame.Timestamp * 1e-6f - Time.fixedTime;

        if (provider.IsConnected())
        {
            //Debug.Log("HOURRA");
            Frame f = provider.GetFixedFrame();
            if (f.Hands.Count > 0)
            {
                Hand hand = f.Hands[0];
                Vector3 posToSet = hand.PalmPosition.ToUnity() / 50;
                Debug.Log(posToSet);
                transform.position = posToSet;
            }
        }
    }

    void OnDestroy()
    {

    }
}
