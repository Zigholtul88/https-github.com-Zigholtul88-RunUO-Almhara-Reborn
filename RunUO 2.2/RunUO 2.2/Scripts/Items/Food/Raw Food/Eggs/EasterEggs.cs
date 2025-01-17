using System;
using Server.Targeting;
using Server.Items;
using Server.Network;

namespace Server.Items
{
	public class EasterEggs : CookableFood
	{
		public override int LabelNumber{ get{ return 1016105; } } // Easter Eggs

		[Constructable]
		public EasterEggs() : base( 0x9B5, 15 )
		{
			Weight = 0.5;
			Hue = 3 + (Utility.Random( 20 ) * 5);
		}

		public EasterEggs( Serial serial ) : base( serial )
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

		public override Food Cook()
		{
			return new FriedEggs();
		}
	}
}