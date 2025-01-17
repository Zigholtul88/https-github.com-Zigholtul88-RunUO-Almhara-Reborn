using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a krakens corpse" )]
	public class Kraken : BaseCreature
	{
		[Constructable]
		public Kraken() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a kraken";
			Body = 77;
			BaseSoundID = 353;

			SetStr( 756, 780 );
			SetDex( 226, 245 );
			SetInt( 26, 40 );

			SetHits( 908, 936 );
			SetMana( 0 );

			SetDamage( 19, 33 );

			SetDamageType( ResistanceType.Physical, 70 );
			SetDamageType( ResistanceType.Cold, 30 );

			SetResistance( ResistanceType.Physical, 50 );
			SetResistance( ResistanceType.Fire, 30 );
			SetResistance( ResistanceType.Cold, 30 );
			SetResistance( ResistanceType.Poison, 20 );
			SetResistance( ResistanceType.Energy, 10 );

			SetSkill( SkillName.MagicResist, 15.1, 20.0 );
			SetSkill( SkillName.Tactics, 45.1, 60.0 );
			SetSkill( SkillName.Wrestling, 45.1, 60.0 );

			Fame = 11000;
			Karma = -11000;

			CanSwim = true;
			CantWalk = true;

			PackGold( 79, 86 );

			Rope rope = new Rope();
			rope.ItemID = 0x14F8;
			PackItem( rope );
			
			if( Utility.RandomDouble() < .05 )
				PackItem( new MessageInABottle() );
				
			PackItem( new SpecialFishingNet() ); //Confirm?

			switch ( Utility.Random( 9 ))
			{
				case 0: PackItem( new ShimmeringExecutionersAxeOfAquaticElegance() ); break;
				case 1: PackItem( new ShimmeringCrossbowOfAquaticElegance() ); break;
				case 2: PackItem( new ShimmeringDaggerOfAquaticElegance() ); break;
				case 3: PackItem( new ShimmeringWarMaceOfAquaticElegance() ); break;
				case 4: PackItem( new ShimmeringHalberdOfAquaticElegance() ); break;
				case 5: PackItem( new ShimmeringSpearOfAquaticElegance() ); break;
				case 6: PackItem( new ShimmeringStaffOfAquaticElegance() ); break;
				case 7: PackItem( new ShimmeringCutlassOfAquaticElegance() ); break;
				case 8: PackItem( new ShimmeringHeaterShieldOfAquaticElegance() ); break;
			}

			PackItem( new FishScale( Utility.RandomMinMax( 50, 100 ) ) );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich, 4 );
		}

		public Kraken( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}
