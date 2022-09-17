using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Rigidbody Rigidbody;

    public bool IsCharged;
    public bool IsReleased;

    private void OnCollisionEnter(Collision collision)
    {
        Default();
    }

    private void OnTriggerEnter(Collider other)
    {
        Obstacle Obstacle = other.GetComponent<Obstacle>();
        if (Obstacle != null)
        {
            if (!Obstacle.IsInfected)
            {
                Obstacle.IsInfected = true;
                StartCoroutine(Obstacle.Infecting());
            }
        }
    }

    public void Default()
    {
        transform.localScale = Vector3.zero;
        transform.position = new Vector3(2, 1, 0);
        Rigidbody.velocity = Vector3.zero;
        IsReleased = false;
        IsCharged = false;
    }
}