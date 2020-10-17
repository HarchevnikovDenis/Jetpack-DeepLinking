using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class JetpackContoller : MonoBehaviour
{
    [SerializeField] private ParticleSystem fireEffect;
    [SerializeField] private float jetpackPower;
    private new Rigidbody2D rigidbody;
    private Vector2 jetpackVelocity;

    private bool isEffectReactiveForce
    {
        get
        {
            return fireEffect.isPlaying;
        }
        set
        {
            if(value && !fireEffect.isPlaying)
            {
                // Play Effect
                fireEffect.Play();
            }
            else
            {
                // Stop Effect
                fireEffect.Stop();
            }
        }
    }

    private void Awake()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        jetpackVelocity = new Vector2(0.0f, jetpackPower);
    }

    private void Update()
    {
        if(Mathf.Abs(rigidbody.velocity.y) >= 6.0f)
        {
            rigidbody.velocity = new Vector2(0.0f, Mathf.Clamp(rigidbody.velocity.y, -6.0f, 6.0f));
        }

        if(!GameManager.Instance.isGameActive && isEffectReactiveForce)
        {
            isEffectReactiveForce = false;
        }
    }

    public void FlyTheJetpack()
    {
        if(!isEffectReactiveForce) isEffectReactiveForce = true;

        rigidbody.velocity += jetpackVelocity * Time.deltaTime;
        rigidbody.velocity = new Vector2(0.0f, Mathf.Clamp(rigidbody.velocity.y, -6.0f, 6.0f));
    }

    public void StopFlyTheJetpack()
    {
        if(isEffectReactiveForce) isEffectReactiveForce = false;
    }
}
