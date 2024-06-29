using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterView : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private Text _text;

    private void OnEnable()
    {
        _counter.Changed += Display;
    }

    private void OnDisable()
    {
        _counter.Changed -= Display;
    }

    private void Display(float value)
    {
        _text.text = value.ToString();
    }
}
