using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    public LineRenderer LR;

    private Vector3 _arrowStart;
    private Vector3 _arrowEnd;
    private Vector3 _targetPos;

    private void Start()
    {
        _targetPos = transform.position;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _arrowStart = Input.mousePosition;
            _arrowStart.z = transform.position.z - Camera.main.transform.position.z + 0.01f;
            _arrowStart = Camera.main.ScreenToWorldPoint(_arrowStart);
        }

        if (Input.GetMouseButton(0))
        {
            _arrowEnd = Input.mousePosition;
            _arrowEnd.z = transform.position.z - Camera.main.transform.position.z + 0.01f;
            _arrowEnd = Camera.main.ScreenToWorldPoint(_arrowEnd);

            LR.positionCount = 2;
            LR.SetPosition(0, _arrowStart);
            LR.SetPosition(1, _arrowEnd);
            LR.enabled = true;

        }
        if (Input.GetMouseButtonUp(0))
        {
            LR.enabled = false;
            _targetPos = _arrowEnd;
            _targetPos.z = transform.position.z;
            _targetPos.y = transform.position.y;
        }

        transform.position = Vector3.MoveTowards(transform.position, _targetPos, Speed * Time.deltaTime);
    }

    private void LateUpdate()
    {
        Vector3 pos = transform.position;
        pos.y = Camera.main.transform.position.y;
        pos.z = Camera.main.transform.position.z;
        Camera.main.transform.position =pos;
    }
}
