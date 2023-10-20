using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    [SerializeField] GameObject _player;
    [SerializeField] float _attackDistance;

    public List<GameObject> _targets = new List<GameObject>();
    public List<GameObject> _attackTargets = new List<GameObject>();
    bool _isCanAttack;

    //�_���[�W:��{�_���[�W*��Z�{���v�f*(1+���Z�{���v�f)
    //�^�_���[�W	(����З�+��)*�A�[�c�З�

    void Start()
    {

    }

    void Update()
    {
        if (_targets.Count > 0)
        {
            ChackDistance();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
            _targets.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
            _targets.Remove(other.gameObject);
    }

    void ChackDistance()
    {
        foreach (var target in _targets)
        {
            if ((_player.transform.position - target.transform.position).sqrMagnitude < _attackDistance * _attackDistance && !_attackTargets.Contains(target))
            {
                _attackTargets.Add(target);
            }
            else if ((_player.transform.position - target.transform.position).sqrMagnitude > _attackDistance * _attackDistance && _attackTargets.Contains(target))
            {
                Debug.Log("���O������");
                _attackTargets.Remove(target);
            }
        }
    }
}
