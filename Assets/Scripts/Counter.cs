using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _startValue = 0f;
    [SerializeField] private float _increment = 1f;
    [SerializeField, Min(0f)] private float _delay = 0.5f;
    [SerializeField] private Clicker _clicker;

    private float _value;
    private bool _isStarted;
    private Coroutine _coroutine;

    public event UnityAction<float> Changed;

    private void Start()
    {
        _value = _startValue;
        _isStarted = false;
    }

    private void OnEnable()
    {
        _clicker.Clicked += StartOrStopCoroutine;
    }

    private void OnDisable()
    {
        _clicker.Clicked -= StartOrStopCoroutine;
    }

    private IEnumerator Count()
    {
        var wait = new WaitForSecondsRealtime(_delay);

        while (true)
        {
            _value += _increment;
            Changed?.Invoke(_value);

            yield return wait;
        }
    }

    private void StartOrStopCoroutine()
    {
        if (_isStarted)
        {
            StopCoroutine(_coroutine);
            _isStarted = false;
        }
        else
        {
            _coroutine = StartCoroutine(Count());
            _isStarted = true;
        }
    }
}
