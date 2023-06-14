using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
	private float speed = 30;
	private PlayerController playerControllerScript;
	private float leftBound = -15;
	int score1;


	// Start is called before the first frame update
	void Start()
    {
		playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
		float score = Time.deltaTime * speed;
		if (Input.GetKey(KeyCode.LeftShift))
		{
			speed =60;
		}
        else
        {
			speed = 30;
        }
		if (playerControllerScript.gameOver == false)
		{
			transform.Translate(Vector3.left * Time.deltaTime * speed);
			Debug.Log("score =" + score * 100);
		}

		if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
		{
			Destroy(gameObject);
		}

		if (playerControllerScript.gameOver == true)
        {
			score = score;
        }

	}
}
