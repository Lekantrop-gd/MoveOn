using GameObjects;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _bestScore;
    [SerializeField] private Score _score;

    private readonly string _bestScoreSave = nameof(_bestScoreSave);

    private void Awake()
    {
        if (PlayerPrefs.HasKey(_bestScoreSave))
        {
            _bestScore.text = PlayerPrefs.GetInt(_bestScoreSave).ToString();
        }
        else
        {
            PlayerPrefs.SetInt(_bestScoreSave, 0);
            _bestScore.text = "0";
        }
    }

    private void OnEnable()
    {
        Hero.Died += FinishLevel;
    }

    private void OnDisable()
    {
        Hero.Died -= FinishLevel;
    }

    public void FinishLevel()
    {
        if (PlayerPrefs.GetInt(_bestScoreSave) < _score.Amount)
        {
            PlayerPrefs.SetInt(_bestScoreSave, _score.Amount);
            PlayerPrefs.Save();
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
