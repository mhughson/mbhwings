using UnityEngine;
using System.Collections;

public class planemovement : MonoBehaviour {
	
	/// <summary>
	/// The speed at which the plane travels every frame.
	/// </summary>
	public float moveSpeed = 10;
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate(new Vector3(0,0,moveSpeed) * Time.deltaTime);
	}
}
