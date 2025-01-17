using System;
using Server;
using Server.Engines.Craft;


namespace Server.Items
{
	public class RunicFrostwood : RunicFletchersTools
	{

		[Constructable]
		public RunicFrostwood() : this( 10 )
		{
		}		

		[Constructable]
		public RunicFrostwood( int uses ) : base( CraftResource.Frostwood )
		{
                  Name = "Frostwood Runic Fletchers Tools";
                  Hue = 1151;
			Weight = 1.0;
			UsesRemaining = uses;
		}
		public RunicFrostwood( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}