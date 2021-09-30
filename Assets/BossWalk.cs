using UnityEngine;

public class BossWalk : StateMachineBehaviour
{
    private Transform m_Player;
    private Rigidbody2D m_Rigidbody2D;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float biteRange = 3f;
    BossFlipper bossFlipper;

    private static readonly int Bite = Animator.StringToHash("Bite");

    private static readonly int Slam = Animator.StringToHash("Slam");
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_Player = GameObject.FindGameObjectWithTag("Player").transform;
        m_Rigidbody2D = animator.GetComponent<Rigidbody2D>();

        bossFlipper = animator.GetComponent<BossFlipper>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        bossFlipper.LookAtPlayer();
        
        //|| Vector2.Distance(m_Player.position, m_Rigidbody2D.position) >= spikeRange)
        // Walk Towards Player
        var position = m_Rigidbody2D.position;
        Vector2 target = new Vector2(m_Player.position.x, position.y);
        Vector2 newPosition = Vector2.MoveTowards(position, target, speed * Time.fixedDeltaTime);
        
        m_Rigidbody2D.MovePosition(newPosition);
        
        
        

    }
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger(Bite);
        animator.ResetTrigger(Slam);
    }
}
