using UnityEngine;
using System.Collections;

[System.Serializable]
public class Done_Boundary 
{
	public float xMin, xMax, zMin, zMax;
}

public class Done_PlayerController : MonoBehaviour
{
	public float speed;
	public float tilt;
	public Done_Boundary boundary;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	 
	private float nextFire;
	
    bool IsFiring()
    {
        //return Input.GetButton("Fire1");
        return GameObject.FindGameObjectWithTag("LeapController").GetComponent<LeapController>().Firing;
    }

    Vector2 Movement()
    {
        //return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		Vector3 planePosition = GameObject.FindGameObjectWithTag("LeapController").GetComponent<LeapController>().PlanePosition;
		return new Vector2 (planePosition.x, planePosition.z);
    }

	void Update ()
	{
		if (IsFiring() && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			GetComponent<AudioSource>().Play ();
		}
	}

	void FixedUpdate ()
	{
        Vector2 inputMovement = Movement();
		float moveHorizontal = inputMovement.x;
        float moveVertical = inputMovement.y; 

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		GetComponent<Rigidbody>().velocity = movement * speed;
		
		GetComponent<Rigidbody>().position = new Vector3
		(
			Mathf.Clamp (GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), 
			0.0f, 
			Mathf.Clamp (GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
		);
		
		GetComponent<Rigidbody>().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
	}
}
