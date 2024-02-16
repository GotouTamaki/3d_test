using System.Collections.Generic;
using UnityEngine;

public class PlayerInputRecord : MonoBehaviour
{
    private void Update()
    {
        // プレイヤーのキー入力を保存(非推奨)

        // 特定のタイミングでのプレイヤーの情報を保存
        // 簡単、安全、問題が問題にならない
        // (間引く前提ならFixedUpdateでも可)
        // Vector3,Rotation,Input,CameraのTransform
        // 30回/s位
        // 1秒間720, １分間43200, 10分間432000バイト
        // 一周432kbyte
        // アラート機能が欲しい

        // 入力の差分から保存する
    }
}