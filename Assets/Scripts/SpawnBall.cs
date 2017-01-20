using UnityEngine;
using System.Collections;

public class SpawnBall : MonoBehaviour {
	public GameObject ball;
	public Vector3 startPosition;

	public MazeController maze;

	// Update is called once per frame
	void Update () {
		if (ball.transform.position.y < maze.minY) {
			ResetBall ();
		}
	}

	void ResetBall(){
		ball.transform.position = startPosition;
	}
}
