package crc645644bb523fb280e7;


public class NetworkCallbackImpl
	extends android.net.ConnectivityManager.NetworkCallback
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onAvailable:(Landroid/net/Network;)V:GetOnAvailable_Landroid_net_Network_Handler\n" +
			"n_onLost:(Landroid/net/Network;)V:GetOnLost_Landroid_net_Network_Handler\n" +
			"n_onCapabilitiesChanged:(Landroid/net/Network;Landroid/net/NetworkCapabilities;)V:GetOnCapabilitiesChanged_Landroid_net_Network_Landroid_net_NetworkCapabilities_Handler\n" +
			"n_onBlockedStatusChanged:(Landroid/net/Network;Z)V:GetOnBlockedStatusChanged_Landroid_net_Network_ZHandler\n" +
			"";
		mono.android.Runtime.register ("DLUTToolBoxMobile.Droid.NetworkCallbackImpl, DLUTToolBoxMobile.Android", NetworkCallbackImpl.class, __md_methods);
	}


	public NetworkCallbackImpl ()
	{
		super ();
		if (getClass () == NetworkCallbackImpl.class)
			mono.android.TypeManager.Activate ("DLUTToolBoxMobile.Droid.NetworkCallbackImpl, DLUTToolBoxMobile.Android", "", this, new java.lang.Object[] {  });
	}


	public NetworkCallbackImpl (int p0)
	{
		super (p0);
		if (getClass () == NetworkCallbackImpl.class)
			mono.android.TypeManager.Activate ("DLUTToolBoxMobile.Droid.NetworkCallbackImpl, DLUTToolBoxMobile.Android", "System.Int32, mscorlib", this, new java.lang.Object[] { p0 });
	}


	public void onAvailable (android.net.Network p0)
	{
		n_onAvailable (p0);
	}

	private native void n_onAvailable (android.net.Network p0);


	public void onLost (android.net.Network p0)
	{
		n_onLost (p0);
	}

	private native void n_onLost (android.net.Network p0);


	public void onCapabilitiesChanged (android.net.Network p0, android.net.NetworkCapabilities p1)
	{
		n_onCapabilitiesChanged (p0, p1);
	}

	private native void n_onCapabilitiesChanged (android.net.Network p0, android.net.NetworkCapabilities p1);


	public void onBlockedStatusChanged (android.net.Network p0, boolean p1)
	{
		n_onBlockedStatusChanged (p0, p1);
	}

	private native void n_onBlockedStatusChanged (android.net.Network p0, boolean p1);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
