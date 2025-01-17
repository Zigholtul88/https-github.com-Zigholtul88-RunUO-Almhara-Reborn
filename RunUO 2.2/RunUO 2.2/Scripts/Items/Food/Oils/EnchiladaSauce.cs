using System;
using System.IO;
using System.Collections;
using Server;
using Server.Items;
using Server.Targeting;
using Server.Network;

namespace Server.Items
{
	public class EnchiladaSauce : Item
	{
		[Constructable]
		public EnchiladaSauce() : base( 0xF04 )
		{
			Stackable = true;
			Hue = 0x1B5;
			Name = "Enchilada Sauce";
		}

		public EnchiladaSauce( Serial serial ) : base( serial )
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