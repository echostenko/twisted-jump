using Data;

namespace Player
{
    public class PlayerStats
    {
        public PlayerData PlayerData { get; }
        public float JumpForce { get; private set; }
        public float Speed { get; }

        public PlayerStats(PlayerData playerData)
        {
            PlayerData = playerData;
            JumpForce = playerData.jumpForce;
            Speed = playerData.speed;
        }
        
        public void BuffJump() => 
            JumpForce += 0.2f;

        public void DebuffJump() => 
            JumpForce -= 0.2f;
    }
}