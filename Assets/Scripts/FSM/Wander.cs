using NEDDY.Tools;
using UnityEngine;

namespace NEDDY
{
    public class Wander : StateBase //繼承狀態基底類別
    {
        [SerializeField, Header("左邊界")]
        private Vector3 pointLeft;
        [SerializeField, Header("右邊界")]
        private Vector3 pointRight;
        [SerializeField, Header("移動速度"),Range(0,3)]
        private float wanderSpeed = 2;
        [SerializeField, Header("停止距離"), Range(0, 1)]
        private float stopDistance = 0.1f;
        [SerializeField, Header("待機機率"), Range(0, 1)]
        private float idleProbability = 0.5f;
        [SerializeField, Range(0, 3)]
        private float idleMin = 1;
        [SerializeField, Range(1, 5)]
        private float idleMax = 3;

        private Vector3 targetPoint;
        private bool isIdle;

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = new Color(1,0.3f,0.3f,0.8f);
            Gizmos.DrawSphere(pointLeft, 0.1f);
            Gizmos.DrawSphere(pointRight, 0.1f);
        }
        protected override void Awake()  //初始化名稱
        {
            base.Awake();     //保留父類別Awake內容
            stateName = "遊走";
        }

        //複寫方法
        public override void EnterState()
        {
            base.EnterState();
            targetPoint = pointRight;
            transform.eulerAngles = Vector3.zero;
        }

        public override void UpdateState()
        {
            base.UpdateState();
            WanderTo();
        }

        public override void ExitState()
        {
            base.ExitState();
        }

        private void WanderTo()
        {
            //如果在待機中就跳出
            if (isIdle) return;

            //如果 (目標座標 - 此物件 的 X 座標)取絕對值  >  0 就 往右邊移動
            if (Mathf.Abs(targetPoint.x - transform.position.x) > stopDistance)
            {
                rig.velocity = transform.right * wanderSpeed;
            }
            // 否則就停下
            else
            {
                rig.velocity =Vector3.zero;
                //如果 隨機值 <= 待機機率 就進入待機持續一段時間
                if (Random.value <= idleProbability)Idle() ;
                //否則 就 翻面
                else Turn();
            }
            //更新移動數值浮點數參數
            ani.SetFloat(parMove,rig.velocity.magnitude / wanderSpeed);
        }

        //定義待機方法
        private void Idle()
        {
            LogSystem.Log("待機", "#66f");
            isIdle = true;
            float random = Random.Range(idleMin,idleMax);
            Invoke("IdleDelay",random);
        }

        private void IdleDelay()
        {
            isIdle = false;
            Turn();
        }

        private void Turn()
        {
            //如果目標座標為右邊  就將  目標座標指定為 左邊
            targetPoint = targetPoint == pointRight ? pointLeft : pointRight;
            float angle = transform.eulerAngles.y == 0 ? 180 : 0;
            transform.eulerAngles = Vector2.up * angle;
        }
    }
}

