using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private float _startTime;
    private float _size;

    private bool _isMobile;

    public bool IsGameOver;

    private Vector3 _prevSpherelSize;

    private Vector3 _prevWaylSize;

    public GameObject GlobalSphere;

    public BallController Ball;

    public WayController Way;

    public GameOverScreen Screen;

    public Rigidbody SphereRigitbody;

    void Start()
    {
        _isMobile = Application.isMobilePlatform;
        _startTime = 0;
        Ball.IsReleased = false;
        Ball.IsCharged = false;
    }

    void Update()
    {
        if (!IsGameOver)
        {
            if (Way.IsClear)
            {
                StartCoroutine(ToFinish());
                return;
            }
            if (!_isMobile)
            {
                if (Input.GetMouseButton(0))
                {
                    if (!Ball.IsReleased)
                        Charge();
                    return;
                }
                _startTime = Time.time;
                _prevSpherelSize = GlobalSphere.transform.localScale;
                _prevWaylSize = Way.transform.localScale;
                if (Ball.IsCharged && !Ball.IsReleased)
                {
                    Shoot();
                }
            }
            else
            {
                if (Input.touchCount > 0)
                {
                    if (!Ball.IsReleased)
                        Charge();
                    return;
                }
                _startTime = Time.time;
                _prevSpherelSize = GlobalSphere.transform.localScale;
                _prevWaylSize = Way.transform.localScale;
                if (Ball.IsCharged && !Ball.IsReleased)
                {
                    Shoot();
                }
            }
        }
    }

    private void Charge()
    {
        _size = (Time.time - _startTime + 0.1f);
        DecreaseSize();
        Ball.transform.localScale = new Vector3(_size, _size, _size);
        Ball.IsCharged = true;
    }

    private void Shoot()
    {
        if (!Ball.IsReleased)
        {
            Ball.IsReleased = true;
            Ball.Rigidbody.AddForce(new Vector2(5, 1), ForceMode.Impulse);
        }
    }

    private void DecreaseSize()
    {
        GlobalSphere.transform.localScale = _prevSpherelSize - new Vector3(_size, _size, _size);
        if (GlobalSphere.transform.localScale.x < 0.5f)
        {
            Screen.GameOver();
            IsGameOver = true;
            return;
        }
        Way.transform.localScale = _prevWaylSize - new Vector3(0, 0, _size/9.5f);
    }

    IEnumerator ToFinish()
    {
        IsGameOver = true;
        for (int i = 0; i < 5; i++)
        {
            SphereRigitbody.constraints = RigidbodyConstraints.FreezeRotation;
            SphereRigitbody.AddForce(new Vector2(GlobalSphere.transform.position.x + 3.5f, GlobalSphere.transform.position.y + 1.5f), ForceMode.Impulse);
            yield return new WaitForSeconds(0.6f);
            SphereRigitbody.constraints = RigidbodyConstraints.FreezeAll;
        }
        Screen.Finish();
    }
}
