using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// テキストの文字送りを行う
/// </summary>
public class TextController : MonoBehaviour
{
    [SerializeField, Header("シナリオを格納する")] string[] scenarios;
    [SerializeField, Header("表示させるTextUI")] Text uiText;
    [SerializeField, Range(0.001f, 0.3f), Header("1文字の表示にかかる時間")] float intervalForCharacterDisplay = 0.05f;

    string currentText = string.Empty;      // 現在の文字列
    float timeUntilDisplay = 0;             // 表示にかかる時間
    float timeElapsed = 1;                  // 文字列の表示を開始した時間
    int currentLine = 0;                    // 現在の行番号
    int lastUpdateCharacter = -1;           // 表示中の文字数

    // 文字の表示が完了しているかどうか
    public bool IsCompleteDisplayText => Time.time > timeElapsed + timeUntilDisplay;

    void Start()
    {
        SetNextLine();
    }

    void Update()
    {
        // TODO:時間経過で次のテキストに切り替わるようにする
        // 文字の表示が完了してるならクリック時に次の行を表示する
        if (IsCompleteDisplayText)
        {
            // 現在の行番号がラストまで行ってない状態でクリックすると、テキストを更新する
            if (currentLine < scenarios.Length && Input.GetMouseButtonDown(0))
            {
                SetNextLine();
            }
        }
        else
        {
            // 完了してないなら文字をすべて表示する
            if (Input.GetMouseButtonDown(0))
            {
                timeUntilDisplay = 0;
            }
        }

        // クリックから経過した時間が想定表示時間の何%か確認し、表示文字数を出す
        int displayCharacterCount = (int)(Mathf.Clamp01((Time.time - timeElapsed) / timeUntilDisplay) * currentText.Length);

        // 表示文字数が前回の表示文字数と異なるならテキストを更新する
        if (displayCharacterCount != lastUpdateCharacter)
        {
            uiText.text = currentText.Substring(0, displayCharacterCount);
            lastUpdateCharacter = displayCharacterCount;
        }
    }

    /// <summary>
    /// テキストを更新する
    /// </summary>
    void SetNextLine()
    {
        currentText = scenarios[currentLine];
        // 想定表示時間と現在の時刻をキャッシュ
        timeUntilDisplay = currentText.Length * intervalForCharacterDisplay;
        timeElapsed = Time.time;
        currentLine++;
        // 文字カウントを初期化
        lastUpdateCharacter = -1;
    }
}