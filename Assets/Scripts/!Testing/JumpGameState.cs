using UnityEngine;
using System.Collections;

/// <summary>
/// defines states of the jump game 
/// <remarks>jump game currently in development</remarks>
/// </summary>
public class JumpGameState : MonoBehaviour {

    public enum GameStateJump
    {
        IntroducingGame,
        Starting,
        Started,
        Ended
    }

    public GameStateJump gameState;
} 