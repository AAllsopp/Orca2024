using UnityEngine;
using UnityEngine.UI;

public class TextIndicator : MonoBehaviour
{
    Vector3 playerSize;
    public Text textItem;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerSize = FindFirstObjectByType<character>().getSize();
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    void printText() {
        if (playerSize.x >= 2.99999999) {
            // add text here
            textItem.text = "You substantially increased in size!";
        }
    }
}
