using Borodar.LD34.Questions;
using UnityEngine;
using UnityEngine.UI;

namespace Borodar.LD34
{
    public class QuestionText : MonoBehaviour
    {
        private Text _text;

        protected void Awake()
        {
            _text = GetComponent<Text>();
        }

        public void GenerateQuestion(bool isThatTrue)
        {
            var question = new Question();
            _text.text =  (isThatTrue) ? question.GetTrueString() : question.GetFakeString();
        }
    }
}