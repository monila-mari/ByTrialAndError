using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour
{
    [SerializeField] private float _dayLength;
    [SerializeField] private float _dawnStart;
    [SerializeField] private float _nightStart;
    [SerializeField] private float _duskStart;

    [Header("Debug Info")]

    [SerializeField] private float _totalTime;
    [SerializeField] private float _currentDay;
    [SerializeField] private float _alpha;

    private SpriteRenderer[] _sprites;

    private void Start()
    {
        _sprites = GetComponentsInChildren<SpriteRenderer>(true);
    }

    private void Update()
    {
        _totalTime += Time.deltaTime;
        _currentDay = _totalTime % _dayLength;

        if ((_currentDay > 0) && (_currentDay < _duskStart))
        {
            //day
            _alpha = 0;
        }

        if ((_currentDay > _duskStart) && (_currentDay < _nightStart)) 
        {
            //dusk
          _alpha = Mathf.InverseLerp(_duskStart, _nightStart, _currentDay);
        }

        if ((_currentDay > _nightStart) && (_currentDay < _dawnStart)) 
        {
            //night
            _alpha = 1;
        }

        if ((_currentDay > _dawnStart) && (_currentDay < _dayLength))
        {
            //dawn
            _alpha = Mathf.InverseLerp(_dayLength, _dawnStart, _currentDay);
        }

        foreach (SpriteRenderer sprite in _sprites)
        {
            sprite.color = new Color(1f,1f, 1f, _alpha);
        }
    }
}
