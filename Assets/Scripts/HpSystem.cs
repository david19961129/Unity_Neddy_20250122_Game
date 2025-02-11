using UnityEngine;

namespace NEDDY
{
public class HpSystem : MonoBehaviour , IDamage
{
        [SerializeField, Header("血量資料")]
        private DataHP dataHP;

        private float hp;
        private Animator ani;
        private string parDead = "觸發死亡";

        private void Awake()
        {
            hp=dataHP.hpmax;
            ani = GetComponent<Animator>();
        }
        public void Damage(float damage)
        {
            hp -= damage;
            if (hp < 0) Dead();
        }

        public void Dead()
        {
            ani.SetTrigger(parDead);
        }
    }
}

