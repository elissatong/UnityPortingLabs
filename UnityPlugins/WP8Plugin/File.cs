// Modified from sample code: http://answers.unity3d.com/questions/579641/handling-the-lack-of-systemio-classes-in-windows-8.html


using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;


	public class File
	{
        //public static void ReadAllFile
		public static bool Exists(string filename, string path = "")
		{
			var task = FileHandling.FileExists(ApplicationData.Current.LocalFolder, filename, path);
			task.Wait();
			return task.Result;
		}

		public static void CreateFile(string filename, string content, string path = "")
		{
			var task = FileHandling.CreateFile(ApplicationData.Current.LocalFolder, filename, path, content);
			task.Wait();
		}

		public static void CreateFile(string filename, byte [] content, string path = "")
		{
			var task = FileHandling.CreateFile(ApplicationData.Current.LocalFolder, filename, path, content);
			task.Wait();
		}

		public static string GetTextFrom(string filename, string path = "")
		{
			var task = FileHandling.GetTextFromFile(ApplicationData.Current.LocalFolder, filename, path);
			task.Wait();
			return task.Result;
		}

		public static Stream GetBinaryReadStream(string filename, string path = "")
		{
			var task = FileHandling.GetReadStreamFrom(ApplicationData.Current.LocalFolder, filename, path);
			task.Wait();
			return task.Result;
		}

		public static Stream GetBinaryWriteStream(string filename, string path = "")
		{
			var task = FileHandling.GetWriteStreamFrom(ApplicationData.Current.LocalFolder, filename, path);
			task.Wait();
			return task.Result;
		}

	}


	public class Directory
	{
		public static void DeleteRecursively(string folderName)
		{
			var task = FileHandling.DeleteFoldersRecursively(ApplicationData.Current.LocalFolder, folderName);
			task.Wait();
		}

		public static void CreateFolder(string path)
		{
			var task = FileHandling.CreateFolder(ApplicationData.Current.LocalFolder, path);
			task.Wait();
		}

		public static string[] GetFolders(string path = "")
		{
			var task = FileHandling.GetFoldersInFolder(ApplicationData.Current.LocalFolder, path);
			task.Wait();
			return task.Result;
		}

		public static string[] GetFiles(string path = "")
		{
			var task = FileHandling.GetFilesInFolder(ApplicationData.Current.LocalFolder, path);
			task.Wait();
			return task.Result;
		}
	}


	static class FileHandling
	{
		public static async Task<bool> FileExists(StorageFolder folder, string filename, string path)
		{
			try {
				folder = await navigateFrom(folder, path);
				var file = await folder.GetFileAsync(filename).AsTask().ConfigureAwait(false);
				return true;
			} catch (Exception) {
				return false;
			}
		}

		public static async Task<string> CreateFile(StorageFolder folder, string filename, string path, string contents)
		{
			folder = await navigateFrom(folder, path);
			StorageFile file = await folder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);

			using (IRandomAccessStream stream = await file.OpenAsync(FileAccessMode.ReadWrite))
			{
				using (DataWriter writer = new DataWriter(stream))
				{
					writer.WriteString(contents);
					await writer.StoreAsync();
				}
			}

			return file.Path;
		}

		public static async Task<string> CreateFile(StorageFolder folder, string filename, string path, byte[] contents)
		{
			folder = await navigateFrom(folder, path);
			StorageFile file = await folder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);

			using (IRandomAccessStream stream = await file.OpenAsync(FileAccessMode.ReadWrite))
			{
				using (DataWriter writer = new DataWriter(stream))
				{
					writer.WriteBytes(contents);
					await writer.StoreAsync();
				}
			}

			return file.Path;
		}

		

		public static async Task<string> GetTextFromFile(StorageFolder folder, string filename, string path)
		{
			folder = await navigateFrom(folder, path);
			StorageFile textFile = await folder.GetFileAsync(filename);

			string contents;

			using (IRandomAccessStream textStream = await textFile.OpenReadAsync())
			{
				using (DataReader textReader = new DataReader(textStream))
				{
					uint textLength = (uint)textStream.Size;
					await textReader.LoadAsync(textLength);
					contents = textReader.ReadString(textLength);
				}
			}
			return contents;
		}

		public static async Task<string[]> GetFoldersInFolder(StorageFolder folder, string path)
		{
			folder = await FileHandling.navigateFrom(folder, path);
			return getStorageItemsNames(await folder.GetFoldersAsync());
		}

		public static async Task<string[]> GetFilesInFolder(StorageFolder folder, string path)
		{
			folder = await FileHandling.navigateFrom(folder, path);
			return getStorageItemsNames(await folder.GetFilesAsync());
		}

		private static async Task<string[]> getFoldersInFolder(StorageFolder folder)
		{
			var foldersInFolder = await folder.GetFoldersAsync();
			return getStorageItemsNames(foldersInFolder);
		}

		private static async Task<string[]> getFilesInFolder(StorageFolder folder)
		{
			var filesInFolder = await folder.GetFilesAsync();
			return getStorageItemsNames(filesInFolder);
		}

		private static string[] getStorageItemsNames(IReadOnlyList<IStorageItem> items)
		{
			string[] files = new string[items.Count];

			int i = 0;
			foreach (IStorageItem folder in items)
			{
				files[i++] = folder.Name;
			}

			return files;
		}

		private static async Task<StorageFolder> navigateFrom(StorageFolder folder, string path, bool assumeLastIsFile = false)
		{
			string[] folderNames = path.Split(new char[] { '/' });
			StorageFolder current = folder;

			int limit = folderNames.Length;
			if (assumeLastIsFile)
			{
				limit--;
			}

			for (int i = 0; i < limit; i++)
			{
				if (folderNames[i].Length > 0)
				{
					current = await current.GetFolderAsync(folderNames[i]);
				}
			}

			return current;
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

		public static async Task DeleteFoldersRecursively(StorageFolder folder, string folderName)
		{
			folder = await folder.GetFolderAsync(folderName);
			await folder.DeleteAsync();
		}

		public static async Task<Stream> GetReadStreamFrom(StorageFolder folder, string filename, string path)
		{
			folder = await navigateFrom(folder, path);
			StorageFile file = await folder.GetFileAsync(filename);
			return await file.OpenStreamForReadAsync();
		}

		public static async Task<Stream> GetWriteStreamFrom(StorageFolder folder, string filename, string path)
		{
			folder = await navigateFrom(folder, path);
			StorageFile file = await folder.CreateFileAsync(filename, CreationCollisionOption.OpenIfExists);
			return await file.OpenStreamForWriteAsync();
		}

        public static async Task<Stream> ReadAllBytes(String text)
        {
            //folder = await navigateFrom(folder, path);
            //StorageFile file = await folder.CreateFileAsync(filename, CreationCollisionOption.OpenIfExists);
            return await file.OpenStreamForWriteAsync();

        }
		
	}
}
