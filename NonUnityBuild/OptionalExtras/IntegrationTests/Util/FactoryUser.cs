using System;
using Zenject;
using UnityEngine;
using System.Linq;

namespace ModestTree.Tests.Zenject
{
    public class FactoryUser<TValue, TFactory> : IInitializable
        where TFactory : Factory<TValue>
    {
        readonly TFactory _factory;

        public FactoryUser(TFactory factory)
        {
            _factory = factory;
        }

        public void Initialize()
        {
            Assert.IsNotNull(_factory.Create());
        }
    }
}

