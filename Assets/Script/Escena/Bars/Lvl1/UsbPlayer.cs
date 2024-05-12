using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsbPlayer : MonoBehaviour
{
    [SerializeField] private float startingUsb;
    public float currentUsb { get; private set; }
    private void Awake()
    {
        currentUsb = 0f;
    }
   public void AddUsb (float _value)
    {
        currentUsb = Mathf.Clamp(currentUsb + _value, 0, startingUsb);
    }
}
