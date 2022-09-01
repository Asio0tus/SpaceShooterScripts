using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Spaceship : Destructible
{
    /// <summary>
    /// Mass for automatic set rigid
    /// </summary>
    [Header("Space ship")]
    [SerializeField] private float m_Mass;

    /// <summary>
    /// Pushing force forward
    /// </summary>
    [SerializeField] private float m_Thrust;

    /// <summary>
    /// Rotating force
    /// </summary>
    [SerializeField] private float m_Mobility;

    /// <summary>
    /// Max line speed
    /// </summary>
    [SerializeField] private float m_MaxLinearVelocity;

    /// <summary>
    /// Max rotational speed. degrees per second
    /// </summary>
    [SerializeField] private float m_MaxAngularVelocity;

    /// <summary>
    /// Save link to rigid
    /// </summary>
    private Rigidbody2D m_Rigid;

    #region Public API

    /// <summary>
    /// Control linear thrust. -1.0 to +1.0
    /// </summary>
    public float ThrustControl { get; set; }

    /// <summary>
    /// Control rotational thrust. -1.0 to +1.0
    /// </summary>
    public float TorqueControl { get; set; }

    #endregion

    #region Unity Event
    protected override void Start()
    {
        base.Start();

        m_Rigid = GetComponent<Rigidbody2D>();
        m_Rigid.mass = m_Mass;

        m_Rigid.inertia = 1;
    }
       

    private void FixedUpdate()
    {
        UpdateRigidBody();
    }

    #endregion

    /// <summary>
    /// Method adding forces to move spaceship
    /// </summary>
    private void UpdateRigidBody()
    {
        m_Rigid.AddForce(ThrustControl * m_Thrust * transform.up * Time.fixedDeltaTime, ForceMode2D.Force);

        m_Rigid.AddForce(-m_Rigid.velocity * (m_Thrust / m_MaxLinearVelocity) * Time.fixedDeltaTime, ForceMode2D.Force);

        m_Rigid.AddTorque(TorqueControl * m_Mobility * Time.fixedDeltaTime, ForceMode2D.Force);

        m_Rigid.AddTorque(-m_Rigid.angularVelocity * (m_Mobility / m_MaxAngularVelocity) * Time.fixedDeltaTime, ForceMode2D.Force);
    }
}
