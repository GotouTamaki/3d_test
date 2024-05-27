using System.Collections.Generic;
using UnityEngine;

public class ListWrapper<T>
{
    /// <summary>
    /// T型のリスト
    /// </summary>
    [SerializeField]
    private List<T> _list = new List<T>();

    /// <summary>
    /// T型のリスト
    /// </summary>
    public List<T> List => _list;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    public ListWrapper() { }

    /// <summary>
    /// リストの長さ
    /// </summary>
    public int Count => _list.Count;

    /// <summary>
    /// リストの要素を取得
    /// </summary>
    public T this[int index]
    {
        get => _list[index];
        set => _list[index] = value;
    }

    /// <summary>
    /// リストに要素を追加
    /// </summary>
    public void Add(T item) => _list.Add(item);

    /// <summary>
    /// リストから要素を削除
    /// </summary>
    public void RemoveAt(int index) => _list.RemoveAt(index);

    /// <summary>
    /// リストをクリア
    /// </summary>
    public void Clear() => _list.Clear();
    
    /// <summary>
    /// 暗示的なListWrapperからListへの変換
    /// </summary>
    public static implicit operator List<T>(ListWrapper<T> wrapper) => wrapper._list;

    /// <summary>
    /// 暗示的なListからListWrapperへの変換
    /// </summary>
    public static implicit operator ListWrapper<T>(List<T> list) => new ListWrapper<T> { _list = list };
}
