using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Usb2Player : MonoBehaviour
{
    [SerializeField] private float startingUsb;
    public float currentUsb { get; private set; }
    private void Awake()
    {
        currentUsb = 2f;
    }
    public void AddUsb(float _value)
    {
        currentUsb = Mathf.Clamp(currentUsb + _value, 0, startingUsb);
    }
}
