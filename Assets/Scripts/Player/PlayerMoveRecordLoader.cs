using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveRecordLoader : MonoBehaviour
{
    private PlayerMoveRecorder _playerMoveRecorder;
    private Queue<Record> _records;
    private Record _currentRecord;

    private void OnEnable()
    {
        _records = GameObject.FindGameObjectWithTag("PlayerMoveRecorder").GetComponent<PlayerMoveRecorder>().PlayerRecords;
        _currentRecord = _records.Dequeue();
        StartCoroutine(LoadPlayerMoveRecord());
    }

    IEnumerator LoadPlayerMoveRecord()
    {
        while (_records != null)
        {
            while (transform.position != _currentRecord.playerPosition)
            {
                //ToDo : 正常に動作しないので治す
                transform.rotation = _currentRecord.playerRotation;
                //var speedRate = _currentRecord.palyerPosition.magnitude;
                var speed = Mathf.Lerp(0f, Vector3.Distance(transform.position, _currentRecord.playerPosition), Time.deltaTime);
                // 今回のフレームでの移動量を計算
                var moveVector = new Vector3(_currentRecord.playerPosition.x, 0f, _currentRecord.playerPosition.y) * speed * Time.deltaTime;
                // 移動先の座標を計算
                var position = transform.position + moveVector;
                // 座標を更新
                transform.position = position;
                
                Debug.Log($"Record : {_currentRecord.playerRotation}\nCurrent : {transform.rotation}");
                yield return null;
            }
            Debug.Log("Load");
            _currentRecord = _records.Dequeue();
            yield return null;
        }
    }
}