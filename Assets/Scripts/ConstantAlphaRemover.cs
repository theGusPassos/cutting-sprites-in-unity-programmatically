using System.Timers;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class ConstantAlphaRemover : MonoBehaviour
    {
        private SpriteRenderer spriteRenderer;
        private Color currentColor;
        private float speed = 0;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();

            currentColor = spriteRenderer.material.GetColor("_Color");
        }

        private void Update()
        {
            if (speed != 0)
            {
                currentColor.a -= speed * Time.deltaTime;

                spriteRenderer.material.SetColor("_Color", currentColor);
            }
        }

        public void RemoveAlpha(float speed) => this.speed = speed;
    }
}
