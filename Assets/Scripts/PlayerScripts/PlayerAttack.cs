using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ComboState
{
    NONE,
    PUNCH_1,
    PUNCH_2,
    PUNCH_3,
    KICK_1,
    KICK_2

}

public class PlayerAttack : MonoBehaviour
{
    private CharacterAnimation player_Animation;
    // Start is called before the first frame update
    private bool activateTimerToReset;

    private float default_Combo_Timer = 0.4f;
    private float current_Combo_Timer;

    private ComboState current_Combo_State;
    void Awake()
    {
        player_Animation = GetComponentInChildren<CharacterAnimation>();
    }
    void Start()
    {
        current_Combo_Timer = default_Combo_Timer;
        current_Combo_State = ComboState.NONE;

    }

    // Update is called once per frame
    void Update()
    {
        ComboAttacks();
        ResetComboState();
    }
    void ComboAttacks()
    {
        //Input.GetKeyDown will only detect it once in the frame that is pushed // GetKey will be detected in every frame that the key is pushed 
        //same for Input.GetKeyUp 
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (current_Combo_State == ComboState.PUNCH_3 ||
                current_Combo_State == ComboState.KICK_1 ||
                current_Combo_State == ComboState.KICK_2)
            {
                return;
            }


            current_Combo_State++;
            //player_Animation.Punch_1();
            activateTimerToReset = true;
            current_Combo_Timer = default_Combo_Timer;

            if (current_Combo_State == ComboState.PUNCH_1)
            {
                player_Animation.Punch_1();
            }


            if (current_Combo_State == ComboState.PUNCH_2)
            {
                player_Animation.Punch_2();
            }


            if (current_Combo_State == ComboState.PUNCH_3)
            {
                player_Animation.Punch_3();
            }
        } //if punch




        if (Input.GetKeyDown(KeyCode.X))
        {
            //if it is in the kick 2 or punch 3 state exit function
            if (current_Combo_State == ComboState.KICK_2 ||
                current_Combo_State == ComboState.PUNCH_3)
            {
                return;
            }

            //if its in any of the below states transition to kick 1
            if (current_Combo_State == ComboState.NONE ||
                current_Combo_State == ComboState.PUNCH_1 ||
                current_Combo_State == ComboState.PUNCH_2)
            {
                current_Combo_State = ComboState.KICK_1;
            }
            //if it is not in any of the above states and state is kick 1 transition to the next state
            else if (current_Combo_State == ComboState.KICK_1)
            {
                current_Combo_State++;
            }

            activateTimerToReset = true;
            current_Combo_Timer = default_Combo_Timer;

            if (current_Combo_State == ComboState.KICK_1)
            {
                player_Animation.Kick_1();
            }

            if (current_Combo_State == ComboState.KICK_2)
            {
                player_Animation.Kick_2();
            }


        } //if kick




        if (Input.GetKeyDown(KeyCode.C))
        {
            player_Animation.Punch_3();
        }
    } //combo attacks

    void ResetComboState()
    {
        if (activateTimerToReset)
        {
            current_Combo_Timer -= Time.deltaTime;

            if (current_Combo_Timer <= 0f)
            {
                current_Combo_State = ComboState.NONE;
                activateTimerToReset = false;
                current_Combo_Timer = default_Combo_Timer;
            }

        }
    } //reset combo state

} //class
