using System;
using Server;
using Server.Spells.Third;
using Server.Targeting;

namespace Server.Items
{
	public class FireballWand : BaseWand
	{
		[Constructable]
		public FireballWand() : base( WandEffect.Fireball, 5, 50 )
		{
                Name = "Fireball Wand";
		}

		public FireballWand( Serial serial ) : base( serial )
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

		public override void OnWandUse( Mobile from )
		{
			Cast( new FireballSpell( from, this ) );
		}
	}
}