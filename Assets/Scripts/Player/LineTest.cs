using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class LineTest : MonoBehaviour
{
    [SerializeField] Color _lineColor = Color.white;
    [SerializeField] Transform _startTransform;
    [SerializeField] Transform _endTransform;
    [SerializeField, Range(0, 2)] float _startWidth = 1;
    [SerializeField, Range(0, 2)] float _endWidth = 1;

    LineRenderer _line = null;

    private void Start()
    {
        _line = GetComponent<LineRenderer>();
        //_line.material = new Material(Shader.Find("Sprites/Default"));
        _line.startWidth = _startWidth;
        _line.endWidth = _endWidth;
        _line.positionCount = 2;
        _line.material.color = _lineColor;
        _line.startColor = _lineColor;
        _line.endColor = _lineColor;
    }

    private void Update()
    {
        _line.startWidth = _startWidth;
        _line.endWidth = _endWidth;
        // LineRenderer�̎n�_�A�I�_�̐ݒ�
        _line.SetPosition(0, _startTransform.position);
        _line.SetPosition(1, _endTransform.position);
    }
}