#if !NOT_UNITY3D || DEBUG || !DEBUG

namespace Zenject
{
    public interface IPrefabProvider
    {
        UnityEngine.Object GetPrefab();
    }
}

#endif

