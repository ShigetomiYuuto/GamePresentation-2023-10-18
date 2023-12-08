using UnityEngine;

public class PlayerBattle : MonoBehaviour
{
    [SerializeField] float _pPower = 0f;
    [SerializeField] float _pWeapon = 0f;
    [SerializeField] float _pHP;
    public float _playerPower = 0;
    public float _playerWeapon = 0;
    public float _playerHP = 0;
    [SerializeField] int _eIndex = default;
    //ダメージ:基本ダメージ*乗算倍率要素*(1+加算倍率要素)
    //与ダメージ	(武器威力+力)*アーツ威力

    void Start()
    {

        _playerPower = _pPower;
        _playerWeapon = _pWeapon;
        _playerHP = _pHP;
    }

    void Update()
    {
        if (EnemyRockOn._active)
        {
            _eIndex = EnemyRockOn._index;
            BattleSelector._enemy = false;
            EnemyRockOn._active = false;
            Debug.Log("PlayerBattle" + _eIndex);
        }
    }
}
