using Microsoft.VisualBasic.FileIO;

/* 12/7/2020
 * Uses some methods from the VisualBasic
 * library to move files to the recyling
 * bin.
 * 
 * Zach Robinson
 */

namespace System.IO
{
    public static class RecycleExtensions
    {
        public static void FileRecycle(this string file)
        {
            FileSystem.DeleteFile(file,
               UIOption.OnlyErrorDialogs,
               RecycleOption.SendToRecycleBin);
        }

        public static void DirectoryRecycle(this string path)
        {
            FileSystem.DeleteDirectory(path,
               UIOption.OnlyErrorDialogs,
               RecycleOption.SendToRecycleBin);
        }
    }
}
