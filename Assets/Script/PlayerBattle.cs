using UnityEngine;

public class PlayerBattle : MonoBehaviour
{
    [SerializeField] float _pPower = 0f;
    [SerializeField] float _pWeapon = 0f;
    [SerializeField] float _pHP;
    public float _playerPower = 0;
    public float _playerWeapon = 0;
    public float _playerHP = 0;
    //�_���[�W:��{�_���[�W*��Z�{���v�f*(1+���Z�{���v�f)
    //�^�_���[�W	(����З�+��)*�A�[�c�З�

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
