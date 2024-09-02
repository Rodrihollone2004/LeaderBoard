using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LeaderboardManager : MonoBehaviour
{
    public TMP_Text numberboardText;
    public TMP_Text nameboardText;
    public TMP_Text scoreboardText;
    public TMP_InputField playerNameInput;
    public TMP_InputField playerScoreInput;
    public Button addButton;

    private List<Player> leaderboard = new List<Player>();

    private void Start()
    {
        InitializeLeaderboard();
        addButton.onClick.AddListener(AddPlayer);
    }

    private void InitializeLeaderboard()
    {
        for (int i = 0; i < 10; i++)
        {
            string randomName = "Player" + Random.Range(1, 1000).ToString();
            int randomScore = Random.Range(0, 1000);
            leaderboard.Add(new Player(randomName, randomScore));
        }
        SortLeaderboard();
        UpdateNumberboardDisplay();
        UpdateNameboardDisplay();
        UpdateScoreboardDisplay();
    }

    private void AddPlayer()
    {
        string name = playerNameInput.text;
        int score;
        if (int.TryParse(playerScoreInput.text, out score))
        {
            leaderboard.Add(new Player(name, score));
            SortLeaderboard();
            UpdateNumberboardDisplay();
            UpdateNameboardDisplay();
            UpdateScoreboardDisplay();
        }
    }

    private void SortLeaderboard()
    {
        leaderboard.Sort((a, b) => b.score.CompareTo(a.score));
        if (leaderboard.Count > 10)
        {
            leaderboard = leaderboard.GetRange(0, 10);
        }
    }

    private void UpdateNumberboardDisplay()
    {
        numberboardText.text = "N°\n";
        for (int i = 0; i < leaderboard.Count; i++)
        {
            numberboardText.text += $"{i + 1}\n";
        }
    }
    private void UpdateNameboardDisplay()
    {
        nameboardText.text = "Nombre\n";
        for (int i = 0; i < leaderboard.Count; i++)
        {
            nameboardText.text += $"{leaderboard[i].name}\n";
        }
    }
    private void UpdateScoreboardDisplay()
    {
        scoreboardText.text = "Score\n";
        for (int i = 0; i < leaderboard.Count; i++)
        {
            scoreboardText.text += $"{leaderboard[i].score}\n";
        }
    }
}