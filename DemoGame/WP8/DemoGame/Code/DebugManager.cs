// DebugManager.cs
// For testing different Windows Phone functionalities
// ie: DebugManager.Instance.CreateFolder();

#define FILEIO

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


#if FILEIO
    using Windows.Storage;
    using System.Threading.Tasks;
#endif

namespace DemoGame.Code
{
    public class DebugManager
    {
        private static DebugManager instance = new DebugManager();
        public static DebugManager Instance
        {
            get { return instance; }
            set { instance = value; }
        }


#if FILEIO
        public void CreateFolder()
        {
            StorageFolder local = Windows.Storage.ApplicationData.Current.LocalFolder;

            var task = CreateFolder(local, "TestOutput2");
            task.Wait();

        }
        public static async Task CreateFolder(StorageFolder folder, string path)
        {
            string[] folderNames = path.Split(new char[] { '/' });

            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFolder current = localFolder;

            foreach (string folderName in folderNames)
            {
                current = await current.CreateFolderAsync(folderName, CreationCollisionOption.OpenIfExists);
            }
        }
#endif // FILEIO

    }
}
