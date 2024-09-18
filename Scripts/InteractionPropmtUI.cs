using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractionPropmtUI : MonoBehaviour
{
    private Camera _mainCam;
    [SerializeField] private GameObject _uiPanel;
    [SerializeField] private TextMeshProUGUI _promptText;

    // Start is called before the first frame update
    void Start()
    {
        _mainCam = Camera.main;
        _uiPanel.SetActive(false);
    }


    private void LateUpdate()
    {
        var rotation = _mainCam.transform.rotation;
        transform.LookAt(transform.position + rotation * Vector3.forward, rotation * Vector3.up);
    }

    public bool IsDisplayed = false;
    public void setUp(string promptText)
    {
        _promptText.text = promptText;
        _uiPanel.SetActive(true);
        IsDisplayed = true;
    }
    public void close(){
        _uiPanel.SetActive(false);
        IsDisplayed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
