using System.Collections.Generic;
using UnityEngine;

public class WireTest : MonoBehaviour
{
    [SerializeField] float _shootSpeed = 1.0f;
    [SerializeField] float _springPower = 5f;
    [SerializeField] Color _lineColor = Color.white;
    /// <summary>�t�b�N�V���b�g�̃C���^�[�o��</summary>
    [SerializeField] float _interval = 1f;

    GameObject _player = null;
    Rigidbody _hookRb = null;
    Rigidbody _playerRb = null;
    LineRenderer _line = null;
    Vector3 _initialPosition = Vector3.zero;

    /// <summary>�t�b�N�V���b�g�̃C���^�[�o���̃C���^�[�o�����擾�ł��܂�</summary>
    public float Interval { get => _interval; set => _interval = value; }

    private void Start()
    {
        _hookRb = GetComponent<Rigidbody>();
        _hookRb.velocity = Vector3.forward * _shootSpeed;
        // �v���C���[���擾
        _player = GameObject.FindWithTag("Player");
        _hookRb = _player.GetComponent<Rigidbody>();
        // LineRenderer�̐ݒ�
        _line = GetComponent<LineRenderer>();
        _line.material = new Material(Shader.Find("Sprites/Default"));
        _line.startWidth = 0.1f;
        _line.endWidth = 0.1f;
        _line.positionCount = 2;
        _line.material.color = _lineColor;
        _line.startColor = _lineColor;
        _line.endColor = _lineColor;
    }

    private void Update()
    {
        // LineRenderer�̎n�_�A�I�_�̐ݒ�
        _line.SetPosition(0, this.transform.position);
        _line.SetPosition(1, _player.transform.position);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �t�b�N���Œ肷��
        _hookRb.Sleep();
        // �v���C���[�ƃt�b�N�̋����𑪒�
        Vector2 _diff = (this.transform.position - _player.transform.position).normalized;
        // �v���C���[�ɗ͂�������
        _playerRb.AddForce(_diff * _springPower, ForceMode.Impulse);
        _playerRb.useGravity = false;
    }
}
