using System;
using System.Runtime.InteropServices;

namespace RawPrint
{
    // ReSharper disable InconsistentNaming
    // ReSharper disable FieldCanBeMadeReadOnly.Local
    [Flags]
    public enum PRINTER_ACCESS_MASK : uint
    {
        PRINTER_ACCESS_ADMINISTER = 0x00000004,
        PRINTER_ACCESS_USE = 0x00000008,
        PRINTER_ACCESS_MANAGE_LIMITED = 0x00000040,
        PRINTER_ALL_ACCESS = 0x000F000C,
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct PRINTER_DEFAULTS
    {
        public string pDatatype;

        private IntPtr pDevMode;

        public PRINTER_ACCESS_MASK DesiredPrinterAccess;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DOC_INFO_1
    {
        public string pDocName;

        public string pOutputFile;

        public string pDataType;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FILETIME
    {
        public uint DateTimeLow;
        public uint DateTimeHigh;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DRIVER_INFO_8
    {
        public uint cVersion;

        public string pName;

        public string pEnvironment;

        public string pDriverPath;

        public string pDataFile;

        public string pConfigFile;

        public string pHelpFile;

        public IntPtr pDependentFiles;

        public string pMonitorName;

        public string pDefaultDataType;

        public string pszzPreviousNames;

        FILETIME ftDriverDate;

        UInt64 dwlDriverVersion;

        public string pszMfgName;

        public string pszOEMUrl;

        public string pszHardwareID;

        public string pszProvider;

        public string pszPrintProcessor;

        public string pszVendorSetup;

        public string pszzColorProfiles;

        public string pszInfPath;

        public uint dwPrinterDriverAttributes;

        public string pszzCoreDriverDependencies;

        FILETIME ftMinInboxDriverVerDate;

        UInt64 dwlMinInboxDriverVerVersion;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct PRINTER_INFO_2
    {
        [MarshalAs(UnmanagedType.LPTStr)]
        string pServerName;

        [MarshalAs(UnmanagedType.LPTStr)]
        public string pPrinterName;

        [MarshalAs(UnmanagedType.LPTStr)]
        string pShareName;

        [MarshalAs(UnmanagedType.LPTStr)]
        public string pPortName;

        [MarshalAs(UnmanagedType.LPTStr)]
        public string pDriverName;

        [MarshalAs(UnmanagedType.LPTStr)]
        string pComment;

        [MarshalAs(UnmanagedType.LPTStr)]
        string pLocation;

        IntPtr pDevMode;

        [MarshalAs(UnmanagedType.LPTStr)]
        string pSepFile;

        [MarshalAs(UnmanagedType.LPTStr)]
        string pPrintProcessor;

        [MarshalAs(UnmanagedType.LPTStr)]
        string pDatatype;

        [MarshalAs(UnmanagedType.LPTStr)]
        string pParameters;

        IntPtr pSecurityDescriptor;

        uint Attributes;

        uint Priority;

        uint DefaultPriority;

        uint StartTime;

        uint UntilTime;

        uint Status;

        uint cJobs;

        uint AveragePPM;
    }

    class NativeMethods
    {
        [DllImport("winspool.drv", SetLastError = true)]
        public static extern int ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.drv", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern int GetPrinterDriver(IntPtr hPrinter, string pEnvironment, int Level, IntPtr pDriverInfo, int cbBuf, ref int pcbNeeded);

        [DllImport("winspool.drv", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern int StartDocPrinterW(IntPtr hPrinter, uint level, [MarshalAs(UnmanagedType.Struct)] ref DOC_INFO_1 di1);

        [DllImport("winspool.drv", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern int EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.drv", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern int StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.drv", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern int EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.drv", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern int WritePrinter(IntPtr hPrinter, [In, Out] byte[] pBuf, int cbBuf, ref int pcWritten);

        [DllImport("winspool.drv", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern int OpenPrinterW(string pPrinterName, out IntPtr phPrinter, ref PRINTER_DEFAULTS pDefault);

    }


    // ReSharper restore FieldCanBeMadeReadOnly.Local
    // ReSharper restore InconsistentNaming
}
