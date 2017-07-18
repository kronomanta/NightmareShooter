using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Transform _player;
    PlayerHealth _playerHealth;
    EnemyHealth _enemyHealth;
    UnityEngine.AI.NavMeshAgent _nav;


    void Awake ()
    {
        _player = GameObject.FindGameObjectWithTag ("Player").transform;
        _playerHealth = _player.GetComponent<PlayerHealth>();
        _enemyHealth = GetComponent<EnemyHealth>();
        _nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
    }


    void Update ()
    {
        if (_enemyHealth.CurrentHealth > 0 && _playerHealth.CurrentHealth > 0)
            _nav.SetDestination(_player.position);
        else
            _nav.enabled = false;
    }
}
