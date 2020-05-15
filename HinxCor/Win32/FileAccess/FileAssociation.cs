﻿using Microsoft.Win32;
using System;
using System.Runtime.InteropServices;

public class FileAssociation
{
    public string Extension { get; set; }
    public string ProgId { get; set; }
    public string FileTypeDescription { get; set; }
    public string ExecutableFilePath { get; set; }
}

public static class FileAssociationUtil
{
    // needed so that Explorer windows get refreshed after the registry is updated
    [DllImport("Shell32.dll")]
    private static extern int SHChangeNotify(int eventId, int flags, IntPtr item1, IntPtr item2);

    private const int SHCNE_ASSOCCHANGED = 0x8000000;
    private const int SHCNF_FLUSH = 0x1000;

    //public static void EnsureAssociationsSet()
    //{
    //    var filePath = Process.GetCurrentProcess().MainModule.FileName;
    //    EnsureAssociationsSet(
    //        new FileAssociation
    //        {
    //            Extension = ".ucs",
    //            ProgId = "UCS_Editor_File",
    //            FileTypeDescription = "UCS File",
    //            ExecutableFilePath = filePath
    //        });
    //}

    public static void EnsureAssociationsSet(params FileAssociation[] associations)
    {
        bool madeChanges = false;
        foreach (var association in associations)
        {
            madeChanges |= SetAssociation(
                association.Extension,
                association.ProgId,
                association.FileTypeDescription,
                association.ExecutableFilePath);
        }

        if (madeChanges)
        {
            SHChangeNotify(SHCNE_ASSOCCHANGED, SHCNF_FLUSH, IntPtr.Zero, IntPtr.Zero);
        }
    }

    public static bool SetAssociation(string extension, string progId, string fileTypeDescription, string applicationFilePath)
    {
        bool madeChanges = false;
        madeChanges |= SetKeyDefaultValue(@"Software\Classes\" + extension, progId);
        madeChanges |= SetKeyDefaultValue(@"Software\Classes\" + progId, fileTypeDescription);
        madeChanges |= SetKeyDefaultValue($@"Software\Classes\{progId}\shell\open\command", "\"" + applicationFilePath + "\" \"%1\"");
        return madeChanges;
    }

    private static bool SetKeyDefaultValue(string keyPath, string value)
    {
        using (var key = Registry.CurrentUser.CreateSubKey(keyPath))
        {
            if (key.GetValue(null) as string != value)
            {
                key.SetValue(null, value);
                return true;
            }
        }

        return false;
    }



    [Obsolete("Incomplete")]
    public static void SetAssociationAtShell(string Extension, string KeyName, string OpenWith, string FileDescription)
    {
        // The stuff that was above here is basically the same

        // Delete the key instead of trying to change it
        var CurrentUser = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FileExts\\" + Extension, true);
        CurrentUser.DeleteSubKey("UserChoice", false);
        CurrentUser.Close();

        // Tell explorer the file association has been changed
        SHChangeNotify(0x08000000, 0x0000, IntPtr.Zero, IntPtr.Zero);
    }

}
