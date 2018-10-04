using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;
    public float boundary;

    private Vector3 offset;
    private Vector3 playerPosition;
    private float viewportCenter = 0.5f;

	// Use this for initialization
	void Start () {

	}
	
	void LateUpdate () {
        playerPosition = Camera.main.WorldToViewportPoint(player.transform.position);
        if (playerPosition.x < boundary) {
            transform.position = Camera.main.ViewportToWorldPoint(new Vector3(playerPosition.x - boundary + viewportCenter, viewportCenter));
        } else if (1.0 - boundary < playerPosition.x) {
            transform.position = Camera.main.ViewportToWorldPoint(new Vector3(playerPosition.x + boundary - viewportCenter, viewportCenter));
        }
        if (playerPosition.y < boundary) {
            transform.position = Camera.main.ViewportToWorldPoint(new Vector3(viewportCenter, playerPosition.y - boundary + viewportCenter));
        } else if (1.0 - boundary < playerPosition.y) {
            transform.position = Camera.main.ViewportToWorldPoint(new Vector3(viewportCenter, playerPosition.y + boundary - viewportCenter));
        }
	}
}
