using System.Collections;
using Borodar.LD34.Helpers;
using UnityEngine;
using UnityEngine.UI;

namespace Borodar.LD34.Managers
{
    public class SceneManager : Singleton<SceneManager>
    {
        public QuestionText QuestionText;
        public Text DebugText;
        public bool IsThatTrue;

        private bool _isCheckingAnswer;

        public void Start()
        {
            GenerateQuestion();
        }

        public void GenerateQuestion()
        {
            IsThatTrue = Random.value > 0.5f;
            QuestionText.GenerateQuestion(IsThatTrue);
        }

        public void CheckAnswer(bool answer)
        {
            if (_isCheckingAnswer) return;

            DebugText.text = (answer == IsThatTrue) ? "Correct" : "Wrong";
            DebugText.gameObject.SetActive(true);
            StartCoroutine(ShowResults());
        }

        private IEnumerator ShowResults()
        {
            _isCheckingAnswer = true;
            yield return new WaitForSeconds(1f);
            DebugText.gameObject.SetActive(false);
            GenerateQuestion();
            _isCheckingAnswer = false;
        }
    }
}