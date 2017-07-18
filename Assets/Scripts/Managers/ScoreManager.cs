using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    int _score = 0;

    Text _text;

    void Awake ()
    {
        _text = GetComponent <Text> ();
    }

    public void AddScore(int amount)
    {
        _score += amount;
        _text.text = "Score: " + _score;
    }
}
