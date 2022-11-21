using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class DayTimeController : MonoBehaviour
{
    private float _time;
    [SerializeField] private const float _daySeconds = 86400f;
    [SerializeField] private Color _night;
    [SerializeField] private Color _day;
    [SerializeField] private AnimationCurve _curve;
    [SerializeField] private Text _text;
    [SerializeField] private float _timeScale;
    [SerializeField] private Light2D _light;
    private int _days;

    private float _hours
    {
        get{return _time / 3600f; } 
        set{}
    }
    private float _minutes
    {
        get{return _time / 60f; } 
        set{}
    }

    private void Update()
    {
        _time += Time.deltaTime * _timeScale;
        _text.text = _hours.ToString();
        float v = _curve.Evaluate(_hours);
        Color c = Color.Lerp(_day, _night, v);
        _light.color = c;
        if (_time > _daySeconds) NextDay();
    }

    private void NextDay()
    {
        _time = 0;
        _days += 1;
    }
}

