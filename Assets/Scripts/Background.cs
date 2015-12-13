using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Borodar.LD34
{
    public class Background : MonoBehaviour
    {
        public List<Color> Colors;
        private Image _background;

        //---------------------------------------------------------------------
        // Messages
        //---------------------------------------------------------------------

        public void Awake()
        {
            _background = GetComponent<Image>();
        }

        //---------------------------------------------------------------------
        // Public
        //---------------------------------------------------------------------

        public void CrossFadeColor()
        {
            Color color;
            do
            {
                color = GetRandomColor();
            } while (_background.color == color);

            StartCoroutine(CrossFadeColor(color, 1f));
        }

        //---------------------------------------------------------------------
        // Helpers
        //---------------------------------------------------------------------

        private Color GetRandomColor()
        {
            return Colors[Random.Range(0, Colors.Count)];
        }

        IEnumerator CrossFadeColor(Color endColor, float duration)
        {
            var startColor = _background.color;

            float elapsed = 0;
            var start = Time.time;

            while (elapsed < duration)
            {
                elapsed = Time.time - start;
                var normalisedTime = Mathf.Clamp(elapsed / duration, 0, 1);

                _background.color = Color.Lerp(startColor, endColor, normalisedTime);
                yield return null;
            }

            _background.color = endColor;
            yield return null;
        }
    }
}