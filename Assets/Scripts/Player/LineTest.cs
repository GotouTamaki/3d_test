using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class LineTest : MonoBehaviour
{
    [SerializeField] Color _lineColor = Color.white;
    [SerializeField] Transform _startTransform;
    [SerializeField] Transform _endTransform;
    LineRenderer _line = null;

    private void Start()
    {
        _line = GetComponent<LineRenderer>();
        //_line.material = new Material(Shader.Find("Sprites/Default"));
        _line.startWidth = 0.1f;
        _line.endWidth = 0.1f;
        _line.positionCount = 2;
        _line.material.color = _lineColor;
        _line.startColor = _lineColor;
        _line.endColor = _lineColor;
    }

    private void Update()
    {
        // LineRendererの始点、終点の設定
        _line.SetPosition(0, _endTransform.position);
        _line.SetPosition(1, _endTransform.position);
    }
}
