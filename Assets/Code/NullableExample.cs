using UnityEngine;

namespace Code
{
    internal sealed class NullableExample
    {
        private void Main()
        {
           Save(null, null); 
        }
        
        private void Save(Player player, int? hp) // Nullable<int> hp
        {
            if (hp.HasValue)
            {
                Debug.Log(hp.Value);
            }

            var pr = player ?? new Player();

            if (player != null)
            {
                if (player.Health != null)
                {
                    var hpNew = player.Health.Hp;
                }
            }
            
            
            var hpNewNew = player?.Health?.Hp;
            Debug.Log(hpNewNew);
        }

        internal class Player
        {
            public Health Health;
        }
    }
}
