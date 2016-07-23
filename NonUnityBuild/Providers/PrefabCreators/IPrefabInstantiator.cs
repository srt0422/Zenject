#if !NOT_UNITY3D || DEBUG || !DEBUG

using System.Collections.Generic;
using UnityEngine;

namespace Zenject
{
    public interface IPrefabInstantiator
    {
        List<TypeValuePair> ExtraArguments
        {
            get;
        }

        string GameObjectName
        {
            get;
        }

        string GameObjectGroupName
        {
            get;
        }

        IEnumerator<GameObject> Instantiate(List<TypeValuePair> args);

        UnityEngine.Object GetPrefab();
    }
}

#endif
