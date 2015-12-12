using Borodar.LD34.Helpers;
using UnityEngine;
using UnityEngine.UI;

namespace Borodar.LD34.Managers
{
    public class SceneManager : Singleton<SceneManager>
    {
        public QuestionText QuestionText;

        public void UpdateQuestion()
        {
            QuestionText.GenerateQuestion();
        }
    }
}