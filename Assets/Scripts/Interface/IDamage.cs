namespace NEDDY
{
    interface IDamage
    {
        /// <summary>
        /// 受傷
        /// </summary>
        /// <param name="damage"></param>
        public void Damage(float damage);

        /// <summary>
        /// 死亡
        /// </summary>
        public void Dead();
    }
}
