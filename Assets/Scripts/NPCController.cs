using Fungus;
using UnityEngine;

namespace NEDDY
{
    /// <summary>
    /// NPC控制器
    /// </summary>
    public class NPCController : MonoBehaviour, IInteraction
    {
        [field: SerializeField]
        public Vector3 uiOffset { get; set; }
        [SerializeField, Header("NPC Fungus_NPC")]
        private Flowchart fungusNPC;
        [SerializeField,Header("NPC 訊息")]
        private string npcMessage;
        public void Interaction()
        {
            Debug.Log("<color=#f33>NPC 開始互動~</color>");
            fungusNPC.SendFungusMessage(npcMessage);
        }
    }
}
