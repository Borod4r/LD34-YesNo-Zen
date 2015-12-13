using System.Collections;
using Borodar.LD34.Helpers;
using Borodar.LD34.Questions;
using UnityEngine;
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
        private bool _isFirstQuestion = true;
        private bool _isQuestionTrue = true;
        private bool _isCheckingAnswer;

        //---------------------------------------------------------------------
        // Messages
        //---------------------------------------------------------------------

        public void Start()
        {
            if (GlobalManager.Game.IsFirstRun)
            {
                GlobalManager.Game.IsFirstRun = false;
            }
            else
            {
                QuestionText.text = "Play again?";
            }
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
            if (_isCheckingAnswer || (_isFirstQuestion && !answer)) return;

            if (_isFirstQuestion && !answer)
            {
                Application.Quit();
                return; // for web-player
            }

            _isFirstQuestion = false;

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

                StartCoroutine(ShowNextQuestion());
            }
            else
            {
                GlobalManager.Audio.StopMusic();
                GlobalManager.Audio.PlayWrongSound();

                HintText.text = _isQuestionTrue ? "But it's true!" : _question.GetTrueString();
                ;
                HintText.gameObject.SetActive(true);

                StartCoroutine(GameOver());
            }

            Background.CrossFadeColor();
        }

        //---------------------------------------------------------------------
        // Helpers
        //---------------------------------------------------------------------

        private IEnumerator ShowNextQuestion()
        {
            _isCheckingAnswer = true;
            yield return new WaitForSeconds(1f);

            HintText.gameObject.SetActive(false);
            GenerateQuestion();
            _isCheckingAnswer = false;
        }

        private IEnumerator GameOver()
        {
            _isCheckingAnswer = true;
            yield return new WaitForSeconds(3f);

            GlobalManager.Game.LoadScene(Application.loadedLevelName);
        }
    }
}