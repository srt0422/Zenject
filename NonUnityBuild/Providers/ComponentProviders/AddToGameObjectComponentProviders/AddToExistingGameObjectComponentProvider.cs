#if !NOT_UNITY3D || DEBUG || !DEBUG

using System;
using System.Collections.Generic;
using UnityEngine;

namespace Zenject
{
    public class AddToExistingGameObjectComponentProvider : AddToGameObjectComponentProviderBase
    {
        readonly GameObject _gameObject;

        public AddToExistingGameObjectComponentProvider(
            GameObject gameObject, DiContainer container, Type componentType,
            string concreteIdentifier, List<TypeValuePair> extraArguments)
            : base(container, componentType, concreteIdentifier, extraArguments)
        {
            _gameObject = gameObject;
        }

        protected override GameObject GetGameObject(InjectContext context)
        {
            return _gameObject;
        }
    }
}

#endif
