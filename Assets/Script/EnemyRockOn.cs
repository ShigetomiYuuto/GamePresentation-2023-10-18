using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyRockOn : MonoBehaviour
{
    [SerializeField] List<GameObject> _selectEnemy = new List<GameObject>();
    [SerializeField] GameObject _enemyPoint;

    int _enemyIndex = default;
    public static int _index = default;
    public static　bool _active = false;

    public event Action UpDateEnemySelect;

    void Start()
    {
        InvokeRepeating("RepitingSort", 0.5f, 1f);
    }
    void RepitingSort()
    {
        if (_selectEnemy != null)
        {
            _selectEnemy = _selectEnemy.OrderBy(e => Vector3.Distance(transform.position, e.transform.position)).ToList();
            UpDateEnemySelect?.Invoke();
        }
    }

    public void OnRockOn(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (_selectEnemy.Count != 0)
            {
                _enemyIndex = context.ReadValue<float>() > 0 ? _enemyIndex += 1 : _enemyIndex -= 1;

                if (_enemyIndex > _selectEnemy.Count - 1)
                {
                    _enemyIndex = 0;
                }

                else if (_enemyIndex < 0)
                {
                    _enemyIndex = _selectEnemy.Count - 1;
                }
                _enemyPoint.transform.position = new Vector3(_selectEnemy[_enemyIndex].transform.position.x,
                    _selectEnemy[_enemyIndex].transform.position.y + 3, _selectEnemy[_enemyIndex].transform.position.z);
            }
            _index = _enemyIndex;
        }
    }

    private void Update()
    {
        if (_selectEnemy.Count != 0 && BattleSelector._enemy)
        {
            _active = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
            _selectEnemy.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
            _selectEnemy.Remove(other.gameObject);
    }

    public List<GameObject> GetSelectEnemys()
    {
        return _selectEnemy;
    }
}























public static class ExtensionMethods
{
    /* - 拡張メソッド - */
    public static List<GameObject> SortGameobjectByDistance(this List<GameObject> go, Transform origin)
    {
        for (int i = 0; i < go.Count; i++)
        {
            var dis = (go[i].transform.position - origin.position).sqrMagnitude;
            var dis1 = (go[(i + 1 < go.Count) ? i + 1 : 0].transform.position - origin.position).sqrMagnitude;
            if (dis < dis1)
            {
                var tmp = go[i];
                go[i] = go[(i + 1 < go.Count) ? i + 1 : 0];
                go[(i + 1 < go.Count) ? i + 1 : 0] = tmp;
            }
        }
        return go;
    }

}