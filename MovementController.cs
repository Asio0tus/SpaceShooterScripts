using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public enum ControlMode
    {
        Keyboard,
        VirtualJoystick
    }

    [SerializeField] private Spaceship m_TargetShip;
    public void SetTargetShip(Spaceship ship) => m_TargetShip = ship;

    [SerializeField] private VirtualJoystick m_VirtualJoystick;

    [SerializeField] private ControlMode m_ControlMode;

    private void Start()
    {
        if (Application.isMobilePlatform)
        {
            m_ControlMode = ControlMode.VirtualJoystick;
            m_VirtualJoystick.gameObject.SetActive(true);
        }
        else if(m_ControlMode == ControlMode.Keyboard)
        {
            m_VirtualJoystick.gameObject.SetActive(false);          
        }
        else
        {
            m_VirtualJoystick.gameObject.SetActive(true);
        }
    }

    private void Update()
    {
        if (m_TargetShip == null) return;

        if (m_ControlMode == ControlMode.Keyboard)
            ControlKeyboard();

        if (m_ControlMode == ControlMode.VirtualJoystick)
            ControlVirtualJoystick();
    }

    private void ControlVirtualJoystick()
    {
        Vector3 dir = m_VirtualJoystick.Value;

        var dot = Vector2.Dot(dir, m_TargetShip.transform.up);
        var dot2 = Vector2.Dot(dir, m_TargetShip.transform.right);

        m_TargetShip.ThrustControl = Mathf.Max(0, dot);
        m_TargetShip.TorqueControl = -dot2;
    }

    private void ControlKeyboard()
    {
        float thrust = 0.0f;
        float torque = 0.0f;

        if (Input.GetKey(KeyCode.UpArrow))
            thrust = 1.0f;

        if (Input.GetKey(KeyCode.DownArrow))
            thrust = -1.0f;

        if (Input.GetKey(KeyCode.LeftArrow))
            torque = 1.0f;

        if (Input.GetKey(KeyCode.RightArrow))
            torque = -1.0f;

        m_TargetShip.ThrustControl = thrust;
        m_TargetShip.TorqueControl = torque;
    }    
}
