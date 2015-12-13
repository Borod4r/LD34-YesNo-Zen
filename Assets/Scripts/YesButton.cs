using Borodar.LD34.Managers;
using UnityEngine;

namespace Borodar.LD34
{
    public class YesButton : MonoBehaviour
    {
        public void OnClickHandler()
        {
            SceneManager.Instance.CheckAnswer(true);
        }
    }
}