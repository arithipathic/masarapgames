using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour {

    [HideInInspector] public bool facingRight = true;

    public Transform target;
    public float maxSpeed = 8f;
    public float maxDistance = 4f;
    public float distanceAbove = -2f;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
    }

    void LateUpdate() {
        Vector2 currentDistance = target.transform.position - transform.position;
        bool shouldFaceRight = (currentDistance.x > 0);

        if ((!shouldFaceRight && facingRight) || (shouldFaceRight && !facingRight)) {
            Flip();
        }

        if (currentDistance.x > maxDistance) {
            transform.position += transform.right * Mathf.Min(maxSpeed, (currentDistance.x - maxDistance)) * Time.deltaTime;
        } else if (currentDistance.x < -1 * maxDistance) {
            transform.position -= transform.right * Mathf.Min(maxSpeed, Mathf.Abs(currentDistance.x + maxDistance)) * Time.deltaTime;
        }

        if (currentDistance.y < distanceAbove) {
            transform.position -= transform.up * Mathf.Min(maxSpeed, Mathf.Abs(currentDistance.y - distanceAbove)) * Time.deltaTime;
        } else if (currentDistance.y > distanceAbove) {
            transform.position += transform.up * Mathf.Min(maxSpeed, currentDistance.y - distanceAbove) * Time.deltaTime;
        }
    }

    void Flip() {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
