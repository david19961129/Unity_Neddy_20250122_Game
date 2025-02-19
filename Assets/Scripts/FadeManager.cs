using System.Collections;
using UnityEngine;

namespace NEDDY
{
    public class FadeManager : MonoBehaviour
    {
        private WaitForSeconds waitFade => new WaitForSeconds(0.05f);
        public IEnumerable Fade(CanvasGroup group, bool fadeIn = true)
        {
            for (int i = 0;i<10;i++)
            {
                group.alpha += 0.1f;
                yield return waitFade;
            }
        }
    }
}

