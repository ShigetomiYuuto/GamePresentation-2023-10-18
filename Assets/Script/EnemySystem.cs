using UnityEngine;

public class EnemySystem : MonoBehaviour
{
    [SerializeField] float _ePower = 0;
    [SerializeField] float _eHp = 0;
    public float _enemyPower = 0;
    public float _enemyHp = 0;

    void Start()
    {
        _enemyPower = _ePower;
        _enemyHp = _eHp;
    }

    void Update()
    {
        
    }
}
