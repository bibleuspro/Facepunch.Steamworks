using System;
using System.Runtime.InteropServices;

namespace SteamNative
{
	public unsafe class SteamUnifiedMessages
	{
		internal Platform.Interface _pi;
		
		public SteamUnifiedMessages( IntPtr pointer )
		{
			if ( Platform.IsWindows64 ) _pi = new Platform.Win64( pointer );
			else if ( Platform.IsWindows32 ) _pi = new Platform.Win32( pointer );
			else if ( Platform.IsLinux32 ) _pi = new Platform.Linux32( pointer );
			else if ( Platform.IsLinux64 ) _pi = new Platform.Linux64( pointer );
			else if ( Platform.IsOsx ) _pi = new Platform.Mac( pointer );
		}
		
		public bool IsValid{ get{ return _pi != null && _pi.IsValid; } }
		
		// bool
		public bool GetMethodResponseData( ClientUnifiedMessageHandle hHandle /*ClientUnifiedMessageHandle*/, IntPtr pResponseBuffer /*void **/, uint unResponseBufferSize /*uint32*/, bool bAutoRelease /*bool*/ )
		{
			return _pi.ISteamUnifiedMessages_GetMethodResponseData( hHandle, (IntPtr) pResponseBuffer, unResponseBufferSize, bAutoRelease );
		}
		
		// bool
		public bool GetMethodResponseInfo( ClientUnifiedMessageHandle hHandle /*ClientUnifiedMessageHandle*/, out uint punResponseSize /*uint32 **/, out Result peResult /*EResult **/ )
		{
			return _pi.ISteamUnifiedMessages_GetMethodResponseInfo( hHandle, out punResponseSize, out peResult );
		}
		
		// bool
		public bool ReleaseMethod( ClientUnifiedMessageHandle hHandle /*ClientUnifiedMessageHandle*/ )
		{
			return _pi.ISteamUnifiedMessages_ReleaseMethod( hHandle );
		}
		
		// ClientUnifiedMessageHandle
		public ClientUnifiedMessageHandle SendMethod( string pchServiceMethod /*const char **/, IntPtr pRequestBuffer /*const void **/, uint unRequestBufferSize /*uint32*/, ulong unContext /*uint64*/ )
		{
			return _pi.ISteamUnifiedMessages_SendMethod( pchServiceMethod, (IntPtr) pRequestBuffer, unRequestBufferSize, unContext );
		}
		
		// bool
		public bool SendNotification( string pchServiceNotification /*const char **/, IntPtr pNotificationBuffer /*const void **/, uint unNotificationBufferSize /*uint32*/ )
		{
			return _pi.ISteamUnifiedMessages_SendNotification( pchServiceNotification, (IntPtr) pNotificationBuffer, unNotificationBufferSize );
		}
		
	}
}