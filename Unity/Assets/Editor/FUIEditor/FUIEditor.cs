using UnityEditor;

namespace FUIEditor
{
    public static class FUIEditor
    {
        [MenuItem("Tools/FUI代码生成")]
        public static void FuiCodeSpawn()
        {
            FUICodeSpawner.ParseAndSpawnCode();
        }

    }
}