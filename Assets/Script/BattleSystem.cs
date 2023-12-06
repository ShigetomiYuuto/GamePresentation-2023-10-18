using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    [SerializeField] float _attackDistance;
    [SerializeField] EnemyRockOn _enemySelector;

    public List<GameObject> _attackTargets = new List<GameObject>();

    //�_���[�W:��{�_���[�W*��Z�{���v�f*(1+���Z�{���v�f)
    //�^�_���[�W	(����З�+��)*�A�[�c�З�

    private void OnEnable()
    {
        _enemySelector.UpDateEnemySelect += CheckDistance;
    }
    private void OnDisable()
    {
        _enemySelector.UpDateEnemySelect -= CheckDistance;
    }
    void CheckDistance()
    {
        _attackTargets = _enemySelector.GetSelectEnemys().Where(e => Vector3.Distance(transform.position,e.transform.position) < _attackDistance)
            .OrderBy(e => Vector3.Distance(transform.position, e.transform.position)).ToList();
    }








    /*
     *         foreach (var target in _targets)
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
    */
}
