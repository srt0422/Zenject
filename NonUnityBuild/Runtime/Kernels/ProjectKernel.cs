#if !NOT_UNITY3D || DEBUG || !DEBUG

namespace Zenject
{
    public class ProjectKernel : MonoKernel
    {
        // Intentional left empty
        // We just need this class to exist so we can make ProjectKernel have a higher
        // script execution order
    }
}

#endif
