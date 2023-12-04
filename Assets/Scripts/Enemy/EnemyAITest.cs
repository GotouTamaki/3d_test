using DG.Tweening;
using UnityEngine;

public class EnemyAITest : MonoBehaviour
{
    /// <summary>最大HP</summary>
    [SerializeField] int _maxHp = 5;
    /// <summary>使用するアニメーター</summary>
    [SerializeField] Animator _animator;
    /// <summary>移動最高速度(m/s)</summary>
    [SerializeField] float _maxSpeed;
    /// <summary>攻撃距離</summary>
    [SerializeField] float _attackRange;
    /// <summary>攻撃判定のコライダー</summary>
    [SerializeField] Collider _attacker;
    /// <summary>喰らい判定のコライダー</summary>
    [SerializeField] Collider _hitCollider;
    /// <summary> 死亡時に再生するエフェクト </summary>
    [SerializeField] private ParticleSystem _deadEffect;
    /// <summary>現在HP</summary>
    int _hp;
    /// <summary>攻撃準備フラグ</summary>
    bool _attackReadyFlag;
    /// <summary>攻撃中フラグ</summary>
    bool _attackFlag;
    /// <summary>ダメージ中フラグ</summary>
    bool _damageFlag;

    /// <summary>死亡しているか否か</summary>
    public bool IsDead => _hp <= 0;

    void Awake()
    {
        _animator.SetBool("IsMove", true);
        _hp = _maxHp;
    }

    /// <summary>更新処理</summary>
    void Update()
    {
        //var player = GameManager.Instance.Player;
        if (_attackReadyFlag || _attackFlag || _damageFlag || _hp <= 0 /*|| player.IsDead*/)
        {
            // 攻撃準備中、攻撃中、ダメージ中、死亡時、またはプレイヤー死亡時は何もしない
            return;
        }

        // プレイヤーの方向を向く
        //var playerPos = player.transform.position;
        //transform.LookAt(playerPos);

        // プレイヤーが攻撃範囲にいたら攻撃を実行
        var currentPos = transform.position;
        //var distance = Vector3.Distance(currentPos, playerPos);
        //if (distance <= _attackRange)
        //{
        //    //AttackReady();
        //    // 攻撃時は移動処理をせず処理を抜ける
        //    return;
        //}

        // プレイヤーに向かって移動
        var maxDistanceDelta = _maxSpeed * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(currentPos, playerPos, maxDistanceDelta);
    }
}