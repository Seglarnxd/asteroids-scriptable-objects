using UnityEditor.VersionControl;
using UnityEngine;
using Variables;

namespace Ship
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Engine : MonoBehaviour
    {
        [SerializeField] private FloatVariable _throttlePower;
        [SerializeField] private FloatVariable _rotationPower;
        
        [SerializeField] private float _throttlePowerSimple;
        [SerializeField] private float _rotationPowerSimple;

        private float speedMultiplier = 1;
        private float powerupTime = 0;
        
        private Rigidbody2D _rigidbody;
        
        private void FixedUpdate()
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                Throttle();
            }
        
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                SteerLeft();
            } 
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                SteerRight();
            }
            if (powerupTime > 0)
            {
                powerupTime -= Time.fixedDeltaTime;
            }
            else if (powerupTime <= 0)
            {
                speedMultiplier = 1;
            }
        }

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }
        
        public void Throttle()
        {
            _rigidbody.AddForce(transform.up * _throttlePower.Value * speedMultiplier, ForceMode2D.Force);
        }

        public void updateSpeed(float speedMultiplier)
        {
            this.speedMultiplier = speedMultiplier;
            powerupTime += 3;
        }

        public void SteerLeft()
        {
            _rigidbody.AddTorque(_rotationPower.Value, ForceMode2D.Force);
        }

        public void SteerRight()
        {
            _rigidbody.AddTorque(-_rotationPower.Value, ForceMode2D.Force);
        }
    }
}
