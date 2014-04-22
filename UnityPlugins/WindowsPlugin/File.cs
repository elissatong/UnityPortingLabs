using System;
using System.Collections.Generic;
using System.IO;


namespace UnityPlugins
{
	public class File
	{
		public static bool Exists(string filename, string path = "")
		{
			return false;
		}

        public static void CreateFile(string filename, string content, string path = "")
        {
            
        }

        public static void CreateFile(string filename, byte[] content, string path = "")
        {
            
        }

		public static string GetTextFrom(string filename, string path = "")
		{
			return "Not supported";
		}

		public static Stream GetBinaryReadStream(string filename, string path = "")
		{
			return null;
		}

		public static Stream GetBinaryWriteStream(string filename, string path = "")
		{
			return null;
		}
	}


	public class Directory
	{
		public static void DeleteRecursively(string folderName)
		{
			
		}

		public static void CreateFolder(string path)
		{
			
		}

		public static string[] GetFolders(string path = "")
		{
			return null;
		}

		public static string[] GetFiles(string path = "")
		{
			return null;
		}
	}

}