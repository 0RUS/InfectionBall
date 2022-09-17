using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayController : MonoBehaviour
{
    public bool IsClear;

    private void Start()
    {
        IsClear = false;
    }

    private void OnTriggerStay(Collider other)
    {
        Obstacle Obstacle = other.GetComponent<Obstacle>();
        if (Obstacle != null)
        {
            IsClear = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Obstacle Obstacle = other.GetComponent<Obstacle>();
        if (Obstacle != null)
        {
            IsClear = true;
        }
    }
}
