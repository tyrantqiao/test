using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGas : MonoBehaviour
{
    private Button ClzBtn;
    private Button SwitchBtn;
    private Camera MainCam;

    // Start is called before the first frame update
    void Start()
    {
        MainCam = GameObject.Find("P1/default/Main Camera").GetComponent<Camera>();
        ClzBtn = transform.Find("AllBtn/Clz").GetComponent<Button>();
        SwitchBtn = transform.Find("AllBtn/Switch").GetComponent<Button>();
        ClzBtn.onClick.AddListener(Close);
    }

    public void Close()
    {
        Destroy(transform.gameObject);
        MainCam.enabled = true;
    }
    // Update is called once per frame
    void Update()
    {
    }
}
