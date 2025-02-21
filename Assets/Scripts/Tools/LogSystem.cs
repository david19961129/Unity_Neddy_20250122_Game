using UnityEngine;

namespace NEDDY.Tools
{
    /// <summary>
    /// 輸出系統
    /// </summary>
    public class LogSystem : MonoBehaviour
    {
        /// <summary>
        /// 輸出系統
        /// </summary>
        /// <param name="message"></param>
        /// <param name="color"></param>
        public static void Log(string message,string color = "#fff")
        {
            Debug.Log($"<color={color}>{message}</color>");
        }
    }
}

