using UnityEngine;

namespace NEDDY
{
    /// <summary>
    /// 狀態基底
    /// </summary>
    public class StateBase:MonoBehaviour
    {
        protected string stateName;
        public virtual void EnterState()
        {
            
        }
    }
}