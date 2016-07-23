#if !NOT_UNITY3D || DEBUG || !DEBUG

using ModestTree;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Zenject
{
    [System.Diagnostics.DebuggerStepThrough]
    public class SceneDecoratorContext : MonoBehaviour
    {
        public string SceneName;

        [SerializeField]
        public DecoratorInstaller[] DecoratorInstallers;

        [SerializeField]
        public MonoInstaller[] PreInstallers;

        [SerializeField]
        public MonoInstaller[] PostInstallers;

        public void Awake()
        {
            // We always want to initialize ProjectContext as early as possible
            ProjectContext.Instance.EnsureIsInitialized();

            SceneContext.BeforeInstallHooks += AddPreBindings;
            SceneContext.AfterInstallHooks += AddPostBindings;

            SceneContext.DecoratedScenes.Add(this.gameObject.scene);

            if (ShouldLoadNextScene())
            {
                SceneManager.LoadScene(SceneName, LoadSceneMode.Additive);
            }
        }

        bool ShouldLoadNextScene()
        {
            // This is the only way I can figure out to do this
            // We can't use GetSceneByName(SceneName).isLoaded since that doesn't work in Awake
            return GetSceneIndex(this.gameObject.scene) == SceneManager.sceneCount - 1;
        }

        int GetSceneIndex(Scene scene)
        {
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                if (SceneManager.GetSceneAt(i) == scene)
                {
                    return i;
                }
            }

            throw Assert.CreateException();
        }

        public void AddPreBindings(DiContainer container)
        {
            foreach (var installer in PreInstallers)
            {
                container.Inject(installer);
                installer.InstallBindings();
            }

            ProcessDecoratorInstallers(container, true);
        }

        public void AddPostBindings(DiContainer container)
        {
            foreach (var installer in PostInstallers)
            {
                container.Inject(installer);
                installer.InstallBindings();
            }

            ProcessDecoratorInstallers(container, false);
        }

        void ProcessDecoratorInstallers(DiContainer container, bool isBefore)
        {
            if (DecoratorInstallers == null)
            {
                return;
            }

            foreach (var installer in DecoratorInstallers)
            {
                Assert.IsNotNull(installer, "Found null installer in SceneDecoratorContext");

                if (installer.enabled)
                {
                    container.Inject(installer);

                    if (isBefore)
                    {
                        installer.PreInstallBindings();
                    }
                    else
                    {
                        installer.PostInstallBindings();
                    }
                }
            }
        }
    }
}

#endif