using UnityEngine;

namespace NEDDY
{
    /// <summary>
    /// 介面:互動
    /// </summary>
    interface IInteraction
    {
        /// <summary>
        /// 互動介面
        /// </summary>
        public void Interaction();
        /// <summary>
        /// 互動介面位移
        /// </summary>
        public Vector3 uiOffset {  get; set; }
    }
}