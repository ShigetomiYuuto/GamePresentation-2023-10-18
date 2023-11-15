using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemySelector : MonoBehaviour
{
    [SerializeField] List<GameObject> _selectEnemy = new List<GameObject>();
    [SerializeField] GameObject _enemyPoint;
    PlayerInput _pInput;

    int _enemyIndex = default;

    public event Action UpDateEnemySelect;

    void Start()
    {
        InvokeRepeating("RepitingSort", 0.5f, 1f);
    }
    void RepitingSort()
    {
        if (_selectEnemy != null)
        {
            // Debug.Log(_selectEnemy);
            _selectEnemy = _selectEnemy.OrderBy(e => Vector3.Distance(transform.position, e.transform.position)).ToList();
            UpDateEnemySelect?.Invoke();
        }
    }

    public void OnRightSelect(InputAction.CallbackContext context)
    {
        if (context.started && _selectEnemy.Count != 0)
        {
            if (_enemyIndex < _selectEnemy.Count - 1)
            {
                _enemyIndex++;
                _enemyPoint.transform.position = _selectEnemy[_enemyIndex].transform.position;
                Debug.Log(_enemyIndex + "if");
            }
            else
            {
                _enemyIndex = 0;
                _enemyPoint.transform.position = _selectEnemy[_enemyIndex].transform.position;
                Debug.Log(_enemyIndex + "else");
            }
        }

    }
    public void OnLeftSelect(InputAction.CallbackContext context)
    {
        if (context.started && _selectEnemy.Count != 0)
        {
            if (_enemyIndex < _selectEnemy.Count - 1)
            {
                _enemyIndex = _selectEnemy.Count - 1;
                _enemyPoint.transform.position = _selectEnemy[_enemyIndex].transform.position;
                Debug.Log(_enemyIndex + "else");
            }
            else
            {
                _enemyIndex--;
                _enemyPoint.transform.position = _selectEnemy[_enemyIndex].transform.position;
                Debug.Log(_enemyIndex + "if");
            }
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
    /* - ägí£ÉÅÉ\ÉbÉh - */
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