using Player;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(CoyoteTime))]
public class PlayerInput : MonoBehaviour
{
 [HideInInspector] public bool jump;
 [HideInInspector] public bool longJump;
 [HideInInspector] public Vector2 moveVector;
 [HideInInspector] public bool run;
 [HideInInspector] public bool dash;
 [HideInInspector] public bool attack;
 private CoyoteTime m_Coyote;

 private void Awake()
    {
        m_Coyote = GetComponent<CoyoteTime>();
    }

 void Update()
    {
     //Move
     moveVector.x = (Keyboard.current.aKey.isPressed ? -1f : 0f) + (Keyboard.current.dKey.isPressed ? 1f : 0f);
     moveVector.y = (Keyboard.current.sKey.isPressed ? 0f : -1f) + (Keyboard.current.wKey.isPressed ? 0f : 1f);

     //Run
     run = Keyboard.current.shiftKey.isPressed;

     //Jump
     jump = Keyboard.current.spaceKey.wasPressedThisFrame;
     longJump = Keyboard.current.spaceKey.isPressed;

     //Dash
     dash = Keyboard.current.spaceKey.wasPressedThisFrame;
     

     // Attack
     attack = Mouse.current.leftButton.wasPressedThisFrame;
     
     //Load Levels
     if (Keyboard.current.escapeKey.isPressed)
     {
         if (Keyboard.current.bKey.wasPressedThisFrame)
         {
             SceneManager.LoadScene("BossLevel");
         }
         else if (Keyboard.current.vKey.wasPressedThisFrame)
         {
             SceneManager.LoadScene("Level 2");
         }
         else if (Keyboard.current.cKey.wasPressedThisFrame)
         {
             SceneManager.LoadScene("Level1 1");
         }
         else if (Keyboard.current.xKey.wasPressedThisFrame)
         {
             SceneManager.LoadScene("Title Scene");
         }
         else if (Keyboard.current.zKey.wasPressedThisFrame)
         {
             SceneManager.LoadScene("Credits");
         }
     }
    }
}