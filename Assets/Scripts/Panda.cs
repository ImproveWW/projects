using System;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;



public class Panda : MonoBehaviour
{
    public event Action Down;

    private int _clicks;

    public int Clicks => _clicks;
  

    private void OnMouseDown()
    {
        Down?.Invoke();
        _clicks++;
    }
    

}
