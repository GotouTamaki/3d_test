/// <summary>集中状態の処理を行うためのインターフェース</summary>
public interface ISlowTime
{
    /// <summary>集中状態に入った時の処理</summary>
    public void OnEnterSlowTime();

    /// <summary>集中状態中の処理</summary>
    public void OnUpdateSlowTime();

    /// <summary>集中状態を終了するときの処理</summary>
    public void OnExitSlowTime();
}