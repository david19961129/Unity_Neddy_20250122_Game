using UnityEngine;

namespace NEDDY
{
    /// <summary>
    /// 寶箱
    /// </summary>
    public class Chest : MonoBehaviour, IInteraction
    {
        [field:SerializeField]
        public Vector3 uiOffset {  get; set; }

        private Animator ani;
        private string parOpen = "觸發寶箱";

        private void Awake()
        {
            ani = GetComponent<Animator>();
        }
        public void Interaction()
        {
            Debug.Log("<color=#f6d>寶相互動</color>");
            ani.SetTrigger(parOpen);
        }

    }
}
