using Borodar.LD34.Managers;
using UnityEngine;

namespace Borodar.LD34
{
    public class NoButton : MonoBehaviour
    {
        public void OnClickHandler()
        {
            SceneManager.Instance.CheckAnswer(false);
        }
    }
}