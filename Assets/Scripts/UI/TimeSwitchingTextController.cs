using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �e�L�X�g�̕���������s��
/// </summary>
public class TimeSwitchingTextController : MonoBehaviour
{
    [SerializeField, Header("�V�i���I���i�[����")] string[] _scenarios;
    [SerializeField, Header("�\��������TextUI")] Text _uiText;
    [SerializeField, Range(0.001f, 0.3f), Header("1�����̕\���ɂ����鎞��")] float _intervalForCharacterDisplay = 0.05f;

    string _currentText = string.Empty;      // ���݂̕�����
    float _timeUntilDisplay = 0;             // �\���ɂ����鎞��
    float _timeElapsed = 1;                  // ������̕\�����J�n��������
    int _currentLine = 0;                    // ���݂̍s�ԍ�
    int _lastUpdateCharacter = -1;           // �\�����̕�����

    // �����̕\�����������Ă��邩�ǂ���
    public bool IsCompleteDisplayText => Time.time > _timeElapsed + _timeUntilDisplay;

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
            if (_currentLine < _scenarios.Length && Input.GetMouseButtonDown(0))
            {
                SetNextLine();
            }
        }
        else
        {
            // �������ĂȂ��Ȃ當�������ׂĕ\������
            if (Input.GetMouseButtonDown(0))
            {
                _timeUntilDisplay = 0;
            }
        }

        // �N���b�N����o�߂������Ԃ��z��\�����Ԃ̉�%���m�F���A�\�����������o��
        int displayCharacterCount = (int)(Mathf.Clamp01((Time.time - _timeElapsed) / _timeUntilDisplay) * _currentText.Length);

        // �\�����������O��̕\���������ƈقȂ�Ȃ�e�L�X�g���X�V����
        if (displayCharacterCount != _lastUpdateCharacter)
        {
            _uiText.text = _currentText.Substring(0, displayCharacterCount);
            _lastUpdateCharacter = displayCharacterCount;
        }
    }

    /// <summary>
    /// �e�L�X�g���X�V����
    /// </summary>
    void SetNextLine()
    {
        _currentText = _scenarios[_currentLine];
        // �z��\�����Ԃƌ��݂̎������L���b�V��
        _timeUntilDisplay = _currentText.Length * _intervalForCharacterDisplay;
        _timeElapsed = Time.time;
        _currentLine++;
        // �����J�E���g��������
        _lastUpdateCharacter = -1;
    }
}