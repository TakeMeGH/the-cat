using Unity.VisualScripting;
using UnityEngine;

namespace TC
{
    public class MCController : StateMachine
    {
        [field: Header("Input Reader")]
        [field: SerializeField] public InputReader InputReader;
        [field: Header("Movement Data")]
        [field: SerializeField] public float Speed;
        [field: SerializeField] public float SlowSpeed;

        [field: SerializeField] public float JumpForce;
        [field: SerializeField] public float JumpBufferTime;
        [field: SerializeField] public float MaxJumpAmmount;
        [field: SerializeField] public float FallMultiplier;
        [field: SerializeField] public float MaxFallSpeed;
        [field: SerializeField] public float FallingThreshold;
        [field: SerializeField] public bool IsUsingDelay;
        [field: SerializeField] public float WalkDelay;
        [field: SerializeField] public float WalkDelayIntervalCompensation;


        #region Component
        [field: Header("Component")]
        [field: SerializeField] public GroundDetector GroundDetector;
        [field: SerializeField] public AnimationEventTrigger AnimationEventTrigger;
        [field: SerializeField] public InteractionManager InteractionManager;
        public Rigidbody Rigidbody { get; private set; }
        public Animator Animator { get; private set; }
        public SpriteRenderer SpriteRenderer { get; private set; }
        #endregion
        [field: Header("Event")]
        [field: SerializeField] public VoidEvent OnRespawnEvent;
        [field: SerializeField] public VoidEvent OnGameOverEvent;

        [field: Header("Flash Damaged")]
        [field: SerializeField] public Material FlashMaterial;
        [field: SerializeField] public float FlashDuration;
        [field: SerializeField] public float FlashInterval;
        #region SharedData
        [field: Header("Read Only")]
        public int CurrentJumpAmount;
        public Vector2 MoveDirection { get; private set; }
        public int CurrentHealth;
        #endregion

        #region State
        public MCIdlingState MCIdlingState { get; private set; }
        public MCWalkingState MCWalkingState { get; private set; }
        public MCJumpingState MCJumpingState { get; private set; }
        public MCFallingState MCFallingState { get; private set; }
        public MCInteractingState MCInteractingState { get; private set; }
        public MCDamagedState MCDamagedState { get; private set; }

        #endregion

        void OnEnable()
        {
            InputReader.MoveEvent += MoveMC;
        }

        void OnDisable()
        {
            InputReader.MoveEvent -= MoveMC;

        }

        void Initialize()
        {
            Rigidbody = GetComponent<Rigidbody>();
            Animator = GetComponent<Animator>();
            SpriteRenderer = GetComponent<SpriteRenderer>();

            MCIdlingState = new MCIdlingState(this);
            MCWalkingState = new MCWalkingState(this);
            MCJumpingState = new MCJumpingState(this);
            MCFallingState = new MCFallingState(this);
            MCInteractingState = new MCInteractingState(this);
            MCDamagedState = new MCDamagedState(this);
        }
        void Start()
        {
            Initialize();
            SwitchState(MCIdlingState);
        }

        // void FixedUpdate()
        // {
        //     // RaycastHit hit;
        //     // Vector3 castPos = transform.position;
        //     // castPos.y += 1;
        //     // if (Physics.Raycast(castPos, -transform.up, out hit, Mathf.Infinity, TerrainLayyer))
        //     // {
        //     //     if (hit.collider != null)
        //     //     {
        //     //         Vector3 movePos = transform.position;
        //     //         movePos.y = hit.point.y + GroundDistance;
        //     //         transform.position = movePos;
        //     //     }
        //     // }
        // }

        void MoveMC(Vector2 pos)
        {
            MoveDirection = pos.normalized;

        }

        public void OnPlayerDamaged(int currentHealth)
        {
            CurrentHealth = currentHealth;
            SwitchState(MCDamagedState);
        }

        public void SelfDestroy()
        {
            SpriteRenderer.enabled = false;
        }
    }
}
