using System;
using System.Linq;
using UnityEngine;

public class SlowTimeController : MonoBehaviour, ISlowTime
{
    public static SlowTimeController Instance;

    [SerializeField, Header("時間制限")] private float slowTimeLimit = 10f;

    private ISlowTime[] _slowTimes; // ISlowTimeを継承したオブジェクト
    private float _timer; // タイマー
    private bool _exitFlag; // 終了時フラグ
    private bool _finishFlag; // 強制終了フラグ

    public void SetFinishFlag(bool flag) => _finishFlag = flag;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    /// <summary>SlowTimeを開始する</summary>
    private void OnStartZoneTime()
    {
        // ISlowTimeを継承しているオブジェクトを非アクティブ含めて検索する
        _slowTimes = FindObjectsOfType<MonoBehaviour>(true).OfType<ISlowTime>().ToArray();

        foreach (var zoneTime in _slowTimes)
        {
            zoneTime.OnEnterSlowTime();
        }

        SetFinishFlag(false);
    }

    private void FixedUpdate()
    {
        // 強制終了時の処理
        if (_finishFlag)
        {
            // まだExit時の処理をしていなければ
            if (!_exitFlag)
            {
                foreach (var zoneTime in _slowTimes)
                {
                    zoneTime.OnExitSlowTime();
                }
            }

            return;
        }

        if (_timer >= 0)
        {
            // 時間内であれば
            foreach (var zoneTime in _slowTimes)
            {
                zoneTime.OnUpdateSlowTime();
            }
        }
        else if (!_exitFlag)
        {
            // 時間外かつ_exitFlagがまだfalseであれば
            foreach (var zoneTime in _slowTimes)
            {
                zoneTime.OnExitSlowTime();
            }

            SetFinishFlag(true);
        }

        _timer -= Time.fixedDeltaTime;
    }

    private void OnDisable()
    {
        throw new NotImplementedException();
    }

    public void OnEnterSlowTime()
    {
        _timer = slowTimeLimit;
        _exitFlag = false;
    }

    public void OnUpdateSlowTime()
    {
        throw new NotImplementedException();
    }

    public void OnExitSlowTime()
    {
        _exitFlag = true;
    }
}