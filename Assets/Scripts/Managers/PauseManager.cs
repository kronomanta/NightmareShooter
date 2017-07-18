using UnityEngine;
using UnityEngine.Audio;

public class PauseManager : MonoBehaviour
{

    public AudioMixerSnapshot Paused;
    public AudioMixerSnapshot Unpaused;

    Canvas _canvas;

    void Start()
    {
        _canvas = GetComponent<Canvas>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            Pause();
        }
    }

    public void Pause()
    {
        _canvas.enabled = !_canvas.enabled;
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        Lowpass();
    }

    void Lowpass()
    {
        if (Time.timeScale == 0)
            Paused.TransitionTo(.01f);
        else
            Unpaused.TransitionTo(.01f);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
		Application.Quit();
#endif
    }
}
