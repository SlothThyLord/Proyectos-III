using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerConnection : MonoBehaviour
{
    public SampleMessageListener sampleMessage;
    public SerialController serialController;
    // Update is called once per frame

    private void Start()
    {
        serialController = GameObject.Find("Ardity").GetComponent<SerialController>();
        sampleMessage = GameObject.Find("MessageArrives").GetComponent<SampleMessageListener>();
    }

    void Update()
    {
      
        if (Input.GetKeyDown(KeyCode.C))
        {
            serialController.SendSerialMessage("#om"); // Recibir matrices
            sampleMessage.Calibrar();   // Calibrar
            
        }
    }

   
}
