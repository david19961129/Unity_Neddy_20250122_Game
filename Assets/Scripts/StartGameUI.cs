using Fungus;
using UnityEngine;

public class StartGameUI : MonoBehaviour
{
    Flowchart flowchart;
    string messageName = "遊戲開始對話";
    
    public void onButtonClick()
    {
        flowchart.SendFungusMessage(messageName);

    }
}
