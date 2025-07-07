using UnityEngine;
using UnityEngine.UI;

public class ResultDisplay : MonoBehaviour
{
    public Text Word;//タイプ結果のテキスト
    public Text Doc;//タイプ結果の文章テキスト

    public QuestionScoring scoring; //別スクリプトから取得したタイプ結果


    private string[] resultWord = {
       "冷静な",
    "繊細な",
    "明るい",
    "自由な",
    };

    private string[] resultDoc = {
    "──アナタは判断を間違えないでしょう\n──アナタはヒトに非難されるでしょう\n──アナタはそれでも歩きツヅけるでしょう",
    "──アナタはヒトを傷つけないでしょう\n──アナタはヒトに傷つけられるでしょう\n──アナタのやさしさは伝わらないでしょう",
    "──アナタの明るさに救われた人がいるでしょう\n──アナタの明るさに苦しめられた人がいるでしょう\n──アナタはソレらに気づくことはないでしょう",
    "──アナタは誰にも縛られないでしょう\n──アナタは誰も縛れないでしょう\n──アナタは義務付けられたジユウを謳歌するでしょう",
    };

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoring = FindObjectOfType<QuestionScoring>();

        ShowText();

    }

    void ShowText()
    {
        char resultType = scoring.GetResultType(); // A〜Dを取得

        switch (resultType)
        {
            case 'A':
                Word.text = resultWord[0];
                Doc.text = resultDoc[0];
                break;
            case 'B':
                Word.text = resultWord[1];
                Doc.text = resultDoc[1];
                break;
            case 'C':
                Word.text = resultWord[2];
                Doc.text = resultDoc[2];
                break;
            case 'D':
                Word.text = resultWord[3];
                Doc.text = resultDoc[3];
                break;
            
        }

    }
}