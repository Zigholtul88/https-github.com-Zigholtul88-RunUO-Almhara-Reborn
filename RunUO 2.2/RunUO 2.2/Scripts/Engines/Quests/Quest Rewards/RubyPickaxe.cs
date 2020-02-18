using System;
using Server;
using Server.Engines.Harvest;

namespace Server.Items
{
	public class RubyPickaxe : BaseAxe, IUsesRemaining
	{
		public override HarvestSystem HarvestSystem{ get{ return Mining.System; } }

		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.DoubleStrike; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.Disarm; } }

		public override int AosStrengthReq{ get{ return 25; } }
		public override int AosMinDamage{ get{ return 1; } }
		public override int AosMaxDamage{ get{ return 15; } }
		public override int AosSpeed{ get{ return 35; } }

		public override WeaponAnimation DefAnimation{ get{ return WeaponAnimation.Slash1H; } }

		[Constructable]
		public RubyPickaxe() : this( 1000 )
		{
		}

		[Constructable]
		public RubyPickaxe( int uses ) : base( 0xE86 )
		{
                        Name = "Ruby Pickaxe";
			Weight = 11.0;
			Hue = 35;
			UsesRemaining = uses;
			ShowUsesRemaining = true;

			LootType = LootType.Blessed;
		}

		public RubyPickaxe( Serial serial ) : base( serial )
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