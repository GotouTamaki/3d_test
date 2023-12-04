using DG.Tweening;
using UnityEngine;

public class EnemyAITest : MonoBehaviour
{
    /// <summary>�ő�HP</summary>
    [SerializeField] int _maxHp = 5;
    /// <summary>�g�p����A�j���[�^�[</summary>
    [SerializeField] Animator _animator;
    /// <summary>�ړ��ō����x(m/s)</summary>
    [SerializeField] float _maxSpeed;
    /// <summary>�U������</summary>
    [SerializeField] float _attackRange;
    /// <summary>�U������̃R���C�_�[</summary>
    [SerializeField] Collider _attacker;
    /// <summary>��炢����̃R���C�_�[</summary>
    [SerializeField] Collider _hitCollider;
    /// <summary> ���S���ɍĐ�����G�t�F�N�g </summary>
    [SerializeField] private ParticleSystem _deadEffect;
    /// <summary>����HP</summary>
    int _hp;
    /// <summary>�U�������t���O</summary>
    bool _attackReadyFlag;
    /// <summary>�U�����t���O</summary>
    bool _attackFlag;
    /// <summary>�_���[�W���t���O</summary>
    bool _damageFlag;

    /// <summary>���S���Ă��邩�ۂ�</summary>
    public bool IsDead => _hp <= 0;

    void Awake()
    {
        _animator.SetBool("IsMove", true);
        _hp = _maxHp;
    }

    /// <summary>�X�V����</summary>
    void Update()
    {
        //var player = GameManager.Instance.Player;
        if (_attackReadyFlag || _attackFlag || _damageFlag || _hp <= 0 /*|| player.IsDead*/)
        {
            // �U���������A�U�����A�_���[�W���A���S���A�܂��̓v���C���[���S���͉������Ȃ�
            return;
        }

        // �v���C���[�̕���������
        //var playerPos = player.transform.position;
        //transform.LookAt(playerPos);

        // �v���C���[���U���͈͂ɂ�����U�������s
        var currentPos = transform.position;
        //var distance = Vector3.Distance(currentPos, playerPos);
        //if (distance <= _attackRange)
        //{
        //    //AttackReady();
        //    // �U�����͈ړ����������������𔲂���
        //    return;
        //}

        // �v���C���[�Ɍ������Ĉړ�
        var maxDistanceDelta = _maxSpeed * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(currentPos, playerPos, maxDistanceDelta);
    }
}