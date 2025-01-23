using UnityEngine;

namespace NEDDY
{
    [CreateAssetMenu(menuName = "NEDDY/DataHP")]
    public class DataHP : ScriptableObject
    {
        [Header("血量最大值"), Range(0, 5000)]
        public float hpmax = 10;
    }
}

