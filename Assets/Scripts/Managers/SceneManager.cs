using System.Collections;
using Borodar.LD34.Helpers;
using Borodar.LD34.Questions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Borodar.LD34.Managers
{
    public class SceneManager : Singleton<SceneManager>
    {
        [Space(10)]
        public Background Background;
        public Text QuestionText;        
        public Text HintText;
        [Space(10)]
        public ParticleSystem YesParticles;
        public ParticleSystem NoParticles;

        private Question _question;
        private bool _isQuestionTrue;
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
            _question = new Question();
            _isQuestionTrue = Random.value > 0.5f;

            QuestionText.text = (_isQuestionTrue) ? _question.GetTrueString() : _question.GetFakeString();
        }

        public void CheckAnswer(bool answer)
        {
            if (_isCheckingAnswer) return;

            var isAnswerCorrect = (answer == _isQuestionTrue);
            if (isAnswerCorrect)
            {
                GlobalManager.Audio.PlayRandomCorrectSound();

                if (_isQuestionTrue)
                {
                    YesParticles.Play();
                }
                else
                {
                    NoParticles.Play();
                }
            }
            else
            {
                GlobalManager.Audio.PauseMusic();
                GlobalManager.Audio.PlayWrongSound();

                HintText.text = _isQuestionTrue ? "But it's true!" : _question.GetTrueString(); ;
                HintText.gameObject.SetActive(true);
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

            HintText.gameObject.SetActive(false);
            GenerateQuestion();
            _isCheckingAnswer = false;
        }
    }
}