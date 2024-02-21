using System.Collections.Generic;
using UnityEngine;

/// <summary>集中状態の処理を行うためのインターフェース</summary>
public interface IZoneTime
{
    /// <summary>集中状態に入った時の処理</summary>
    public void OnEnterZoneTime();

    /// <summary>集中状態中の処理</summary>
    public void OnUpdateZoneTime();

    /// <summary>集中状態を終了するときの処理</summary>
    public void OnExitZoneTime();
}