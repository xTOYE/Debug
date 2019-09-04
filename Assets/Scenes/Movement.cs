using UnityEngine;
//Errors =  /11
namespace Debugging.Player
{
    [AddComponentMenu("RPG/Player/Movement")]
    [RequireComponent(typeof(CharacterController))]
    public class Movement : MonoBehaviour
    {
        [Header("Speed Vars")]
        //Value Variables 
        public float moveSpeed;
        public float walkSpeed, runSpeed, crouchSpeed, jumpSpeed;
        private float _gravity = 20.0f;
        //Struct - Contains Multiple Variables (eg...3 floats)
        private Vector3 _moveDir;
        //Reference Variable
        private CharacterController _charC;
        private void Start()
        {
            _charC = GetComponent<CharacterController>();
        }
        private void Update()
        {
            Move();
        }
        private void Move()
        {
            //if we are on the ground
            if (_charC.isGrounded)
            {
                //set speed
                if (Input.GetButton("Sprint"))
                {
                    moveSpeed = runSpeed;
                }
                else if (Input.GetButton("Crouch"))
                {
                    moveSpeed = crouchSpeed;
                }
                else
                {
                    moveSpeed = walkSpeed;
                }
                //calculate movement direction based off inputs
                _moveDir = transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * moveSpeed);
                if (Input.GetButton("Jump"))
                {
                    _moveDir.y = jumpSpeed;
                }
            }
            //Regardless if we are grounded or not
            //apply gravity
            _moveDir.y -= _gravity * Time.deltaTime;
            //apply movement
            _charC.Move(_moveDir * Time.deltaTime);
        }
        }
    
}
