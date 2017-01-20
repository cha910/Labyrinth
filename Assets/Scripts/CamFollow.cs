using UnityEngine;
using System.Collections;

public class CamFollow : MonoBehaviour {
	public GameObject ball;
	public bool topDown;
	public MazeController maze;
	private float x, y, z;
	
	// Update is called once per frame
	void Update () {
		if (!topDown) {
			x = ball.transform.position.x;
			y = ball.transform.position.y+2f;
			z = ball.transform.position.z-5;
			if (y < maze.minY + 2f) {
				y = maze.minY + 2f;
			}
		} else {
			x = ball.transform.position.x;
			y = ball.transform.position.y+5;
			z = ball.transform.position.z;
			if (y < maze.minY + 5) {
				y = maze.minY + 5;
			}
		}

		transform.position = new Vector3 (x, y, z);
	}
}
