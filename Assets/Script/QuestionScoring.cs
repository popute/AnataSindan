using System.Collections.Generic;
using UnityEngine;

public class QuestionScoring : MonoBehaviour
{
    // 各タイプのスコア管理（A/B/C/D）
    private Dictionary<char, int> typeScores = new Dictionary<char, int>
    {
        { 'A', 0 },
        { 'B', 0 },
        { 'C', 0 },
        { 'D', 0 }
    };

    // 質問ごとの加点設定
    private Dictionary<(int, string), List<char>> pointTable = new Dictionary<(int, string), List<char>>
    {
        { (0, "Yes"), new List<char>{ 'A', 'B' } },
        { (0, "No"),  new List<char>{ 'C' } },
        { (0, "Unknown"), new List<char>{ 'D' } },

        { (1, "Yes"), new List<char>{ 'B', 'C' } },
        { (1, "No"),  new List<char>{ 'D' } },
        { (1, "Unknown"), new List<char>{ 'A' } },

        { (2, "Yes"), new List<char>{ 'C', 'D' } },
        { (2, "No"),  new List<char>{ 'A' } },
        { (2, "Unknown"), new List<char>{ 'B' } },

        { (3, "Yes"), new List<char>{ 'A', 'B' } },
        { (3, "No"),  new List<char>{ 'C', 'D' } },
        { (3, "Unknown"), new List<char>{ 'D' } },

        { (4, "Yes"), new List<char>{ 'B', 'D' } },
        { (4, "No"),  new List<char>{ 'A' } },
        { (4, "Unknown"), new List<char>{ 'C' } },

        { (5, "Yes"), new List<char>{ 'D' } },
        { (5, "No"),  new List<char>{ 'C' } },
        { (5, "Unknown"), new List<char>{ 'A', 'B' } },

        { (6, "Yes"), new List<char>{ 'C' } },
        { (6, "No"),  new List<char>{ 'A', 'D' } },
        { (6, "Unknown"), new List<char>{ 'B' } },

        { (7, "Yes"), new List<char>{ 'B', 'C' } },
        { (7, "No"),  new List<char>{ 'D' } },
        { (7, "Unknown"), new List<char>{ 'A' } },
    };

    public void AddScore(int questionIndex, string answer)
    {
        var key = (questionIndex, answer);
        if (pointTable.ContainsKey(key))
        {
            foreach (char type in pointTable[key])
            {
                typeScores[type]++;
                Debug.Log($"タイプ {type} に1点加点 (Q{questionIndex + 1} - {answer})");
            }
        }
        else
        {
            Debug.LogWarning($"加点情報が見つかりません: Q{questionIndex + 1} - {answer}");
        }
    }

    public Dictionary<char, int> GetScores()
    {
        return typeScores;
    }

    public char GetResultType()
    {
        // 最もスコアが高いタイプを返す
        int max = int.MinValue;
        char result = 'A';
        foreach (var pair in typeScores)
        {
            if (pair.Value > max)
            {
                max = pair.Value;
                result = pair.Key;
            }
        }
        return result;
    }

}