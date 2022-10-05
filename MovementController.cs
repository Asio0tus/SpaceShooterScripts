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

    [SerializeField] private PointerClickHold m_MobileFirePrimary;
    [SerializeField] private PointerClickHold m_MobileFireSecondary;

    private void Start()
    {
        if (Application.isMobilePlatform)
        {
            m_ControlMode = ControlMode.VirtualJoystick;
            m_VirtualJoystick.gameObject.SetActive(true);
            m_MobileFirePrimary.gameObject.SetActive(true);
            m_MobileFireSecondary.gameObject.SetActive(true);
        }
        else if(m_ControlMode == ControlMode.Keyboard)
        {
            m_VirtualJoystick.gameObject.SetActive(false);
            m_MobileFirePrimary.gameObject.SetActive(false);
            m_MobileFireSecondary.gameObject.SetActive(false);
        }
        else
        {
            m_VirtualJoystick.gameObject.SetActive(true);
            m_MobileFirePrimary.gameObject.SetActive(true);
            m_MobileFireSecondary.gameObject.SetActive(true);
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
        var dir = m_VirtualJoystick.Value;

        m_TargetShip.ThrustControl = dir.y;
        m_TargetShip.TorqueControl = -dir.x;

        if (m_MobileFirePrimary.IsHold)
        {
            m_TargetShip.Fire(TurretMode.Primary);
        }

        if (m_MobileFireSecondary.IsHold)
        {
            m_TargetShip.Fire(TurretMode.Secondary);
        }

        
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

        if (Input.GetKey(KeyCode.Space))
        {
            m_TargetShip.Fire(TurretMode.Primary);
        }
        
        if (Input.GetKey(KeyCode.X))
        {
            m_TargetShip.Fire(TurretMode.Secondary);
        }

        m_TargetShip.ThrustControl = thrust;
        m_TargetShip.TorqueControl = torque;
    }    
}
