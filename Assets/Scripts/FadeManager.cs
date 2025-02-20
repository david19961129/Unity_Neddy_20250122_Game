using System.Collections;
using UnityEngine;

namespace NEDDY
{
    /// <summary>
    /// 淡入淡出管理器
    /// </summary>
    public class FadeManager : MonoBehaviour
    {
        private WaitForSeconds waitFade => new WaitForSeconds(0.05f);
        /// <summary>
        /// 淡入淡出(協同程序)
        /// </summary>
        /// <param name="group">要淡入的群組元件</param>
        /// <param name="fadeIn">是否淡入</param>
        /// <returns></returns>
        public IEnumerable Fade(CanvasGroup group, bool fadeIn = true)
        {
            yield return new WaitForSeconds(1);
            float increase = fadeIn ? +0.1f : -0.1f;//如果淡入就+0.1 否則 -0.1
            for (int i = 0;i<10;i++)   //重複跑十次
            {
                group.alpha += increase;   //透明度累加0.1
                yield return waitFade;  //等待
            }
            group.interactable = fadeIn;  //互動設定
            group.blocksRaycasts =fadeIn; //射線遮擋設定
        }
    }
}

