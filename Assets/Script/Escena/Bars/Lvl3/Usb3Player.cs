using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Usb3Player : MonoBehaviour
{
    [SerializeField] private float startingUsb;
    public float currentUsb { get; private set; }
    private void Awake()
    {
        currentUsb = 5f;
    }
    public void AddUsb(float _value)
    {
        currentUsb = Mathf.Clamp(currentUsb + _value, 0, startingUsb);
    }
}
