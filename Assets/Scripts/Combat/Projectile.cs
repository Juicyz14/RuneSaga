using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector3 position;
    private Vector3 initialPosition;
    private float velocity; // TO-DO: higher velocity depending on how long mouse is held?
    private float angle;

    private Transform transform;

    public bool active;

    public int timeToLive;

    private float lastY;

    // Use this for initialization
    void Awake()
    {
        transform = GetComponent<Transform>();
        initialPosition = new Vector3(transform.position.x, transform.position.y);
        velocity = 0.5f;
        timeToLive = 500;
        angle = Vector2.Angle(Input.mousePosition, position);
        active = true;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 newPosition = transform.position;
        if (timeToLive <= 0)
        {
            this.active = false;
            return;
        }

        newPosition.x += velocity;
        newPosition.y = getTrajectoryY(transform.position.x, velocity);

        transform.position += newPosition;

        //transform.position += Vector3.right * velocity;
        //transform.position -= Vector3.up * getTrajectoryY(position.x, velocity);
        timeToLive--;
    }

    private float getTrajectoryY(float x, float velocity)
    {
        float relativePosition = position.x - initialPosition.x;
        return (relativePosition * (Mathf.Tan(angle))) - (((1) * (Mathf.Pow(relativePosition, 2)) / 2 * (Mathf.Pow(velocity, 2)) * Mathf.Pow(Mathf.Cos(angle), 2.0f)));
    }
}

