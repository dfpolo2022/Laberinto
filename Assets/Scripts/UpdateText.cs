using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateText : MonoBehaviour
{
    public bool n;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeValue(float size)
    {
        if (n)
        {
            this.GetComponent<TextMeshProUGUI>().text = "N: " + size;
        }
        else
        {
            this.GetComponent<TextMeshProUGUI>().text = "M: " + size;
        }
        
    }
}
