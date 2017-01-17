using UnityEngine;
using System.Collections;

public class InputScript : MonoBehaviour {
	
	Vector3 prevAccel;
	Quaternion prevRot;
	private float tilt = 0.3f;

	private int sizeFilter= 15;
	private Vector3[] filter;
	private Vector3 filterSum = Vector3.zero;
	private int posFilter = 0;
	private int qSamples = 0;

	// Use this for initialization
	void Start () {
		prevRot = transform.rotation;
		prevAccel = Input.acceleration.normalized;
	}
	
	// Update is called once per frame
	void Update () {
		#if(UNITY_IOS)
			ReceiveInput();
		#endif
	
	}

	void ReceiveInput(){
		
		//transform.forward = -(Input.acceleration.normalized);
		Vector3 add = MovAverage(Input.acceleration.normalized - prevAccel);

		Quaternion newRot = new Quaternion (prevRot.x + (add.y*tilt), prevRot.y, prevRot.z - (add.x*tilt), transform.rotation.w);
		transform.rotation = newRot;

		prevRot = transform.rotation;
		prevAccel =  Input.acceleration.normalized;
	}

	Vector3 MovAverage(Vector3 sample){

		if (qSamples == 0) {
			filter = new Vector3[sizeFilter];
		}

		filterSum += sample - filter[posFilter];

		filter[posFilter++] = sample;

		if (posFilter > qSamples) {
			qSamples = posFilter;
		}

		posFilter = posFilter % sizeFilter;

		return filterSum / qSamples;
	}
}


