using UnityEngine;
using NEDDY.Tools;

namespace NEDDY
{
    /// <summary>
    /// 狀態基底
    /// </summary>
    public class StateBase : MonoBehaviour, IState
    {
        protected string stateName;
        protected Animator ani;
        protected Rigidbody2D rig;
        protected string parMove = "移動數值";
        protected string parAttack = "觸發攻擊";

        protected virtual void Awake()
        {
            ani = GetComponent<Animator>();
            rig = GetComponent<Rigidbody2D>();
        }
        public virtual void EnterState()
        {
            LogSystem.Log($"進入【{stateName}】狀態)", "#3f3");
        }

        public virtual void ExitState()
        {
            LogSystem.Log($"離開【{stateName}】狀態)", "#f33");
        }

        public virtual void UpdateState()
        {
            LogSystem.Log($"更新【{stateName}】狀態)", "#fa3");
        }
    }
}