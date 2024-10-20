using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using TMPro;

public class TextIndicator : MonoBehaviour
{
    Vector3 playerSize;
    public TMP_Text text;
    // public float time = 5.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerSize = FindFirstObjectByType<character>().getSize();
    }

    // Update is called once per frame
    void Update()
    {
        // time -= Time.deltaTime;
        
        // if (time <= 0) {
            
        //     time = 5.0f;
        // }
        
    }
    public void setText() {
        text.SetText("You substantially increased in size!");
    }

    public void removeText() {
        text.SetText("");
    }
}
