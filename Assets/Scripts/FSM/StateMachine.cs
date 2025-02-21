using UnityEngine;

namespace NEDDY
{
    /// <summary>
    /// 狀態機
    /// </summary>
    public class StateMachine : MonoBehaviour
    {
        [SerializeField,Header("預設狀態")]
        private StateBase stateDefault;

        private StateBase stateCurrent;

        private void Start()
        {
            SwitchState(stateDefault);
        }

        private void Update()
        {
            stateCurrent.UpdateState();
        }

        /// <summary>
        /// 切換狀態
        /// </summary>
        /// <param name="stateNext">要切換的下一個狀態機</param>
        public void SwitchState(StateBase stateNext)
        {
            //?判定左邊是否有值，有值才會執行右邊
            stateCurrent?.ExitState();  //先退出目前狀態機
            stateCurrent = stateNext;   //將目前狀態機指向下一個狀態
            stateCurrent.EnterState();   //執行目前狀態機的進入
        }
    }
}

