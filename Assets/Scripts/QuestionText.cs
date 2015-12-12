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

        public void GenerateQuestion()
        {
            var q = new Question();
            _text.text =  q.FirstOperand + " " + q.OperationString + " " + q.SecondOperand + " = " + q.Result;
        }
    }
}