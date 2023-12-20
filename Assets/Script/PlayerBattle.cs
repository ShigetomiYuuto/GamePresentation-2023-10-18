using UnityEngine;

public class PlayerBattle : MonoBehaviour
{
    [SerializeField] float _pPower = 0f;
    [SerializeField] float _pWeapon = 0f;
    [SerializeField] float _pHP;
    public static float  _playerPower = 0;
    public static float _playerWeapon = 0;
    public static float _playerHP = 0;

    void Start()
    {
        _playerPower = _pPower;
        _playerWeapon = _pWeapon;
        _playerHP = _pHP;
    }

    void Update()
    {

    }
}
