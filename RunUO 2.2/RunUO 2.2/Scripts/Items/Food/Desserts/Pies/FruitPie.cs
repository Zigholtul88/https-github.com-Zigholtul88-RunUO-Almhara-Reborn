using System;
using System.Collections;
using Server.Network;
using System.Collections.Generic;
using Server.ContextMenus;

namespace Server.Items
{
	public class FruitPie : Food
	{
		public override int LabelNumber{ get{ return 1041346; } } // baked fruit pie

		[Constructable]
		public FruitPie() : base( 0x1041 )
		{
			Stackable = false;
			this.Weight = 1.0;
			this.FillFactor = 5;
		}

		public FruitPie( Serial serial ) : base( serial )
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