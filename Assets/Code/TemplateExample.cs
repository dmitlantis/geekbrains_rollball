using UnityEngine;

namespace Code
{
    internal sealed class TemplateExample
    {
        public void Start(IUserFactory factory)
        {
            Enemy<float> enemy = factory.Create<Enemy<float>, float>(4.0f);
            User<int> user = factory.Create<User<int>, int>(4);
            return;
            Display(1);
            Display(1d);
            Display(1m);
            Display(1.0f);
        }

        private void Display<T>(T value)
        {
            Debug.Log(value);
        }
    }

    public sealed class User<T> : IUnit<T>
    {
        public T Hp { get; set; }
    }

    public sealed class Enemy<T> : IUnit<T>
    {
        public T Hp { get; set; }
    }

    public interface IUserFactory
    {
        T Create<T, T2>(T2 hp) where T : IUnit<T2>, new()
            where T2 : struct;
    }

    public sealed class UserFactory : IUserFactory
    {
        public T Create<T, T2>(T2 hp) where T : IUnit<T2>, new()
        where T2 : struct
        {
            var result = new T();
            result.Hp = hp;
            return result;
        }
    }

    public interface IUnit<T>
    {
        T Hp { get; set; }
    }
}
