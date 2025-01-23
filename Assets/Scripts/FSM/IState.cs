using UnityEngine;

namespace NEDDY
{
    interface IState
    {
        /// <summary>
        /// 進入狀態
        /// </summary>
        void EnerState();
        /// <summary>
        /// 更新狀態
        /// </summary>
        void UpdateState();
        /// <summary>
        /// 離開狀態
        /// </summary>
        void ExitState();
    }
}
