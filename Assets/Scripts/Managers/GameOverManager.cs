using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth PlayerHealth;
    public float RestartDelayInSecond = 5;

    Animator _anim;
    float _restartTimeInSecond;

    void Awake()
    {
        _anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (PlayerHealth.CurrentHealth <= 0)
        {
            _anim.SetTrigger("GameOver");
            _restartTimeInSecond += Time.deltaTime;

            if (_restartTimeInSecond >= RestartDelayInSecond)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
            }
        }
    }
}
