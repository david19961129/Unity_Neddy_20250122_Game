using UnityEngine;

namespace NEDDY
{
    /// <summary>
    /// 世界座標轉為介面座標
    /// </summary>
    public class WorldToUIPosition : MonoBehaviour
    {
        private RectTransform rect;
        private Canvas canvas;
        private RectTransform rectCanvas;
        private Camera worldCamera;

        private void Awake()
        {
            rect = GetComponent<RectTransform>();
            canvas = transform.root.GetComponent<Canvas>();
            rectCanvas = canvas.GetComponent<RectTransform>();
            worldCamera = canvas.worldCamera;
        }
        /// <summary>
        /// 更新介面的座標
        /// </summary>
        /// <param name="target"></param>
        /// <param name="offset"></param>
        public void UpdatePosition(Transform target, Vector3 offset)
        {
            //先得目標物世界座標
            Vector3 worldPosition = target.position;
            // 位移座標
            worldPosition += offset;
            //將世界座標轉為螢幕座標
            Vector3 screen  = Camera.main.WorldToScreenPoint(worldPosition);
            //將螢幕座標傳為介面座標
            RectTransformUtility.ScreenPointToLocalPointInRectangle(rectCanvas, screen,worldCamera,out Vector2 uiposition);
            //更新介面座標
            rect.anchoredPosition = uiposition;
        }

    }
}
