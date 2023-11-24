using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �e�L�X�g�̕���������s��
/// </summary>
public class TextController : MonoBehaviour
{
    [SerializeField, Header("�V�i���I���i�[����")] string[] scenarios;
    [SerializeField, Header("�\��������TextUI")] Text uiText;
    [SerializeField, Range(0.001f, 0.3f), Header("1�����̕\���ɂ����鎞��")] float intervalForCharacterDisplay = 0.05f;

    string currentText = string.Empty;      // ���݂̕�����
    float timeUntilDisplay = 0;             // �\���ɂ����鎞��
    float timeElapsed = 1;                  // ������̕\�����J�n��������
    int currentLine = 0;                    // ���݂̍s�ԍ�
    int lastUpdateCharacter = -1;           // �\�����̕�����

    // �����̕\�����������Ă��邩�ǂ���
    public bool IsCompleteDisplayText => Time.time > timeElapsed + timeUntilDisplay;

    void Start()
    {
        SetNextLine();
    }

    void Update()
    {
        // TODO:���Ԍo�߂Ŏ��̃e�L�X�g�ɐ؂�ւ��悤�ɂ���
        // �����̕\�����������Ă�Ȃ�N���b�N���Ɏ��̍s��\������
        if (IsCompleteDisplayText)
        {
            // ���݂̍s�ԍ������X�g�܂ōs���ĂȂ���ԂŃN���b�N����ƁA�e�L�X�g���X�V����
            if (currentLine < scenarios.Length && Input.GetMouseButtonDown(0))
            {
                SetNextLine();
            }
        }
        else
        {
            // �������ĂȂ��Ȃ當�������ׂĕ\������
            if (Input.GetMouseButtonDown(0))
            {
                timeUntilDisplay = 0;
            }
        }

        // �N���b�N����o�߂������Ԃ��z��\�����Ԃ̉�%���m�F���A�\�����������o��
        int displayCharacterCount = (int)(Mathf.Clamp01((Time.time - timeElapsed) / timeUntilDisplay) * currentText.Length);

        // �\�����������O��̕\���������ƈقȂ�Ȃ�e�L�X�g���X�V����
        if (displayCharacterCount != lastUpdateCharacter)
        {
            uiText.text = currentText.Substring(0, displayCharacterCount);
            lastUpdateCharacter = displayCharacterCount;
        }
    }

    /// <summary>
    /// �e�L�X�g���X�V����
    /// </summary>
    void SetNextLine()
    {
        currentText = scenarios[currentLine];
        // �z��\�����Ԃƌ��݂̎������L���b�V��
        timeUntilDisplay = currentText.Length * intervalForCharacterDisplay;
        timeElapsed = Time.time;
        currentLine++;
        // �����J�E���g��������
        lastUpdateCharacter = -1;
    }
}