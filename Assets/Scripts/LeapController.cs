using UnityEngine;
using System.Collections;
using Leap;

[RequireComponent(typeof(LeapProvider))]
public class LeapController : MonoBehaviour
{
    public float rotationSpeed = 90f;
    private LeapProvider provider;

	// Facteur d'échelle du déplacement de la main
	public float scale = 50;
	// Position de la main dans le plan
	public Vector3 PlanePosition { get; private set; }

    void Start()
    {
        provider = GetComponent<LeapProvider>();
    }

    void Update()
    {
	}

    void FixedUpdate()
    {
        if (provider.IsConnected())
        {
            Frame f = provider.GetFixedFrame();
            if (f.Hands.Count > 0)
            {
                Hand hand = f.Hands[0];
				Vector3 posToSet = hand.PalmPosition.ToUnity() / scale;
				PlanePosition = new Vector3 (posToSet.x, 0, - posToSet.z);
            }
        }
    }

    void OnDestroy()
    {

    }
}
