using UnityEditor.SceneManagement;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(SpriteCutter))]
    public class MageKiller : MonoBehaviour
    {
        private SpriteRenderer spriteRenderer;
        private SpriteCutter spriteCutter;
        [SerializeField] private float alphaRemoverSpeed;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            spriteCutter = GetComponent<SpriteCutter>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                KillMage();
            }
        }

        private void KillMage()
        {
            var mageParts = spriteCutter.CutSpriteHorizontally(spriteRenderer, transform.position);

            mageParts[0].AddComponent<ConstantForceApplier>().ApplyForce(new Vector3(1, 1));
            mageParts[0].AddComponent<ConstantAlphaRemover>().RemoveAlpha(alphaRemoverSpeed);

            mageParts[1].AddComponent<ConstantForceApplier>().ApplyForce(new Vector3(1, -1));
            mageParts[1].AddComponent<ConstantAlphaRemover>().RemoveAlpha(alphaRemoverSpeed);

            Destroy(gameObject);
        }
    }
}
