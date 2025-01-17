using System;
using Server.Items;

namespace Server.Items
{
	public class AncientWildStaff : WildStaff
	{
		public override int LabelNumber{ get{ return 1073550; } } // ancient wild staff

		[Constructable]
		public AncientWildStaff()
		{
			WeaponAttributes.ResistPoisonBonus = 25;
		}

		public AncientWildStaff( Serial serial ) : base( serial )
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
