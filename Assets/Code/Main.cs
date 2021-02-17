using UnityEngine;
using static UnityEngine.Debug;

namespace Code
{
    internal sealed class Main : MonoBehaviour
    {
        private void Start()
        {
            Player player = new Player(new Health());
            ((IApplyDamage)player).ApplyDamage();
            ((IGetDamage)player).ApplyDamage();
            player.ApplyDamage();
            player.SetHp(100.0f);

            Player playerNew = (Player)player.Clone();
            playerNew.SetHp(10.0f);
            Log(player.Hp);
            Log(player.Health.GetHashCode());
            Log(playerNew.Hp);
            Log(playerNew.Health.GetHashCode());

            foreach (var p in playerNew)
            {
                Log(p);
            }

            using (var p = new Player(new Health()))
            {
                Log(p.Health);
            }
            
            Log(playerNew["First"]);
        }
    }
}
