using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveRecorder : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    public List<Record> _playerRecords = new List<Record>();
    private Record _record = new Record();

    /// <summary>フレームのカウントをする</summary>
    private int _flameCount = 0;

    private float _currentTime = 0;

    public List<Record> PlayerRecords => _playerRecords;

    void FixedUpdate()
    {
        // 2フレームに1回保存する
        if (_flameCount % 2 == 0)
        {
            var record = new Record(_player.transform.position, _player.transform.rotation, _currentTime,
                Input.GetButtonDown("Fire1"));
            _playerRecords.Add(record);
        }

        // カウントアップ
        _flameCount++;
        _currentTime += Time.fixedDeltaTime;
    }
}

[System.Serializable]
public struct Record
{
    public Vector3 PlayerPosition;
    public Quaternion PlayerRotation;
    public float RecordTime;
    public bool RecordInput;

    public Record(Vector3 playerPosition, Quaternion playerRotation, float recordTime, bool recordInput)
    {
        PlayerPosition = playerPosition;
        PlayerRotation = playerRotation;
        RecordTime = recordTime;
        RecordInput = recordInput;
    }
}