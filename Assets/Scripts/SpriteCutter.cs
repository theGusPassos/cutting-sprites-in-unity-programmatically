using UnityEngine;

namespace Assets.Scripts
{
    public class SpriteCutter : MonoBehaviour
    {
        [SerializeField] private float verticalOffset;

        [ContextMenu("cut horizontally")]
        public void Cut()
        {
            CutSpriteHorizontally(GetComponent<SpriteRenderer>(), transform.position);
        }

        public GameObject[] CutSpriteHorizontally(SpriteRenderer spriteRenderer, Vector2 spritePosition)
        {
            var spriteToCut = spriteRenderer.sprite;
            var ySpriteSize = spriteToCut.rect.height / 2;

            var upperSprite = Sprite.Create(
                spriteToCut.texture,
                new Rect(
                    spriteToCut.rect.x,
                    spriteToCut.rect.y + ySpriteSize - verticalOffset,
                    spriteToCut.rect.width,
                    ySpriteSize + verticalOffset),
                Vector2.zero,
                spriteToCut.pixelsPerUnit,
                0,
                SpriteMeshType.FullRect);

            var lowerSprite = Sprite.Create(
                spriteToCut.texture,
                new Rect(
                    spriteToCut.rect.x,
                    spriteToCut.rect.y,
                    spriteToCut.rect.width,
                    ySpriteSize - verticalOffset),
                Vector2.zero,
                spriteToCut.pixelsPerUnit,
                0,
                SpriteMeshType.FullRect);

            var upperBody = new GameObject("upper body");
            var lowerBody = new GameObject("lower body");

            var upperBodyRenderer = upperBody.AddComponent<SpriteRenderer>();
            upperBodyRenderer.sprite = upperSprite;
            upperBodyRenderer.material = spriteRenderer.material;

            var lowerBodyRenderer = lowerBody.AddComponent<SpriteRenderer>();
            lowerBodyRenderer.sprite = lowerSprite;
            lowerBodyRenderer.material = spriteRenderer.material;

            var xPivotInUnits = spriteToCut.pivot.x / spriteToCut.pixelsPerUnit;
            var yPivotInUnits = spriteToCut.pivot.y / spriteToCut.pixelsPerUnit;

            upperBody.transform.position = spritePosition - new Vector2(
                xPivotInUnits,
                -(lowerSprite.rect.height / spriteToCut.pixelsPerUnit) + yPivotInUnits);

            lowerBody.transform.position = spritePosition - new Vector2(xPivotInUnits, yPivotInUnits);

            return new GameObject[] { upperBody, lowerBody };
        }
    }
}
