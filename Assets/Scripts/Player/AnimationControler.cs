using UnityEngine;

public class AnimationControler : MonoBehaviour {

    private Animator            m_animator;
    private Rigidbody2D         m_body2d;
    private bool                m_combatIdle = false;
    private bool                m_isDead = false;

    private void OnEnable()
    {
        PlayerHealthManager.OnPlayerTakeDamage += PlayHurtAnimation;
        HealthBarManager.OnPlayerDeath += PlayDeathAnimation;
    }
    private void OnDisable()
    {
        PlayerHealthManager.OnPlayerTakeDamage += PlayHurtAnimation;
        HealthBarManager.OnPlayerDeath -= PlayDeathAnimation;


    }

    // Use this for initialization
    void Start () {
        m_animator = GetComponent<Animator>();
        m_body2d = GetComponent<Rigidbody2D>();
       
    }
	
	// Update is called once per frame
	void Update () {

        // -- Player input and movement --
        float inputX = Input.GetAxis("Horizontal");

        // Swap direction of sprite depending on walk direction
        if (inputX > 0)
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (inputX < 0)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }


        //Set AirSpeed in animator
        m_animator.SetFloat("AirSpeed", m_body2d.velocity.y);


        //Run
        if (Mathf.Abs(inputX) > Mathf.Epsilon)
            m_animator.SetInteger("AnimState", 2);

        //Combat Idle
        else if (m_combatIdle)
            m_animator.SetInteger("AnimState", 1);

        //Idle
        else
            m_animator.SetInteger("AnimState", 0);
    }

    private void PlayHurtAnimation(float a)
    {
        m_animator.Play("Hurt");
    }
    private void PlayDeathAnimation()
    {
        if (!m_isDead)
            m_animator.SetTrigger("Death");

        m_isDead = !m_isDead;

    }
}
