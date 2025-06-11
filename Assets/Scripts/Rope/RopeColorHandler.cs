using UnityEngine;

namespace SHS.Assessment.Rope
{
    public class RopeColorHandler : MonoBehaviour
    {
        [SerializeField] private Color topColor;
        [SerializeField] private Color bottomColor;
        [SerializeField] private SpriteRenderer ropeRenderer;
        [SerializeField] private float topY = 3f;
        [SerializeField] private float bottomY = -3f;

        private Color currentColor;

        private void Update()
        {
            currentColor = Color.white;

            if (transform.position.y > 0)
            {
                float t = Mathf.InverseLerp(topY, 0, transform.position.y);
                currentColor = Color.Lerp(topColor, Color.white, t);
            }
            else
            {
                float t = Mathf.InverseLerp(0, bottomY, transform.position.y);
                currentColor = Color.Lerp(Color.white, bottomColor, t);
            }

            ropeRenderer.color = currentColor;
        }
    }
}