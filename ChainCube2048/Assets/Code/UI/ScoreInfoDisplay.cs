using TMPro;
using UnityEngine;

public class ScoreInfoDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _score;

    private int _scoreValue;

    private void OnEnable() => Cube.OnCubeMergeStatic += ShowScoreInfo;
    private void OnDisable() => Cube.OnCubeMergeStatic -= ShowScoreInfo;

    private void ShowScoreInfo(int mergeValue)
    {
        _scoreValue += mergeValue;

        _score.text = _scoreValue.ToString();
    }
}
