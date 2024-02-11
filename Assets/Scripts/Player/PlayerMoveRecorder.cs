using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveRecorder : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    public Queue<Record> _playerRecords = new Queue<Record>();
    private Record _record = new Record();

    /// <summary>フレームのカウントをする</summary>
    private int _flameCount = 0;

    public Queue<Record> PlayerRecords => _playerRecords;

    void FixedUpdate()
    {
        // 2フレームに1回保存する
        if (_flameCount % 2 == 0)
        {
            _record.playerPosition = _player.transform.position;
            _record.playerRotation = _player.transform.rotation;
            _record.time = Time.time;
            _record.input = false;
            _playerRecords.Enqueue(_record);
            
            _flameCount = 0;
        }

        _flameCount++; // カウントアップ
    }
}

[System.Serializable]
public struct Record
{
    public Vector3 playerPosition;
    public Quaternion playerRotation;
    public float time;
    public bool input;
}