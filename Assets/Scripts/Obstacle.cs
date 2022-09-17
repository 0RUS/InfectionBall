using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Color _infectedColor = Color.yellow; 
    private Animator _animator;

    public bool IsInfected;

    public Rigidbody Rigidbody;

    void Start()
    {
        _animator = GetComponent<Animator>();
        IsInfected = false;
    }

    public IEnumerator Infecting()
    {
        yield return new WaitForSeconds(.2f);
        GetComponent<Renderer>().material.SetColor("_Color", _infectedColor);
        _animator.SetTrigger("Infection");
        yield return new WaitForSeconds(1.5f);
        Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        Rigidbody.AddForce(new Vector2(-10, -100), ForceMode.Impulse);
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}