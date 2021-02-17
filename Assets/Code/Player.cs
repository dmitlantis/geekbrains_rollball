using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code
{
    internal sealed class Player : IApplyDamage, IGetDamage, ICloneable, IEnumerable, IDisposable
    {
        public float Hp { get; private set; }
        public readonly Health Health;

        private readonly List<TypeExample> _typeExamples = new List<TypeExample> {TypeExample.None, TypeExample.First, TypeExample.Second};
        
        public TypeExample this[string value]
        {
            get
            {
                switch (value)
                {
                    case "None":
                        return TypeExample.None;
                    case "First":
                        return TypeExample.First;
                    case "Second":
                        return TypeExample.Second;
                    default: return TypeExample.None;
                }
            }
        }
        
        public Player(Health health)
        {
            Health = health;
        }

        public void SetHp(float hp)
        {
            Hp = hp;
        }
        
        void IApplyDamage.ApplyDamage()
        {
            Debug.Log($"{typeof(IApplyDamage)}");
        }
        
        void IGetDamage.ApplyDamage()
        {
            Debug.Log($"{typeof(IGetDamage)}");
        }

        public void ApplyDamage()
        {
            Debug.Log($"{typeof(IApplyDamage)} - {typeof(IGetDamage)}");
        }

        public object Clone()
        {
            return new Player(new Health
            {
                Hp = Health.Hp
            });
            return MemberwiseClone();
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var t in _typeExamples)
            {
               yield return t;
            }
        }

        public void Dispose()
        {
            _typeExamples.Clear();
            Health.Dispose();
        }
    }
}
