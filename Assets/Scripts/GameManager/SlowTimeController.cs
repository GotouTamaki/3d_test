using System;
using System.Linq;
using UnityEngine;

public class ZoneTimeController : MonoBehaviour, IZoneTime
{
    public static ZoneTimeController Instance;

    [SerializeField, Header("時間制限")] private float zoneTimeLimit = 10f;

    private IZoneTime[] _zoneTimes;
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

    /// <summary>ZoneTimeを開始する</summary>
    private void OnStartZoneTime()
    {
        // IZoneTimeを継承しているオブジェクトを非アクティブ含めて検索する
        _zoneTimes = FindObjectsOfType<MonoBehaviour>(true).OfType<IZoneTime>().ToArray();

        foreach (var zoneTime in _zoneTimes)
        {
            zoneTime.OnEnterZoneTime();
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
                foreach (var zoneTime in _zoneTimes)
                {
                    zoneTime.OnExitZoneTime();
                }
            }

            return;
        }

        if (_timer >= 0)
        {
            // 時間内であれば
            foreach (var zoneTime in _zoneTimes)
            {
                zoneTime.OnUpdateZoneTime();
            }
        }
        else if (!_exitFlag)
        {
            // 時間外かつ_exitFlagがまだfalseであれば
            foreach (var zoneTime in _zoneTimes)
            {
                zoneTime.OnExitZoneTime();
            }

            SetFinishFlag(true);
        }

        _timer -= Time.fixedDeltaTime;
    }

    private void OnDisable()
    {
        throw new NotImplementedException();
    }

    public void OnEnterZoneTime()
    {
        _timer = zoneTimeLimit;
        _exitFlag = false;
    }

    public void OnUpdateZoneTime()
    {
        throw new NotImplementedException();
    }

    public void OnExitZoneTime()
    {
        _exitFlag = true;
    }
}