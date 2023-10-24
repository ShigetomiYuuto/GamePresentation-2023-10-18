using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemySelector : MonoBehaviour
{
    [SerializeField] List<GameObject> _selectEnemy = new List<GameObject>();
    [SerializeField] BattleSystem _battleSys;
    [SerializeField] GameObject _point;
    int _enemyIndex = default;
    void Start()
    {

    }
    void Update()
    {
        _selectEnemy = 
            (_battleSys != null) ? 
            _battleSys._targets.SortGameobjectByDistance(GameObject.FindGameObjectWithTag("Player").transform)
            : throw new System.Exception("Attach The Battle System Component");
    }

    public void OnSelect(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Instantiate(_point, _selectEnemy[_enemyIndex].transform.position, Quaternion.identity);
            _enemyIndex++;
            Debug.Log(_enemyIndex);
        }
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