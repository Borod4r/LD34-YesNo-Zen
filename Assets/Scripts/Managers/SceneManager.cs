using System.Collections;
using Borodar.LD34.Helpers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Borodar.LD34.Managers
{
    public class SceneManager : Singleton<SceneManager>
    {
        [Space(10)]
        public Background Background;
        public QuestionText QuestionText;        
        public Text DebugText;
        [Space(10)]
        public ParticleSystem YesParticles;
        public ParticleSystem NoParticles;
        [Space(10)]
        public bool IsQuestionTrue;

        private bool _isCheckingAnswer;

        //---------------------------------------------------------------------
        // Messages
        //---------------------------------------------------------------------

        public void Start()
        {
            GenerateQuestion();
        }

        //---------------------------------------------------------------------
        // Public
        //---------------------------------------------------------------------

        public void GenerateQuestion()
        {
            IsQuestionTrue = Random.value > 0.5f;
            QuestionText.GenerateQuestion(IsQuestionTrue);
        }

        public void CheckAnswer(bool answer)
        {
            if (_isCheckingAnswer) return;

            var isAnswerCorrect = (answer == IsQuestionTrue);

            DebugText.text = isAnswerCorrect ? "Correct" : "Wrong";
            DebugText.gameObject.SetActive(true);

            if (isAnswerCorrect)
            {
                if (IsQuestionTrue)
                {
                    YesParticles.Play();
                }
                else
                {
                    NoParticles.Play();
                    
                }
            }

            StartCoroutine(ShowResults());

            Background.CrossFadeColor();
        }

        //---------------------------------------------------------------------
        // Helpers
        //---------------------------------------------------------------------

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