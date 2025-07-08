using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuestionMove : MonoBehaviour
{
    public GameObject choiceButtons; // はい・いいえ・わからないボタンをまとめたオブジェクト
    public GameObject nextButton; // 「次へ」ボタン

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

    private string[] introDialogue = {
        "ようこそお客人",
        "ここは……どこなんでしょうね",
        "大丈夫、アナタは質問にこたえてくれるだけでいい\nそれで無事に帰れる",
        "それじゃ、始めようか"
    };
    private int dialogueIndex = 0;
    private bool isIntroFinished = false;

    private string[] outroDialogue = {
    "──ふむ、なるほどね。",
    "ありがとう。アナタのこと、少し分かった気がするよ。",
    "……ほんとにありがとう",
    "そしたら、さようなら"
};

private int outroIndex = 0;
private bool isOutro = false;

    void Start()
    {
        // もし前回のスコアが残っているならリセット
        scoring = FindObjectOfType<QuestionScoring>();
        if (scoring != null)
        {
            scoring.ResetScores();
        }

        choiceButtons.SetActive(false);
        nextButton.SetActive(true);

        ShowDialogue();
    }

    void ShowDialogue()
    {
        if (dialogueIndex < introDialogue.Length)
        {
            questionText.text = introDialogue[dialogueIndex];
            dialogueIndex++;
        }
        else
        {
            isIntroFinished = true;
            nextButton.SetActive(false);
            choiceButtons.SetActive(true);
            ShowQuestion();
        }
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
            /* char resultType = scoring.GetResultType(); // A〜Dを取得

         string sceneName = resultType.ToString(); // 'A' → "A" など

         Debug.Log($"結果タイプ: {resultType}, 遷移先Scene: {sceneName}");
 */
        isOutro = true;
        nextButton.SetActive(true);
        choiceButtons.SetActive(false);
        ShowOutroDialogue();
        }
    }

    void ShowOutroDialogue()
{
    if (outroIndex < outroDialogue.Length)
    {
        questionText.text = outroDialogue[outroIndex];
        outroIndex++;
    }
    else
    {
        // 会話が終わったら次のSceneへ
        SceneManager.LoadScene("ResultScene");
    }
}
    
    public void OnNextClicked()
    {
        if (!isIntroFinished)
    {
        ShowDialogue();
    }
    else if (isOutro)
    {
        ShowOutroDialogue();
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
