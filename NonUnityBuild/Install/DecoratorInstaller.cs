#if !NOT_UNITY3D || DEBUG || !DEBUG

using UnityEngine;

namespace Zenject
{
    [System.Diagnostics.DebuggerStepThrough]
    public abstract class DecoratorInstaller : MonoBehaviour
    {
        [Inject]
        DiContainer _container = null;

        protected DiContainer Container
        {
            get
            {
                return _container;
            }
        }

        public virtual void PreInstallBindings()
        {
        }

        public virtual void PostInstallBindings()
        {
        }
    }
}

//#endif
#endif
