using System.Collections.Generic;
using UnityEngine;

public class HookShot : MonoBehaviour
{
    // <summary>マズルの位置</summary>
    [SerializeField] Transform _muzzle = default;
    /// <summary>ターゲットの位置</summary>
    [SerializeField] GameObject _target = default; /// <summary>弾の種類</summary>
    [SerializeField] WireTest _bullet = null;

    // 各種初期化
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

        // 大砲の角度変更
        this.transform.up = _target.transform.position - this.transform.position;

        // 弾の発射
        if (_timer > _interval)
        {
            if (Input.GetButtonDown("Fire1"))// 押したことを判定
            {
                WireTest bullet = Instantiate(_bullet, _muzzle.position, this.transform.rotation);
                Debug.Log($"左砲発射、インターバル{bullet.GetComponent<WireTest>().Interval}");
                _interval = bullet.Interval;
                _timer = 0f;
            }
        }
    }
}
