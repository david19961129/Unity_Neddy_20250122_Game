using UnityEngine;

namespace NEDDY
{
    /// <summary>
    /// 互動系統
    /// </summary>
    public class InteractionSystem:MonoBehaviour
    {
        [SerializeField, Header("群組_互動介面")]
        private Animator aniInteractionUI;
        [SerializeField, Header("互動按鍵")]
        private KeyCode interactionKey = KeyCode.E;

        private string parFadeIn = "觸發淡入", parFadeOut = "觸發淡出";
        private bool startInteraction;
        private IInteraction interactionObject;
        private WorldToUIPosition interactionPosition;

        private void Awake(){interactionPosition = aniInteractionUI.GetComponent<WorldToUIPosition>();}

        //觸發事件
        //collision 儲存碰到物件的碰撞資訊
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.TryGetComponent(out IInteraction interaction))
            {
                aniInteractionUI.SetTrigger(parFadeIn);
                startInteraction = true;
                interactionObject=interaction;
                interactionPosition.UpdatePosition(collision.transform, Vector3.zero);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            //如果碰到物件有安裝互動介面
         if(collision.TryGetComponent(out IInteraction interaction))
            {
                //就隱藏互動介面
                aniInteractionUI.SetTrigger(parFadeOut);
                startInteraction = false;
                interactionObject= null;
            }
        }

        private void Update()
        {
            StartInteraction();
        }

        private void StartInteraction()
        {
            if(!startInteraction) return;

            if(interactionObject == null)return;

            if(Input.GetKeyDown(interactionKey))
            {
                interactionObject.Interaction();
                aniInteractionUI.SetTrigger(parFadeOut);
            }
        }
    }
}
