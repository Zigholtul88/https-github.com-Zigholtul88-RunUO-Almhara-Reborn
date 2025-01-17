using System;
using Server.Items;

namespace Server.Items
{
	public class FrozenLongbow : ElvenCompositeLongbow
	{
		public override int LabelNumber{ get{ return 1073507; } } // frozen longbow

		[Constructable]
		public FrozenLongbow()
		{
			WeaponAttributes.HitHarm = 15;
		}

		public FrozenLongbow( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();
		}
	}
}
