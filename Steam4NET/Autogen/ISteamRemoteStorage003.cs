// This file is automatically generated.
using System;
using System.Text;
using System.Runtime.InteropServices;
using Steam4NET.Attributes;

namespace Steam4NET
{

	[InterfaceVersion("STEAMREMOTESTORAGE_INTERFACE_VERSION003")]
	public interface ISteamRemoteStorage003
	{
		[VTableSlot(0)]
		bool FileWrite(string pchFile, Byte[] pvData, Int32 cubData);
		[VTableSlot(1)]
		Int32 FileRead(string pchFile, Byte[] pvData, Int32 cubDataToRead);
		[VTableSlot(2)]
		bool FileForget(string pchFile);
		[VTableSlot(3)]
		bool FileDelete(string pchFile);
		[VTableSlot(4)]
		UInt64 FileShare(string pchFile);
		[VTableSlot(5)]
		bool FileExists(string pchFile);
		[VTableSlot(6)]
		bool FilePersisted(string pchFile);
		[VTableSlot(7)]
		Int32 GetFileSize(string pchFile);
		[VTableSlot(8)]
		Int64 GetFileTimestamp(string pchFile);
		[VTableSlot(9)]
		Int32 GetFileCount();
		[VTableSlot(10)]
		string GetFileNameAndSize(Int32 iFile, ref Int32 pnFileSizeInBytes);
		[VTableSlot(11)]
		bool GetQuota(ref Int32 pnTotalBytes, ref Int32 puAvailableBytes);
		[VTableSlot(12)]
		bool IsCloudEnabledForAccount();
		[VTableSlot(13)]
		bool IsCloudEnabledThisApp();
		[VTableSlot(14)]
		bool SetCloudEnabledThisApp(bool bEnable);
		[VTableSlot(15)]
		UInt64 UGCDownload(UInt64 hContent);
		[VTableSlot(16)]
		bool GetUGCDetails(UInt64 hContent, ref UInt32 pnAppID, StringBuilder ppchName, ref Int32 pnFileSizeInBytes, ref CSteamID pSteamIDOwner);
		[VTableSlot(17)]
		Int32 UGCRead(UInt64 hContent, Byte[] pvData, Int32 cubDataToRead);
		[VTableSlot(18)]
		Int32 GetCachedUGCCount();
		[VTableSlot(19)]
		UInt64 GetCachedUGCHandle(Int32 iCachedContent);
	};
}
