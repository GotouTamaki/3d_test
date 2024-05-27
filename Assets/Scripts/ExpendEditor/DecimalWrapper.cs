using UnityEngine;

/// <summary>
/// decimal型用のラッパークラス
/// 本来のdecimal型とほぼ同じように使えます
/// </summary>
[System.Serializable]
public class DecimalWrapper : ISerializationCallbackReceiver
{
    //　参考URL : https://discussions.unity.com/t/how-to-make-decimal-variables-visible-in-inspector/119343

    /// <summary>_valueを保存する配列</summary>
    [SerializeField] private int[] _data;

    /// <summary>DecimalWrapperの値</summary>
    private decimal _value;

    /// <summary>DecimalWrapperの値</summary>
    public decimal Value
    {
        get => _value;
        set => this._value = value;
    }

    /// <summary>DecimalWrapperのコンストラクタ</summary>
    public DecimalWrapper(decimal value) => this._value = value;

    /// <summary>DecimalWrapperをstring型に変換します</summary>
    public override string ToString() => _value.ToString();

    /// <summary>DecimalWrapperをdecimalに暗示的に変換します</summary>
    public static implicit operator decimal(DecimalWrapper wrapper) => wrapper._value;

    /// <summary>decimalをDecimalWrapperに暗示的に変換します</summary>
    public static implicit operator DecimalWrapper(decimal value) => new DecimalWrapper(value);

    /// <summary>シリアライズ前のデータの処理</summary>
    public void OnBeforeSerialize() => _data = decimal.GetBits(_value);

    /// <summary>デシリアライズ後のデータの処理</summary>
    public void OnAfterDeserialize()
    {
        if (_data != null && _data.Length == 4)
        {
            _value = new decimal(_data);
        }
    }
}
