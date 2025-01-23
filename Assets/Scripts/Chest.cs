using UnityEngine;

namespace NEDDY
{
    /// <summary>
    /// 寶箱
    /// </summary>
    public class Chest : MonoBehaviour, IInteraction
    {
        public void Interaction()
        {
            Debug.Log("<color=#f6d>寶相互動</color>");
        }
    }
}
