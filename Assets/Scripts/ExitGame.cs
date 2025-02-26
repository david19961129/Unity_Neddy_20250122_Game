using UnityEngine;

namespace NEDDY
{
    public class ExitGame : MonoBehaviour
    {
        public void QuitGame()
        {
            Debug.Log("退出遊戲！"); // 在 Unity 編輯器測試時可看到這條訊息
            Application.Quit(); // 正式遊戲時關閉應用程式
        }
    }
}

