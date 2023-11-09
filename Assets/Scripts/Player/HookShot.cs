using System.Collections.Generic;
using UnityEngine;

public class HookShot : MonoBehaviour
{
    // <summary>�}�Y���̈ʒu</summary>
    [SerializeField] Transform _muzzle = default;
    /// <summary>�^�[�Q�b�g�̈ʒu</summary>
    [SerializeField] GameObject _target = default; /// <summary>�e�̎��</summary>
    [SerializeField] WireTest _bullet = null;

    // �e�평����
    float _interval = 1f;
    float _timer = 0;
    Vector2 _r = Vector2.zero;

    void Start()
    {
        _timer = _interval;
    }

    void Update()
    {
        _timer += Time.deltaTime;

        // ��C�̊p�x�ύX
        this.transform.up = _target.transform.position - this.transform.position;

        // �e�̔���
        if (_timer > _interval)
        {
            if (Input.GetButtonDown("Fire1"))// ���������Ƃ𔻒�
            {
                WireTest bullet = Instantiate(_bullet, _muzzle.position, this.transform.rotation);
                Debug.Log($"���C���ˁA�C���^�[�o��{bullet.GetComponent<WireTest>().Interval}");
                _interval = bullet.Interval;
                _timer = 0f;
            }
        }
    }
}
