using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveRecordLoader : MonoBehaviour
{
    private PlayerMoveRecorder _playerMoveRecorder;
    private List<Record> _records;
    private Record _currentRecord;
    private int _currentIndex = 0;

    /// <summary>フレームのカウントをする</summary>
    private int _flameCount = 0;

    private void Start()
    {
        _records = GameObject.FindGameObjectWithTag("PlayerMoveRecorder").GetComponent<PlayerMoveRecorder>()
            .PlayerRecords;
        _currentRecord = _records[0];
        _currentIndex++;

        Debug.Log($"Record : {_currentRecord.PlayerRotation}\nCurrent : {transform.rotation}");
    }

    void FixedUpdate()
    {
        if (_records == null)
        {
#if UNITY_EDITOR
            Debug.LogWarning("プレイヤーの記録がありません");
#endif
            return;
        }

        if (_flameCount % 2 == 0)
        {
            if (transform.position != _currentRecord.PlayerPosition)
            {
                //ToDo : 正常に動作しないので治す
                transform.rotation = _currentRecord.PlayerRotation;
                // 座標を更新
                transform.position = _currentRecord.PlayerPosition;
                Debug.Log($"Record : {_currentRecord.PlayerRotation}\nCurrent : {transform.rotation}");
            }
        }
        else
        {
            Debug.Log("Load");
            _currentRecord = _records[_currentIndex];
            _currentIndex++;
            // 奇数フレームの補間を行う
            var speed = Vector3.Lerp(transform.position, _currentRecord.PlayerPosition, 0.5f);
            Debug.Log($"Record : {_currentRecord.PlayerRotation}\nCurrent : {transform.rotation}");

        }

        _flameCount++;
    }
}