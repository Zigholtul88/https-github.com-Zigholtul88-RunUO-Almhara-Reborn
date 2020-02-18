/////////////////////////////////////////////////
//
// Automatically generated by the
// AddonGenerator script by Arya
//
/////////////////////////////////////////////////
using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class MLTree18Addon : BaseAddon
	{
		public override BaseAddonDeed Deed
		{
			get
			{
				return new MLTree18AddonDeed();
			}
		}

		[ Constructable ]
		public MLTree18Addon()
		{
			AddonComponent ac = null;
			ac = new AddonComponent( 15053 );
			AddComponent( ac, 3, -1, 0 );
			ac = new AddonComponent( 15052 );
			AddComponent( ac, 3, 0, 0 );
			ac = new AddonComponent( 15051 );
			AddComponent( ac, -3, 1, 0 );
			ac = new AddonComponent( 15050 );
			AddComponent( ac, -3, 1, 0 );
			ac = new AddonComponent( 15049 );
			AddComponent( ac, -2, 1, 0 );
			ac = new AddonComponent( 15048 );
			AddComponent( ac, -1, 1, 0 );
			ac = new AddonComponent( 15047 );
			AddComponent( ac, 0, 1, 0 );
			ac = new AddonComponent( 15046 );
			AddComponent( ac, 1, 1, 0 );
			ac = new AddonComponent( 15045 );
			AddComponent( ac, 2, 1, 0 );
			ac = new AddonComponent( 15044 );
			AddComponent( ac, 3, 1, 0 );

		}

		public MLTree18Addon( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( 0 ); // Version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	public class MLTree18AddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{
			get
			{
				return new MLTree18Addon();
			}
		}

		[Constructable]
		public MLTree18AddonDeed()
		{
			Name = "MLTree18";
		}

		public MLTree18AddonDeed( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( 0 ); // Version
		}

		public override void	Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}