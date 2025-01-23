using UnityEngine;

namespace NEDDY
{
    /// <summary>
    /// NPC控制器
    /// </summary>
    public class NPCController : MonoBehaviour, IInteraction
    {
        public void Interaction()
        {
            Debug.Log("<color=#f33>NPC 開始互動~</color>");
        }
    }
}
