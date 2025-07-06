using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuestionMove : MonoBehaviour
{
    public Text questionText; // 質問文を表示するText
     public QuestionScoring scoring; 

    private int questionIndex = 0;
    private string[] questions = {
       "タニンからの評価がキになる？",
    "本音をヒトに話すのはニガテ？",
    "落ち込んだとき、ダレかに話を聞いてほしい？",
    "ヒトにタヨるのは甘え？",
    "ジブンにどこか欠けてる部分があるとオモウ？",
    "昔の失敗をオモイダスことはある？",
    "タニンのシアワセを喜べる？",
    "いまのジブンを好きだと言える？"
    };

    void Start()
    {
        ShowQuestion();
    }

    void ShowQuestion()
    {
        if (questionIndex < questions.Length)
        {
            questionText.text = questions[questionIndex];
        }
        else
        {
            // 質問が終わったら次のSceneに移動など
            Debug.Log("質問終了");
            char resultType = scoring.GetResultType(); // A〜Dを取得

        string sceneName = resultType.ToString(); // 'A' → "A" など

        Debug.Log($"結果タイプ: {resultType}, 遷移先Scene: {sceneName}");

        SceneManager.LoadScene(sceneName);
        

        SceneManager.LoadScene(sceneName);
        }
    }

    public void OnYes()
    {
        scoring.AddScore(questionIndex, "Yes"); 
        questionIndex++;
        ShowQuestion();
    }

    public void OnNo()
    {
        scoring.AddScore(questionIndex, "No"); 
        questionIndex++;
        ShowQuestion();
    }

    public void OnUnknown()
    {
        scoring.AddScore(questionIndex, "Unknown"); 
        questionIndex++;
        ShowQuestion();
    }
}
